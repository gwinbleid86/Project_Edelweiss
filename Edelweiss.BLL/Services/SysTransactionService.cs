using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using Edelweiss.BLL.DTO;
using Edelweiss.BLL.Enums;
using Edelweiss.BLL.Infrastructure;
using Edelweiss.BLL.Interfaces;
using Edelweiss.DAL.Entities;
using Edelweiss.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using X.PagedList;

namespace Edelweiss.BLL.Services
{
    public class SysTransactionService : ISysTransactionService
    {
        private IUnitOfWork Database { get; set; }
        private UserManager<User> _userManager;
        ICommissionService _commissionService { get; set; }
        IClientService _clientService { get; set; }
        ICountryService _countryService { get; set; }
        private const int pageSize = 5;

        public SysTransactionService(IUnitOfWork uow, UserManager<User> userManager, ICommissionService service,  
            IClientService clientService, ICountryService countryService)
        {
            Database = uow;
            _userManager = userManager;
            _commissionService = service;
            _clientService = clientService;
            _countryService = countryService;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++      Base       ++++++++++++++++++++++++++++++++++++++++++++++++++

        public IPagedList<SysTransactionDTO> GetAll(int page)
        {
            return Mapper.Map<IEnumerable<SysTransactionDTO>>(Database.TransactionsAC.GetAll()).ToPagedList(page, pageSize);
        }

        public IPagedList<SysTransactionDTO> GetAllByUserId(string userId, int page)
        {
            User currentUser = Database.Users.GetByUserId(userId);
            Agent agent = Database.Agents.Get(currentUser.AgentId);
            var transactions =
                Database.TransactionsAC.Find(sysTransaction => sysTransaction.CountryId == agent.CountryId);
            return Mapper.Map<IEnumerable<SysTransactionDTO>>(transactions).ToPagedList(page, pageSize);
        }

        IEnumerable<SysTransactionDTO> ISysTransactionService.Find(Expression<Func<SysTransaction, bool>> predicate)
        {
            return Mapper.Map<IEnumerable<SysTransactionDTO>>(Database.TransactionsAC.Find(predicate));
        }

        //Все транзакции "По статусам" для данного агента, а также
        //Транзакции которые необходимо подтвердить котроллеру
        public IPagedList<SysTransactionDTO> AllByStatusAndUserId(string userId, string value, int page)
        {
            //int pageNumber = page;
            return Mapper.Map<IEnumerable<SysTransactionDTO>>
            (Database.TransactionsAC
                .Find(t => t.TransactionStatus == ((int)(TransactionStatus)Enum.Parse(typeof(TransactionStatus), value))
                           && t.AgentFrom.Id == Database.Users.GetByUserId(userId).AgentId)).ToPagedList(page, pageSize);
        }

        //---------------------------------   Controller ViewMethods   -----------------------------------

        //Все транзакции данного cубагента которые видны котроллеру(только просмотр)
        public IPagedList<SysTransactionDTO> AllForControllerAsSubAgent(string userId, int page)//Не находит субагентов
        {
            return Mapper.Map<IEnumerable<SysTransactionDTO>>
            (Database.TransactionsAC
                .Find(t => t.AgentFrom.Id == Database.Users.GetByUserId(userId).AgentId)).ToPagedList(page, pageSize); 
        }

        //Доступ котроллеру для просмотра всех транзакций своей точки и парентагента 
        public IPagedList<SysTransactionDTO> AllForControllerAsAgent(string userId, int page)
        {
            User user = Database.Users.GetByUserId(userId);
            Agent agent = Database.Agents.Get(user.AgentId);
            List<int> relatedAgents = new List<int>();

            relatedAgents = agent.ParentAgentId == null ? Database.Agents.Find(a => a.ParentAgentId == agent.Id).Select(c => c.Id).ToList()
                : Database.Agents.Find(a => a.Id == agent.ParentAgentId).Select(c => c.Id).ToList();
            IEnumerable<SysTransaction> childAgetntsTransactions = Database.TransactionsAC.Find(t => relatedAgents.Contains(t.AgentFromId));
            IEnumerable<SysTransaction> agentTransactions = Database.TransactionsAC.Find(t => t.AgentFromId == agent.Id);

            return Mapper.Map<IEnumerable<SysTransactionDTO>>(agentTransactions.Union(childAgetntsTransactions)).ToPagedList(page, pageSize);
        }


        public SysTransactionDTO Get(int id)
        {
            var transaction = Database.TransactionsAC.Get(id);
            if (transaction == null)
                throw new ValidationException("Транзакция не найдена", "");

            return Mapper.Map<SysTransactionDTO>(transaction);
        }

        public ClientsAndTransactionDTO GetClientsAndTransactionDTO(int id)
        {
            ClientsAndTransactionDTO model = new ClientsAndTransactionDTO();
            ClientDTO client = _clientService.Get(id);
            model.Id = client.Id;
            model.Name = client.Name;
            model.LastName = client.LastName;

            return model;
        }

        public SysTransactionDTO SingleOrDefault(Func<SysTransaction, bool> predicate)
        {
            return Mapper.Map<SysTransactionDTO>(Database.TransactionsAC.SingleOrDefault(predicate));
        }

        public SysTransactionDTO SingleIncludeAgents(int id)
        {
            return Mapper.Map<SysTransactionDTO>(Database.TransactionsAC.SingleIncludeAgents(id));
        }

        public void Create(ClientsAndTransactionDTO item, string userId)
        {
            string tcn = TcnGenerator();

            User user = Database.Users.GetByUserId(userId);
            Agent agentFrom = Database.Agents.Get((user.AgentId));
            SysTransactionDTO transaction = item.SysTransactionDto;
            ClientDTO clientTo = item.ClientDto;

            var result = _clientService.FirstOrDefault(c =>
                c.Name == clientTo.Name && c.LastName == clientTo.LastName && c.MobilePhone == clientTo.MobilePhone);

            if (result == null)
            {
                _clientService.Create(clientTo);
                clientTo = _clientService.FirstOrDefault(c => c.MobilePhone == clientTo.MobilePhone);
            }
            else
            {
                clientTo = result;
            }

            Country country = Mapper.Map<Country>(_countryService.Get(agentFrom.CountryId));
            Currency currency =
                Database.Currencies.SingleOrDefault(c => c.Id == Convert.ToInt32(item.SysTransactionDto.CurrencyName));

            transaction.AgentFromId = agentFrom.Id;
            transaction.TransactionStatus = (int)TransactionStatus.Created;
            transaction.Tcn = tcn;
            transaction.UserFromId = userId;
            transaction.CreateDateLocal = DateTime.UtcNow.AddHours(country.Utc); // Дата в часовом поясе агента
            transaction.ClientToId = clientTo.Id;
            transaction.CreateDateUtc = DateTime.UtcNow;
            transaction.CurrencyId = currency.Id;
            
            var map = Mapper.Map<SysTransaction>(transaction);
            Database.TransactionsAC.Create(map);
            Database.Save();

            _countryService.UpdatePopularity(item.SysTransactionDto.CountryId);
        }

        public ClientsAndTransactionDTO Copy(int id, string userId, int clientToId, int clientFromId)
        {   
            SysTransaction copyTransaction = Database.TransactionsAC.Get(id);
            Client clientTo = Database.Clients.Get(clientToId);
            Client clientFrom = Database.Clients.Get(clientFromId);

            ClientsAndTransactionDTO copyClientsAndTransactionTransactionDto = new ClientsAndTransactionDTO
            {
                SysTransactionDto = new SysTransactionDTO
                {   
                    Sum = copyTransaction.Sum,
                    CurrencyName = copyTransaction.Currency.Name,
                    CountryId = copyTransaction.CountryId,
                    ClientFromId = copyTransaction.ClientFromId,
                },
                ClientDto = new ClientDTO
                {
                    Name = clientTo.Name,
                    LastName = clientTo.LastName,
                    MobilePhone = clientTo.MobilePhone
                },
                Id = clientFrom.Id,
                Name = clientFrom.Name,
                LastName = clientFrom.LastName
        };
            return copyClientsAndTransactionTransactionDto;  
        }

        public void Update(SysTransactionDTO item)
        {
            SysTransaction map = Mapper.Map<SysTransaction>(item);
            Database.TransactionsAC.Update(map);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.TransactionsAC.Delete(id);
            Database.Save();
        }

        //+++++++++++++++++++++++++++++++++++++++++++++++     Statuses      +++++++++++++++++++++++++++++++++++++++++++++++++

        //перевод в статусы "К оплате" и "Одобрено"

        public bool StatusToPayAndApproved(int id, string value)
        {
            SysTransaction transaction = Database.TransactionsAC.Get(id);
            transaction.TransactionStatus = (int)(TransactionStatus)Enum.Parse(typeof(TransactionStatus), value);
            Database.TransactionsAC.Update(transaction);
            Database.Save();
            return transaction.TransactionStatus == (int)(TransactionStatus)Enum.Parse(typeof(TransactionStatus), value);
        }

        //перевод в статус "Подтвержден"
        public bool StatusConfirmed(int id, string userId)
        {
            SysTransaction transaction = Database.TransactionsAC.Get(id);
            //User user = Database.Users.GetByUserId(userId);
            Agent agent = Database.Agents.Get(transaction.AgentFromId);
            Country country = Mapper.Map<Country>(_countryService.Get(agent.CountryId));
            Tariff tariff = _commissionService.GetTariff(transaction, transaction.AgentFromId);
            decimal summ = _commissionService.GetCommissionWhenTransactionCreate(tariff.CommissionType, tariff.Value, transaction);
            transaction.TransactionStatus = (int)TransactionStatus.Confirmed;
            transaction.ConfirmDateLocal = DateTime.UtcNow.AddHours(country.Utc); // Дата в часовом поясе агента
            transaction.ConfirmDateUtc = DateTime.UtcNow;
            transaction.ControllerId = userId;
            transaction.Sum = summ;
            Database.TransactionsAC.Update(transaction);
            Database.Save();
            return transaction.TransactionStatus == (int)TransactionStatus.Confirmed;
        }

        //перевод в статус "К выплате"
        public bool StatusToPayOff(int id, string userId)
        {
            SysTransaction transaction = Database.TransactionsAC.Get(id);
            transaction.TransactionStatus = (int)TransactionStatus.ToPayOff;
            transaction.UserToId = userId;
            transaction.AgentToId = Database.Users.GetByUserId(userId).AgentId;
            Database.TransactionsAC.Update(transaction);
            Database.Save();

            return transaction.TransactionStatus == (int)TransactionStatus.ToPayOff;
        }

        //перевод в статус "Выдан"
        public bool StatusToIssued(int id)
        {
            SysTransaction transaction = Database.TransactionsAC.Get(id);
            Country country = Mapper.Map<Country>(_countryService.Get(transaction.CountryId));
            Tariff tariff = _commissionService.GetTariff(transaction, transaction.AgentFromId);
            decimal summ = _commissionService.GetCommissionWhenTransactionIssued(tariff.CommissionType, tariff.Value, transaction);
            transaction.TransactionStatus = (int)TransactionStatus.Issued;
            transaction.IssueDateLocal = DateTime.UtcNow.AddHours(country.Utc); // Дата в часовом поясе агента
            transaction.IssueDateUtc = DateTime.UtcNow;
            transaction.Sum = summ;
            Database.TransactionsAC.Update(transaction);
            Database.Save();
            _commissionService.SendSmsToClientSender(transaction.ClientFromId);

            return transaction.TransactionStatus == (int)TransactionStatus.Issued;
        }

        //перевод в статус "Отменен"
        public bool StatusToCanceled(int id)
        {
            SysTransaction transaction = Database.TransactionsAC.Get(id);
            Agent agent = Database.Agents.Get(transaction.AgentFromId);
            Country country = Mapper.Map<Country>(_countryService.Get(agent.CountryId));
            Tariff tariff = _commissionService.GetTariff(transaction, transaction.AgentFromId);
            if (transaction.TransactionStatus == (int) TransactionStatus.Issued && transaction.AgentFromId == id)
            {
                return false;
            }
            decimal summ = _commissionService.GetCommissionWhenTransactionIssued(tariff.CommissionType, tariff.Value, transaction);
            transaction.TransactionStatus = (int)TransactionStatus.Canceled;
            transaction.IssueDateLocal = DateTime.UtcNow.AddHours(country.Utc); // Дата в часовом поясе агента
            transaction.IssueDateUtc = DateTime.UtcNow;
            
            Database.TransactionsAC.Update(transaction);
            Database.Save();

            return transaction.TransactionStatus == (int)TransactionStatus.Canceled;
        }

        //Все транзакции отправленные в данную страну и подтвержденные Контроллером отправителем
        public IPagedList<SysTransactionDTO> AllTransactionsToPayOff(string userId, int page)
        {
            User user = Database.Users.GetByUserId(userId);
            Agent agent = Database.Agents.Get(user.AgentId);
            return Mapper.Map<IEnumerable<SysTransactionDTO>>
            (Database.TransactionsAC
                .Find(t => 
                    t.CountryId == agent.CountryId &&
                    t.TransactionStatus == (int)TransactionStatus.Confirmed
                    )).ToPagedList(page, pageSize); 
        }

        //Все транзакции принятые к выплате, у них уже заполнены поля UserToId и AgentToId или
        //Все выплаченные транзакции данного агента. 
        //Которые не могут быть отменены т.е. ToPayOff и Issued
        public IPagedList<SysTransactionDTO> AllTransactionsCantCanceled(string userId, string value, int page)
        {
            //int pageSize = 3;
            //int pageNumber = page;
            User user = Database.Users.GetByUserId(userId);
            Agent agent = Database.Agents.Get(user.AgentId);
            
            return Mapper.Map<IEnumerable<SysTransactionDTO>>
            (Database.TransactionsAC
                .Find(t =>
                    t.AgentToId == agent.Id &&
                    t.TransactionStatus == (int)(TransactionStatus)Enum.Parse(typeof(TransactionStatus), value)//(int)TransactionStatus.ToPayOff
                )).ToPagedList(page, pageSize); 
        }
        
        //Все отмененные транзакции данного пользователя
        public IPagedList<SysTransactionDTO> AllTransactionsCanceled(string userId, int page)
        {
            return Mapper.Map<IEnumerable<SysTransactionDTO>>
            (Database.TransactionsAC
                .Find(t =>
                    t.UserFromId == userId &&
                    t.TransactionStatus == (int)TransactionStatus.Canceled
                )).ToPagedList(page, pageSize); 
        }


        //++++++++++++++++++++++++++++++++++++++++++++++      Sort       ++++++++++++++++++++++++++++++++++++++++++++++++++

        public SortDTO Sort(
            string tcn,
            string country,
            string agentTo,
            string agentFrom,
            DateTime timeFrom,
            DateTime timeTo,
            string fio,
            int page,
            string userId,
            SortState sortOrder = SortState.NameAsc)
        {
            User user = Database.Users.GetByUserId(userId);
            //IEnumerable<SysTransactionDTO> sysTransactions = Mapper.Map<IEnumerable<SysTransactionDTO>>(Database.TransactionsAC.Find(x => x.TransactionStatus == (int)TransactionStatus.Created));
            IEnumerable<SysTransactionDTO> sysTransactions = Mapper.Map<IEnumerable<SysTransactionDTO>>(Database.TransactionsAC.Find(t => t.AgentFromId == user.AgentId));
            

            if (!string.IsNullOrEmpty(tcn))
            {
                sysTransactions = Mapper.Map<IEnumerable<SysTransactionDTO>>(Database.TransactionsAC.Find(x => x.Tcn == tcn));
            }

            if (!string.IsNullOrEmpty(country))
            {
                //sysTransactions = Mapper.Map<IEnumerable<SysTransactionDTO>>(Database.TransactionsAC.GetTransactionByCountry(country));
                sysTransactions = Mapper.Map<IEnumerable<SysTransactionDTO>>(Database.TransactionsAC.Find(t => t.AgentTo.Country.Name == country));
            }

            if (!string.IsNullOrEmpty(agentTo))
            {
                sysTransactions = Mapper.Map<IEnumerable<SysTransactionDTO>>(Database.TransactionsAC.Find(x => x.AgentTo.Name.Contains(agentTo)));
               

            }

            if (!string.IsNullOrEmpty(agentFrom))
            {
                sysTransactions = Mapper.Map<IEnumerable<SysTransactionDTO>>(Database.TransactionsAC.Find(x => x.AgentFrom.Name.Contains(agentFrom)));
            }

            if (timeFrom > DateTime.MinValue)
            {
                sysTransactions = Mapper.Map<IEnumerable<SysTransactionDTO>>(Database.TransactionsAC.Find(p => p.CreateDateLocal >= timeFrom));
            }

            if (timeTo > DateTime.MinValue)
            {
                sysTransactions = Mapper.Map<IEnumerable<SysTransactionDTO>>(Database.TransactionsAC.Find(p => p.CreateDateLocal <= timeTo));
            }

            if (timeFrom > DateTime.MinValue && timeTo > DateTime.MinValue)
            {

                sysTransactions = Mapper.Map<IEnumerable<SysTransactionDTO>>(Database.TransactionsAC.Find(p => p.CreateDateLocal <= timeTo && p.CreateDateLocal >= timeFrom));
            }
            if (!string.IsNullOrEmpty(fio))
            {
                sysTransactions = Mapper.Map<IEnumerable<SysTransactionDTO>>(Database.TransactionsAC.Find(t => t.ClientFrom.LastName.Contains(fio)));
            }
           
            return new SortDTO()
            {
                Transaction = sysTransactions.OrderBy(t => t.CreateDateLocal).ToPagedList(page, pageSize),
                AgentFrom = agentFrom,
                AgentTo = agentTo,
                DateFrom = timeFrom,
                DateTo = timeTo,
                Fio = fio,
                Country = country
            };
        }

        //++++++++++++++++++++++++++++++++++++++++++++++      Other       ++++++++++++++++++++++++++++++++++++++++++++++++++


        // Метод проверки для отмены транзакции
        // Он выполняет проверку этот ли агент отправлял этот перевод, если да то возращает true

        public bool Checker(int transactionId, string userId)
        {
            SysTransaction transaction = Database.TransactionsAC.SingleOrDefault(t => t.Id == transactionId);
            User user = Database.Users.GetByUserId(userId);
            Agent agent = Database.Agents.SingleOrDefault(a => a.Id == user.AgentId);

            if (transaction.AgentFromId == Database.Users.GetByUserId(userId).AgentId ||
                transaction.CountryId == agent.CountryId)
            {
                return true;
            }

            return false;
        }

        private string TcnGenerator()
        {
            const int length = 10;
            string characters = "QWE1RTY2UIO3PAS4DFG5HJK6LZX7CVB8NM912345678qwe1rty2ui3opa4sdf5ghj6klz7xcv8bnm9";
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder(length);
            int position = 0;
            for (int i = 0; i < length; i++)
            {
                position = rnd.Next(0, characters.Length - 1);
                sb.Append(characters[position]);
            }

            if (TcnUniquenessCheck(sb.ToString()))
            {
                return sb.ToString();
            }

            return TcnGenerator();
        }

        private bool TcnUniquenessCheck(string tcn)
        {
            if (Database.TransactionsAC.GetByField(t => t.Tcn == tcn) == null)
            {
                return true;
            }
            return false;
        }
    }
}

