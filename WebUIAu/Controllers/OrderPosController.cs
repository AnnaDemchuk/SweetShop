using Shop.BLL.Models;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Step.WebUI.Controllers
{
    public class OrderPosController : Controller
    {
        IGenericService<OrderPositionDTO> orderPositionService;
        IGenericService<ProductDTO> productService;

        public OrderPosController(IGenericService<OrderPositionDTO> orderPositionService, 
            IGenericService<ProductDTO> productService)
        {
            this.orderPositionService = orderPositionService;
            this.productService = productService;
        }

        public ActionResult IndexHtmlAction()
        {
            return View();
        }

    //админ панель
        public ActionResult Positions(int? id)
        {
            var model = orderPositionService.GetAll().Where(e => e.OrderId == id);
            return PartialView("Positions", model);
        }

        //панель пользователя
      
        public ActionResult FindMyOrderDetails(int id)
        {
            var model = orderPositionService.GetAll().Where(e => e.OrderId == id);
            return View(model);
        }

        public ActionResult Index()
        {
            var model = orderPositionService.GetAll();
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id = 0)
        {
            var model = (id == 0) ? new OrderPositionDTO() : orderPositionService.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(OrderPositionDTO orderPos)
        {
            if (ModelState.IsValid)
            {
                orderPositionService.AddOrUpdate(orderPos);
                return RedirectToAction("IndexHtmlAction");
            }
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                OrderPositionDTO orderPosition = orderPositionService.Get(id);
                orderPositionService.Delete(orderPosition);
                return Json("OK");
            }
            catch
            {
                return Json("Error");
            }
        }

      

    }
}