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
    public class CommissionController : Controller
    {
        private ICommissionsDividingService _service;            

        public CommissionController(ICommissionsDividingService service)
        {
            _service = service;
        }
        // GET: Commission
        public ActionResult Index(int page = 1)
        {
            return View(_service.GetAll(page));
        }

        // GET: Commission/Details/5
        public ActionResult Details(int id)
        {
            return View(_service.Get(id));
        }

        // GET: Commission/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Commission/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommissionsDividingDTO item)
        {
            try
            {
                _service.Create(item);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Запись разделения комиссий уже существует. Измените существующую");
                return View(item);
            }
        }

        // GET: Commission/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_service.Get(id));
        }

        // POST: Commission/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CommissionsDividingDTO item)
        {
            try
            {
                _service.Update(item);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Введены неправильные данные");
                return View(item);
            }
        }

        // GET: Commission/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_service.Get(id));
        }

        // POST: Commission/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteItem(int id)
        {
            try
            {
                _service.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.ToString());
                return View();
            }
        }
    }
}