using Shop.BLL.Models;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList; //


namespace WebUIAu.Controllers
{
    public class UnitController : Controller
    {
        IGenericService<UnitDTO> unitService;

        public UnitController(IGenericService<UnitDTO> unitService)
        {
            this.unitService = unitService;
        }

       
        public ActionResult IndexHtmlAction()
        {
            return View();
        }

        public ActionResult IndexListing(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var model = unitService.GetAll();
            return PartialView("IndexListing", model.ToPagedList(pageNumber, pageSize));
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id = 0)
        {
            var model = (id == 0) ? new UnitDTO() : unitService.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UnitDTO unit)
        {
            if (ModelState.IsValid)
            {
                unitService.AddOrUpdate(unit);
                return RedirectToAction("IndexHtmlAction");
            }
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                UnitDTO unit = unitService.Get(id);
                unitService.Delete(unit);
                return Json("OK");
            }
            catch
            {
                return Json("Error");
            }
        }
    }
}