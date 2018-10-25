using System;
using Edelweiss.BLL.DTO;
using Edelweiss.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project_Edelweiss.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CurrencyController : Controller
    {
        private ICurrencyService _service;

        public CurrencyController(ICurrencyService service)
        {
            _service = service;
        }
        // GET: Currency
        public ActionResult Index(int page = 1)
        {
            return View(_service.GetAll(page));
        }

        // GET: Currency/Details/5
        public ActionResult Details(int id)
        {
            return View(_service.Get(id));
        }

        // GET: Currency/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Currency/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CurrencyDTO model)
        {
            try
            {
                _service.Create(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Введены неправильные данные");
                return View(model);
            }
        }

        // GET: Currency/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_service.Get(id));
        }

        // POST: Currency/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CurrencyDTO model)
        {
            try
            {
                _service.Update(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Введены неправильные данные");
                return View(model);
            }
        }

        // GET: Currency/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_service.Get(id));
        }

        // POST: Currency/Delete/5
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