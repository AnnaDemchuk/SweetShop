using Shop.BLL.Models;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Step.WebUI.Controllers
{
    public class ManufacturerController : Controller
    {
        IGenericService<ManufacturerDTO> manufacturerService;

        public ManufacturerController(IGenericService<ManufacturerDTO> manufacturerService)
        {
            this.manufacturerService = manufacturerService;
        }

        public ActionResult Index()
        {
            var model = manufacturerService.GetAll();
            return View(model);
        }

        public ActionResult Edit(int id = 0)
        {
            var model = (id == 0) ? new ManufacturerDTO() : manufacturerService.Get(id);
      
            ViewBag.ManufacturerId = new SelectList(manufacturerService.GetAll(),
                              "ManufacturerId", "ManufacturerName", model.ManufacturerId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ManufacturerDTO manufacturer)
        {
            if (ModelState.IsValid)
            {
                manufacturerService.AddOrUpdate(manufacturer);
                return RedirectToAction("Index");
            }
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                ManufacturerDTO manufacturer = manufacturerService.Get(id);
                manufacturerService.Delete(manufacturer);
                return Json("OK");
            }
            catch
            {
                return Json("Error");
            }
        }


    }
}