using System;
using System.Collections.Generic;
using System.Linq;
using Edelweiss.BLL.DTO;
using Edelweiss.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project_Edelweiss.Controllers
{
    public class TariffController : Controller
    {
        private ITariffService _tariffService;
        private ICountryService _countryService;
        private ICurrencyService _currencyService;
        private IAgentService _agentService;
        private IRangeService _rangeService;

        public TariffController(ITariffService tariffService, 
            ICountryService countryService,
            ICurrencyService currencyService,
            IAgentService agentService,
            IRangeService rangeService)
        {
            _tariffService = tariffService;
            _countryService = countryService;
            _currencyService = currencyService;
            _agentService = agentService;
            _rangeService = rangeService;
        }
        // GET: Tariff
        [Authorize(Roles = "Admin, Agent, Cashier, Controller,ControllerExtended")]
        public ActionResult Index(int page = 1)
        {
            return View(_tariffService.GetAll(page));
        }

        // GET: Tariff/Details/5
        [Authorize(Roles = "Admin, Agent, Cashier, Controller,ControllerExtended")]
        public ActionResult Details(int id)
        {
            return View(_tariffService.Get(id));
        }

        // GET: Tariff/Copy
        [Authorize(Roles = "Admin")]
        public ActionResult Copy(int id)
        {
            ViewBag.agents = new SelectList(_agentService.GetAll(), "Id", "Name");
            ViewBag.currencies = new SelectList(_currencyService.GetAll(), "Id", "Name");
            ViewBag.countries = new SelectList(_countryService.GetAll(), "Id", "Name");
            ViewBag.rangesMin = new SelectList(_rangeService.GetAll(), "Id", "MinValue");
            ViewBag.rangesMax = new SelectList(_rangeService.GetAll(), "Id", "MaxValue");


            return View(_tariffService.Get(id));
        }

        // GET: Tariff/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.agents = new SelectList(_agentService.GetAll(), "Id", "Name");
            ViewBag.currencies = new SelectList(_currencyService.GetAll(), "Id", "Name");
            ViewBag.countries = new SelectList(_countryService.GetAll(), "Id", "Name");
            ViewBag.rangesMin = new SelectList(_rangeService.GetAll(), "Id", "MinValue");
            ViewBag.rangesMax = new SelectList(_rangeService.GetAll(), "Id", "MaxValue");


            return View();
        }

        // POST: Tariff/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TariffDTO model)
        {
            try
            {
                _tariffService.Create(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Введены неправильные данные");
                return View(model);
            }
        }

        // GET: Tariff/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            ViewBag.agents = new SelectList(_agentService.GetAll(), "Id", "Name");
            ViewBag.currencies = new SelectList(_currencyService.GetAll(), "Id", "Name");
            ViewBag.countries = new SelectList(_countryService.GetAll(), "Id", "Name");
            ViewBag.rangesMin = new SelectList(_rangeService.GetAll(), "Id", "MinValue");
            ViewBag.rangesMax = new SelectList(_rangeService.GetAll(), "Id", "MaxValue");
            return View(_tariffService.Get(id));
        }

        // POST: Tariff/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TariffDTO model)
        {
            try
            {
                _tariffService.Update(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Введены неправильные данные");
                return View(model);
            }
        }

        // GET: Tariff/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View(_tariffService.Get(id));
        }

        // POST: Tariff/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteItem(int id)
        {
            try
            {
                _tariffService.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.ToString());
                return View();
            }
        }
    }
}