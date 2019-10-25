using Shop.BLL.Models;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUIAu.Controllers
{
    public class StatusOrderController : Controller
    {
        IGenericService<StatusOrderDTO> statusOrderService;

        public StatusOrderController(IGenericService<StatusOrderDTO> statusOrderService)
        {
            this.statusOrderService = statusOrderService;
        }


        public ActionResult IndexHtmlAction()
        {
            return View();
        }

        public ActionResult IndexListing()
        {
            var model = statusOrderService.GetAll();
            return PartialView("IndexListing", model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id = 0)
        {
            var model = (id == 0) ? new StatusOrderDTO() : statusOrderService.Get(id);

            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(StatusOrderDTO statusOrder)
        {
            if (ModelState.IsValid)
            {
                statusOrderService.AddOrUpdate(statusOrder);
                return RedirectToAction("IndexHtmlAction");
            }
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                StatusOrderDTO statusOrder = statusOrderService.Get(id);
                statusOrderService.Delete(statusOrder);
                return Json("OK");
            }
            catch
            {
                return Json("Error");
            }
        }


    }
}