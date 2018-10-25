using System;
using Edelweiss.BLL.DTO;
using Edelweiss.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project_Edelweiss.Controllers
{
    public class AgentController : Controller
    {
        IAgentService agentService;
        ICountryService _countryService;
        public AgentController(IAgentService agentService, ICountryService countryService)
        {
            this.agentService = agentService;
            _countryService = countryService;
        }


        // GET: Agent
        [Authorize(Roles = "Admin")]
        public ActionResult Index(int page = 1)
        {
            return View(agentService.GetAll(page));
        }

        // GET: Agent/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                ModelState.AddModelError(string.Empty, "Агент не найден");
                return RedirectToAction("SearchAgentForBlock", "Account");
            }
            ViewBag.Promo = agentService.GetAgent(id).ImagePromo;
            ViewBag.Logo = agentService.GetAgent(id).ImageLogo;

            return View(agentService.Get(id));
        }

        [Authorize(Roles = "Admin,Agent,Cashier,Controller,ControllerExtended")]
        public ActionResult General(int id)
        {
            ViewBag.Promo = agentService.GetAgent(id).ImagePromo;
            ViewBag.Logo = agentService.GetAgent(id).ImageLogo;

            return View(agentService.Get(id));
        }

        // GET: Agent/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewBag.agents = new SelectList(agentService.GetAll(), "Id", "Name");
            ViewBag.countries = new SelectList(_countryService.SortByPopularity(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(AgentDTO agentDTO)
        {
            agentService.Create(agentDTO);
            return RedirectToAction(nameof(Index));
        }


        // GET: Agent/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            ViewBag.agents = new SelectList(agentService.GetAll(), "Id", "Name");
            ViewBag.countries = new SelectList(_countryService.SortByPopularity(), "Id", "Name");
            return View(agentService.Get(id));
        }

        // POST: Agent/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(AgentDTO model)
        {
            agentService.Update(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: Agent/Delete/5
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            return View((agentService.Get(id)));
        }

        

        // POST: Agent/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteItem(int id)
        {
            agentService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}