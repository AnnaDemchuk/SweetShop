using Shop.BLL.Models;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.IO;
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

        public ActionResult IndexHtmlAction()
        {
            return View();
        }

        public ActionResult IndexListing()
        {
            var model = manufacturerService.GetAll();
            return PartialView("IndexListing", model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id = 0)
        {
            var model = (id == 0) ? new ManufacturerDTO() : manufacturerService.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ManufacturerDTO manufacturer)
        {
            if (ModelState.IsValid)
            {
                manufacturerService.AddOrUpdate(manufacturer);
                return RedirectToAction("IndexHtmlAction");
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

        [HttpPost]
        public ActionResult UploadPhoto(HttpPostedFileBase fileUpload)
        {
            string Id = Request.Params["id"];

            if (fileUpload != null)
            {
                ManufacturerDTO manufacturer = manufacturerService.Get(Convert.ToInt32(Id));
                manufacturer.ManufacturerPhotoPath = "/Images/" + fileUpload.FileName;
                manufacturerService.AddOrUpdate(manufacturer);
            }
            string path = Path.Combine(Server.MapPath("~/Images/"), fileUpload.FileName);
            fileUpload.SaveAs(path);
            return RedirectToAction("Edit", "Manufacturer", new { id = Convert.ToInt32(Id) });
        }
    }
}