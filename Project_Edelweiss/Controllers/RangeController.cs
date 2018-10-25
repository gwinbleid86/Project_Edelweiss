using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edelweiss.BLL.DTO;
using Edelweiss.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project_Edelweiss.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RangeController : Controller
    {
        private IRangeService _service;
        public RangeController(IRangeService service)
        {
            _service = service;
        }
        // GET: Range
        public ActionResult Index(int page = 1)
        {
            return View(_service.GetAll(page));
        }

        // GET: Range/Details/5
        public ActionResult Details(int id)
        {
            return View(_service.Get(id));
        }

        // GET: Range/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Range/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RangeDTO range)
        {
            try
            {
                _service.Create(range);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Введены неправильные данные");
                return View(range);
            }
        }

        // GET: Range/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_service.Get(id));
        }

        // POST: Range/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RangeDTO range)
        {
            try
            {
                _service.Update(range);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Введены неправильные данные");
                return View(range);
            }
        }

        // GET: Range/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_service.Get(id));
        }

        // POST: Range/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteItem(int id)
        {
            try
            {
                _service.Delete(id);

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