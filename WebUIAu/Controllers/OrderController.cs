using Shop.BLL.Models;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUIAu.Models;

namespace Step.WebUI.Controllers
{
    public class OrderController : Controller
    {
        IGenericService<OrderDTO> orderService;
        IGenericService<OrderPositionDTO> orderPositionService;//
        IGenericService<DeliveryDTO> deliveryService;///
        IGenericService<StatusOrderDTO> statusOrderService;///

        public OrderController(IGenericService<OrderDTO> orderService,
            IGenericService<OrderPositionDTO> orderPositionService,
            IGenericService<DeliveryDTO> deliveryService,//
            IGenericService<StatusOrderDTO> statusOrderService)//
        {
            this.orderService = orderService;
            this.orderPositionService = orderPositionService;
            this.deliveryService = deliveryService;//
            this.statusOrderService = statusOrderService;//
        }


        public ActionResult IndexHtmlAction()
        {
            return View();
        }

        public ActionResult IndexListing()
        {
            var model = orderService.GetAll();
            return PartialView("IndexListing", model);
        }

        //кабинет пользователя
        //public ActionResult FindMyOrderEmail(string myEmail)
        //{
        //    var model = orderService.GetAll().Where(e => e.UserEmail == myEmail);
        //    return View(model);
        //}
        //кабинет пользователя
        public ActionResult FindMyOrder(string myId)
        {
            var model = orderService.GetAll().Where(e => e.UserId == myId);
            return View(model);
        }

        //


        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id = 0)
        {
            var model = (id == 0) ? new OrderDTO() : orderService.Get(id);
            ViewBag.DeliveryId = new SelectList(GetNullDeliveryName().Union(deliveryService.GetAll()), "DeliveryId", "DeliveryName", model.DeliveryId);
            ViewBag.StatusId = new SelectList(GetNullStatusName().Union(statusOrderService.GetAll()), "StatusId", "StatusName", model.StatusId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(OrderDTO order)
        {
            if (ModelState.IsValid)
            {
                orderService.AddOrUpdate(order);
                return RedirectToAction("IndexHtmlAction");
            }
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                OrderDTO order = orderService.Get(id);
                orderService.Delete(order);
                return Json("OK");
            }
            catch
            {
                return Json("Error");
            }
        }

        IEnumerable<DeliveryDTO> GetNullDeliveryName() //
        {
            yield return new DeliveryDTO() { DeliveryName = "Input Delivery" };
        }

        IEnumerable<StatusOrderDTO> GetNullStatusName() //
        {
            yield return new StatusOrderDTO() { StatusName = "Input StatusOrder" };
        }

        //на header
        public ActionResult AboutOrder()
        {
            return View();
        }
    }
}