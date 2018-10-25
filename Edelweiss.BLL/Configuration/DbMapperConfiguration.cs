using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Edelweiss.BLL.DTO;
using Edelweiss.DAL.Entities;

namespace Edelweiss.BLL.Configuration
{
    public class DbMapperConfiguration : Profile
    {
        public DbMapperConfiguration()
        {
            CreateMap<Agent, AgentDTO>()
                .ForMember(x => x.ParentAgentName, opt => opt.MapFrom(s => s.ParentAgent.Name))
                .ForMember(x => x.CountryName, opt => opt.MapFrom(s => s.Country.Name))
                .ForMember(x => x.ImageLogo, s => s.Ignore())
                .ForMember(x => x.ImagePromo, s => s.Ignore());

            CreateMap<AgentDTO, Agent>()
                .ForMember(x => x.ParentAgent, s => s.Ignore())
                .ForMember(x => x.Country, s => s.Ignore())
                .ForMember(x => x.ImageLogo, s => s.Ignore())
                .ForMember(x => x.ImagePromo, s => s.Ignore())
                .ForMember(x => x.User, s => s.Ignore())
                .ForMember(x => x.Tariffs, s => s.Ignore())
                .ForMember(x => x.SysTransactionsTo, s => s.Ignore())
                .ForMember(x => x.SysTransactionsFrom, s => s.Ignore());

            CreateMap<Client, ClientDTO>();
            CreateMap<ClientDTO, Client>()
                .ForMember(d => d.SysTransactionsFrom, x => x.Ignore())
                .ForMember(d => d.SysTransactionsTo, x => x.Ignore());

            CreateMap<Country, CountryDTO>();
            CreateMap<CountryDTO, Country>()
                .ForMember(x => x.Agents, x => x.Ignore())
                .ForMember(x => x.Tariffs, x => x.Ignore())
                .ForMember(x => x.CellPhoneMasks, x => x.Ignore());
            CreateMap<Currency, CurrencyDTO>();
            CreateMap<CurrencyDTO, Currency>()
                .ForMember(x => x.Tariffs, x => x.Ignore());

            CreateMap<SysTransaction, SysTransactionDTO>()
                .ForMember(x => x.ClientFromName, opt => opt.MapFrom(s => s.ClientFrom.LastName))
                .ForMember(x => x.ClientToName, opt => opt.MapFrom(s => s.ClientTo.LastName))
                .ForMember(x => x.AgentFromName, opt => opt.MapFrom(s => s.AgentFrom.Name))
                .ForMember(x => x.AgentToName, opt => opt.MapFrom(s => s.AgentTo.Name))
                .ForMember(x => x.CountryName, opt => opt.MapFrom(s => s.Country.Name))
                .ForMember(x => x.CurrencyName, opt => opt.MapFrom(s => s.Currency.Name))
                .ForMember(x => x.CurrencyId, opt => opt.MapFrom(s => s.Currency.Id))
                .ForMember(x => x.AgentFromTextPromo, opt => opt.MapFrom(s => s.AgentFrom.TextPromo))

                .ForMember(x => x.AgentFromCommission, opt => opt.MapFrom(s => s.Commissions.
                    FirstOrDefault(c => c.AgentId == s.AgentFromId && c.TransactionId == s.Id).Value))
                .ForMember(x => x.AgentToCommission, opt => opt.MapFrom(s => s.Commissions.
                    FirstOrDefault(c => c.AgentId == s.AgentToId && c.TransactionId == s.Id).Value))
                .ForMember(x => x.SystemCommission, opt => opt.MapFrom(s => s.Commissions
                    .FirstOrDefault(c => c.Agent.Name == "System" && c.TransactionId == s.Id).Value))

                .ForMember(x => x.Status, opt => opt.MapFrom(s => s.TransactionStatus));
            CreateMap<SysTransactionDTO, SysTransaction>()
                .ForPath(x => x.Currency.Id, opt => opt.MapFrom(s => s.CurrencyId))
                .ForMember(x => x.Currency, x => x.Ignore())
                .ForMember(x => x.AgentTo, x => x.Ignore())
                .ForMember(x => x.AgentFrom, x => x.Ignore())
                .ForMember(x => x.ClientTo, x => x.Ignore())
                .ForMember(x => x.ClientFrom, x => x.Ignore())
                .ForMember(x => x.Country, x => x.Ignore())
                .ForMember(x => x.ConfirmDateUtc, x => x.Ignore())
                .ForMember(x => x.IssueDateLocal, x => x.Ignore())
                .ForMember(x => x.IssueDateUtc, x => x.Ignore());

            CreateMap<Tariff, TariffDTO>()
                .ForMember(x => x.AgentName, opt => opt.MapFrom(s => s.Agent.Name))
                .ForMember(x => x.CountryName, opt => opt.MapFrom(s => s.Country.Name))
                .ForMember(x => x.CurrencyName, opt => opt.MapFrom(s => s.Currency.Name))
                .ForMember(x => x.RangeMinValue, opt => opt.MapFrom(s => s.Range.MinValue))
                .ForMember(x => x.RangeMaxValue, opt => opt.MapFrom(s => s.Range.MaxValue))
                .ForMember(x => x.TypeOfCommission, opt => opt.MapFrom(s => s.CommissionType));
            CreateMap<TariffDTO, Tariff>()
                .ForMember(x => x.Agent, x => x.Ignore())
                .ForMember(x => x.Currency, x => x.Ignore())
                .ForMember(x => x.Range, x => x.Ignore())
                .ForMember(x => x.Country, x => x.Ignore());

            CreateMap<Range, RangeDTO>();
            CreateMap<RangeDTO, Range>()
                .ForMember(x => x.Tariffs, x => x.Ignore());

            CreateMap<User, UserDTO>();

            CreateMap<CellPhoneMaskDTO, CellPhoneMask>()
                .ForMember(x => x.Country, x => x.Ignore());
            CreateMap<CellPhoneMask, CellPhoneMaskDTO>()
                .ForMember(x => x.CountryName, opt => opt.MapFrom(s => s.Country.Name));

            CreateMap<CommissionDTO, Commission>();
            CreateMap<Commission, CommissionDTO>();

            CreateMap<CommissionsDividingDTO, CommissionDividing>();
            CreateMap<CommissionDividing, CommissionsDividingDTO>();
                        
        }
    }
}
