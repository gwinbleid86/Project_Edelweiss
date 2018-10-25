using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Edelweiss.BLL.DTO;
using Edelweiss.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project_Edelweiss.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CellPhoneMaskController : Controller
    {
        ICellPhoneMaskService cellPhoneMaskService;
        ICountryService _countryService;

        public CellPhoneMaskController(ICellPhoneMaskService cellPhoneMaskService, ICountryService countryService)
        {
            this.cellPhoneMaskService = cellPhoneMaskService;
            _countryService = countryService;
        }

        // GET: CellPhoneMask
        public ActionResult Index(int page = 1)
        {
            return View(cellPhoneMaskService.GetAll(page));
        }

        // GET: CellPhoneMask/Details/5
        public ActionResult Details(int id)
        {
            var cellMask = cellPhoneMaskService.Get(id);
            return View(cellMask);
        }

        // GET: CellPhoneMask/Create
        public ActionResult Create()
        {
            ViewBag.countries = new SelectList(_countryService.SortByPopularity(), "Id", "Name");
            return View();
        }

        // POST: CellPhoneMask/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CellPhoneMaskDTO cellPhoneMask)
        {
            if (ModelState.IsValid)
            {
                cellPhoneMaskService.Create(cellPhoneMask);
                return RedirectToAction(nameof(Index));
            }

            return View("ExeptionView", "SysTransactions");
        }

        // GET: CellPhoneMask/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.countries = new SelectList(_countryService.SortByPopularity(), "Id", "Name");
            return View(Mapper.Map<CellPhoneMaskDTO>(cellPhoneMaskService.Get(id)));
        }

        // POST: CellPhoneMask/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CellPhoneMaskDTO cellPhoneMask)
        {
            if (!ModelState.IsValid)
            {
                return View("ExeptionView", "SysTransactions");
            }
            cellPhoneMaskService.Update(cellPhoneMask);
            return RedirectToAction(nameof(Index));
        }

        // GET: CellPhoneMask/Delete/5
        public ActionResult Delete(int id)
        {
            return View(cellPhoneMaskService.Get(id));
        }

        // POST: CellPhoneMask/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCellPhoneMask(int id)
        {
            if (!ModelState.IsValid)
            {
                return View("ExeptionView", "SysTransactions");
            }
            cellPhoneMaskService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}