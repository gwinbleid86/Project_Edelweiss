using System;
using System.Linq;
using Edelweiss.BLL.DTO;
using Edelweiss.BLL.Enums;
using Edelweiss.BLL.Interfaces;
using Edelweiss.DAL.Entities;
using Edelweiss.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace Project_Edelweiss.Controllers
{
    public class SysTransactionsController : Controller
    {
        IAgentService _agentService;
        private IUnitOfWork Database { get; set; }
        ISysTransactionService transactionService;
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        ICountryService countryService;
        ICurrencyService _currencyService;
        IClientService _clientService;

        public SysTransactionsController(ICountryService countryService, 
            IUnitOfWork uow, 
            ISysTransactionService transactionService,
            ICurrencyService currencyService,
            UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager,
            IAgentService agentService,
            IClientService clientService)
        {
            Database = uow;
            this.transactionService = transactionService;
            _currencyService = currencyService;
            _userManager = userManager;
            _roleManager = roleManager;
            this.countryService = countryService;
            _agentService = agentService;
            _clientService = clientService;
        }
        //++++++++++++++++++++++++++++++++++++++++++++++      CRUD       ++++++++++++++++++++++++++++++++++++++++++++++++++
        // GET: SysTransactions
        //[Authorize(Roles = "SuperAdmin")]
        public IActionResult Index(bool role, int page = 1)
        { 
            //TODO: в последствии попробовать изменить, что бы не задействовать логику в контроллере. Если заходить под админом - на агенте вылетает эксепшн.
            User currentUser = Database.Users.GetByUserId(_userManager.GetUserId(HttpContext.User));
            Agent agent = Database.Agents.Get(currentUser.AgentId);
            if(agent.ImageLogo != null)
            { ViewBag.Logo = agent.ImageLogo;}
            if (agent.ImagePromo != null)
            { ViewBag.Promo = agent.ImagePromo; }

            if (role)
            {
                return View(transactionService.GetAll(page));
            }
            return View(transactionService.GetAllByUserId(_userManager.GetUserId(HttpContext.User), page));
        }

        // GET: SysTransactions/Details/5
        [Authorize(Roles = "Admin, Agent, Cashier, Controller,ControllerExtended")]
        public ActionResult Details(int id, int idAgent)
        {
            if (!transactionService.Checker(id, _userManager.GetUserId(HttpContext.User)))
            {
                return RedirectToAction(nameof(CanceledTransaction));
            }

            ViewBag.CountryFrom = _agentService.GetAgentByUserId(_userManager.GetUserId(HttpContext.User));// для отображения кнпки отмена только тому, кто создавал перевод.
            if(_agentService.GetAgent(idAgent).ImagePromo != null)
            { ViewBag.Promo = _agentService.GetAgent(idAgent).ImagePromo;}
            return View(transactionService.SingleIncludeAgents(id));

        }

        [Authorize(Roles = "Admin, Agent, Cashier, Controller,ControllerExtended")]
        public ActionResult CanceledTransaction()
        {
            return View();

        }

        // GET: SysTransactions/Create
        [Authorize(Roles = "Admin,Cashier,ControllerExtended")]
        public ActionResult Create(int id, string sort)
        {
            
            ViewBag.countries = new SelectList(countryService.SortByPopularity(), "Id", "Name");
            
            //ViewBag.countries = new SelectList(countryService.GetAll(), "Id", "Name");
           // ViewBag.countriesByName = new SelectList(countryService.SortByName(), "Id", "Name");
           // ViewBag.countriesByPopularity = new SelectList(countryService.SortByPopularity(), "Id", "Name");
            ViewBag.currencies = new SelectList(_currencyService.GetAll(), "Id", "Name");
            ViewBag.clientFromId = id;
            return View(transactionService.GetClientsAndTransactionDTO(id));
        }

        [HttpPost]
        public ActionResult SortByName()
        { 
            return Json(new SelectList(countryService.SortByName(), "Id", "Name"));
        }

        [HttpPost]
        public ActionResult SortByPopularity()
        { 
            return Json(new SelectList(countryService.SortByPopularity(), "Id", "Name"));
        }

        // POST: SysTransactions/Create
        [HttpPost]
        [Authorize(Roles = "Admin,Cashier,ControllerExtended")]
        public IActionResult Create(ClientsAndTransactionDTO model)
        {
            if (ModelState.IsValid)
            {
                transactionService.Create(model, _userManager.GetUserId(HttpContext.User));
                return RedirectToAction(nameof(AllCreated));
            }

            return View("ExeptionView");
        }

        // GET: SysTransactions/Edit/5
        [Authorize(Roles = "Admin,Cashier,ControllerExtended")]
        public ActionResult Edit(int id)
        {
            return View(transactionService.SingleIncludeAgents(id));
        }

        // POST: SysTransactions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Cashier,ControllerExtended")]
        public ActionResult Edit(SysTransactionDTO item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    transactionService.Update(item);
                    return RedirectToAction(nameof(AllCreated));
                }

                return View("ExeptionView");//TODO заменить каким-то статусом
            }
            catch(Exception ex)
            {
                return View(ex);
            }
        }

        // GET: SysTransactions/Delete/5
        [Authorize(Roles = "Admin,SuperAdmin")]
        public ActionResult Delete(int id)
        {
            return View(transactionService.Get(id));
        }

        // POST: SysTransactions/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public ActionResult DeleteItem(int id)
        {
            transactionService.Delete(id);
            return RedirectToAction(nameof(Index));
        }



        //++++++++++++++++++++++++++++++++++++++++++++      Транзакции и статусы       +++++++++++++++++++++++++++++++++++++++++++++++
        [Authorize(Roles = "Admin,Cashier,ControllerExtended")]
        public IActionResult AllCreated()
        {
            //return View(transactionService.Find(t => t.TransactionStatus == (int)TransactionStatus.Created)); //Можно переадресовать
            return RedirectToAction("AllByStatus", "SysTransactions", new { status = "Created"});
        }

        [Authorize(Roles = "Admin,Agent,Cashier,Controller,ControllerExtended")]
        public IActionResult AllByStatus(string status, int page = 1)
        {
            switch (status)
            {
                case "Created":
                    
                    return View(transactionService.AllByStatusAndUserId(_userManager.GetUserId(HttpContext.User), status, page));

                case "ToPay":
                    return View(transactionService.AllByStatusAndUserId(_userManager.GetUserId(HttpContext.User), status, page));

                case "Approved":
                    return View(transactionService.AllByStatusAndUserId(_userManager.GetUserId(HttpContext.User), status, page));

                case "Confirmed":
                    ViewBag.status = status;
                    return View(transactionService.AllByStatusAndUserId(_userManager.GetUserId(HttpContext.User), status, page));

                case "ToPayOff":
                    ViewBag.status = status;
                    return View(transactionService.AllTransactionsCantCanceled(_userManager.GetUserId(HttpContext.User), status, page));

                case "Issued":
                    ViewBag.status = status;
                    return View(transactionService.AllTransactionsCantCanceled(_userManager.GetUserId(HttpContext.User), status, page));

                case "Canceled":
                    ViewBag.status = status;
                    return View(transactionService.AllByStatusAndUserId(_userManager.GetUserId(HttpContext.User), status, page));
            }

            return View();
        }

        [Authorize(Roles = "Admin,Cashier,ControllerExtended")]
        public IActionResult AllToPayOff(int page = 1)
        {
            return View(transactionService.AllTransactionsToPayOff(_userManager.GetUserId(HttpContext.User), page));
        }

        [Authorize(Roles = "Admin,Cashier,ControllerExtended")]
        public IActionResult AllCanceled(int page = 1)
        {
            return View(transactionService.AllTransactionsCanceled(_userManager.GetUserId(HttpContext.User), page));
        }

        /*
         * В данном окне контроллер агента видит все переводы, не подтвержденные по его пункту (точке продаж) и осуществляет подтверждение
         */
        [Authorize(Roles = "Admin,Agent,Cashier,Controller,ControllerExtended")]
        public IActionResult AllByThisAgent(int page = 1)
        {
            return View(transactionService.AllForControllerAsSubAgent(_userManager.GetUserId(HttpContext.User), page)); //здесь верстка может слетать
        }

        /*
         * Система предоставляет отдельный доступ, который позволяет сотруднику видеть все переводы в рамках своего агента
         */
        [Authorize(Roles = "Admin,Agent,ControllerExtended")]
        public IActionResult AllByThisSubAgentIncludParentAgent(int page = 1)
        {
            return View(transactionService.AllForControllerAsAgent(_userManager.GetUserId(HttpContext.User), page));    //здесь верстка может слетать
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ControllerExtended,Cashier")]
        public ActionResult ToPay(int id, int idAgent)
        {
            try
            {
                if (transactionService.StatusToPayAndApproved(id, "ToPay")) 
                {
                    return RedirectToAction("Details", new { id = id, idAgent = idAgent });
                }

                return View("ExeptionView");
            }
            catch
            {
                return View("ExeptionView");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ControllerExtended,Cashier")]
        public ActionResult Approved(int id, int idAgent)
        {
            try
            {
                if (transactionService.StatusToPayAndApproved(id, "Approved"))
                {
                    return RedirectToAction("Details", new { id = id, idAgent = idAgent });
                }

                return View("ExeptionView");
            }
            catch
            {
                return View("ExeptionView");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Controller,ControllerExtended")]
        public ActionResult Confirmed(int id, int idAgent)
        {
            try
            {
                if (transactionService.StatusConfirmed(id, _userManager.GetUserId(HttpContext.User)))
                {
                    return RedirectToAction("Details", new { id = id, idAgent = idAgent });
                }

                return View("ExeptionView");
            }
            catch(Exception ex)
            {
                return View("ExeptionView");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ControllerExtended,Cashier")]
        public ActionResult ToPayOff(int id, int idAgent)
        {
            try
            {
                if (transactionService.StatusToPayOff(id, _userManager.GetUserId(HttpContext.User)))
                {
                    return RedirectToAction("Details", new { id = id, idAgent = idAgent });
                }

                return View("ExeptionView");
            }
            catch
            {
                return View("ExeptionView");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ControllerExtended,Cashier")]
        public ActionResult ToIssued(int id, int idAgent)
        {
            try
            {
                if (transactionService.StatusToIssued(id))
                {
                    return RedirectToAction("Details", new { id = id, idAgent = idAgent });
                }

                return View("ExeptionView");
            }
            catch
            {
               return View("ExeptionView");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Cashier,Controller,ControllerExtended")]
        public ActionResult ToCanceled(int id, int idAgent)
        {
            try
            {
                if (transactionService.StatusToCanceled(id))
                {
                    return RedirectToAction("Details", new { id = id, idAgent = idAgent });
                }

                return View(); //
            }
            catch(Exception ex)
            {
                return View("ExeptionView"); 
            }
        }

        //++++++++++++++++++++++++++++++++++++++++++++++      Sort       ++++++++++++++++++++++++++++++++++++++++++++++++++
        [Authorize(Roles = "Admin,Agent,Cashier,Controller,ControllerExtended")]
        public IActionResult Sort(
            string country,
            string agentTo,
            string agentFrom,       
            DateTime timeFrom,
            DateTime timeTo,
            string tcn,
            string fio,
            int page = 1,
            SortState sortOrder = SortState.NameAsc)
        {

            ViewBag.NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewBag.PriceSort = sortOrder == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;
            ViewBag.CompSort = sortOrder == SortState.CompAsc ? SortState.CompDesc : SortState.CompAsc;
            
            return View(transactionService.Sort(tcn, country, agentTo, agentFrom, timeFrom, timeTo, fio, page, _userManager.GetUserId(HttpContext.User), sortOrder));

        }

        [Authorize(Roles = "Admin,Cashier,ControllerExtended")]
        public IActionResult Copy(int id, int clientFromId, int clientToId)
        {
            ViewBag.countries = new SelectList(countryService.GetAll(), "Id", "Name");
            ViewBag.currencies = new SelectList(_currencyService.GetAll(), "Id", "Name");
            ViewBag.clientFromId = clientFromId;
            return View(transactionService.Copy(id, _userManager.GetUserId(HttpContext.User), clientToId, clientFromId));
        }
    }
}