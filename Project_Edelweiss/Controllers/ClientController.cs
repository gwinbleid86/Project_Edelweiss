using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Edelweiss.BLL.DTO;
using Edelweiss.BLL.Interfaces;
using Edelweiss.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Project_Edelweiss.Controllers
{
    public class ClientController : Controller 
    {
        IClientService clientService;
        private readonly ILogger _logger;
        private UserManager<User> _userManager;

        public ClientController(IClientService clientService,
            ILogger<SysTransactionsController> logger,
            UserManager<User> userManager)
        {
            this.clientService = clientService;
            _logger = logger;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin,Agent,Cashier,Controller,ControllerExtended")]
        public IActionResult Index()
        {
            //IEnumerable<ClientDTO> clientDtos = ;
            //var clients = Mapper.Map<IEnumerable<ClientDTO>, List<ClientViewModel>>(clientDtos);
            return RedirectToAction("Search");
            
        }
        [Authorize(Roles = "Admin,Agent,Cashier,Controller,ControllerExtended")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Agent,Cashier,Controller,ControllerExtended")]
        public IActionResult Create(ClientDTO clientDTO)
        {

            if (ModelState.IsValid)
            {
                clientService.Create(clientDTO);
                return RedirectToAction("Details", new {id = clientService.SingleOrDefault(c => c.PassportData == clientDTO.PassportData).Id });
            }
            return View("ExeptionView", "SysTransactions");
        }

        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Delete(int id)
        {
            return View(clientService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult DeleteClient(int id)
        {
            clientService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // GET:
        [Authorize(Roles = "Admin,Agent,Cashier,ControllerExtended")]
        public IActionResult Edit(int id)
        {
            return View(Mapper.Map<ClientDTO>(clientService.Get(id)));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Agent,Cashier,ControllerExtended")]
        public IActionResult Edit(ClientDTO client)
        {
            if (!ModelState.IsValid)
            {
                return View("ExeptionView", "SysTransactions");
            }
            clientService.Update(client);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin,Agent,Cashier,Controller,ControllerExtended")]
        public IActionResult Details(int id)
        {
            var client = clientService.Get(id);
            return View(client);
        }

        [Authorize(Roles = "Admin,Agent,Cashier,Controller,ControllerExtended")]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Agent,Cashier,Controller,ControllerExtended")]
        public IActionResult Search(string passport)
        {
            
            var client = clientService.SingleOrDefault(c => c.PassportData == passport);


            if (client != null)
            {
                _logger.LogError("Поиск по паспорту: {1} делал пользователь: {2} ", passport, _userManager.GetUserName(HttpContext.User));
                return RedirectToAction("Details", "Client", client);
            }

            _logger.LogError("Поиск по паспорту: {1} делал пользователь: {2} ", passport, _userManager.GetUserName(HttpContext.User));
            return RedirectToAction(nameof(Create));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Agent,Cashier,Controller,ControllerExtended")]
        public IActionResult SearchByLastName(string lastName, int page = 1)
        {
            return View(clientService.GetAllByLastName(lastName, page));
        }

    }
}