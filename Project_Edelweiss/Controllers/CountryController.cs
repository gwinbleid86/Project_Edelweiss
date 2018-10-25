using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Edelweiss.BLL.DTO;
using Edelweiss.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project_Edelweiss.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CountryController : Controller
    {
        ICountryService countryService;

        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        public IActionResult Index()
        {
            return View(countryService.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CountryDTO country)
        {
            if (ModelState.IsValid)
            {
                countryService.Create(country);
                return RedirectToAction(nameof(Index));
            }
            return View("ExeptionView", "SysTransactions");
        }

        public IActionResult Edit(int id)
        {
            return View(Mapper.Map<CountryDTO>(countryService.Get(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CountryDTO country)
        {
            if (ModelState.IsValid)
            {
                countryService.Update(country);
                return RedirectToAction(nameof(Index));
            }
            return View("ExeptionView", "SysTransactions");
        }


        public IActionResult Details(int id)
        {
            var country = countryService.Get(id);
            return View(country);
        }

        public IActionResult Delete(int id)
        {
            return View(countryService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCountry(int id)
        {
            countryService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}