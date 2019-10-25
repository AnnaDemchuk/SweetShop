using Shop.BLL.Models;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Step.WebUI.Controllers
{
    public class DeliveryController : Controller
    {
        IGenericService<DeliveryDTO> deliveryService;

        public DeliveryController(IGenericService<DeliveryDTO> deliveryService)
        {
            this.deliveryService = deliveryService;
        }

        public ActionResult IndexHtmlAction()
        {
            return View();
        }

        public ActionResult IndexListing()
        {
            var model = deliveryService.GetAll();
            return PartialView("IndexListing", model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id = 0)
        {
            var model = (id == 0) ? new DeliveryDTO() : deliveryService.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(DeliveryDTO delivery)
        {
            if (ModelState.IsValid)
            {
                deliveryService.AddOrUpdate(delivery);
                return RedirectToAction("IndexHtmlAction");
            }
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                DeliveryDTO delivery = deliveryService.Get(id);
                deliveryService.Delete(delivery);
                return Json("OK");
            }
            catch
            {
                return Json("Error");
            }
        }
    }
}