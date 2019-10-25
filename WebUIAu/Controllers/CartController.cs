using Shop.BLL.Models;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUIAu.Models;

namespace WebUIAu.Controllers
{
    public class CartController : Controller
    {
        IGenericService<ProductPriceDTO> productPriceService;
        IGenericService<OrderDTO> orderService;
        IGenericService<OrderPositionDTO> orderPosService;
      //  private ApplicationUserManager _userManager;
        CustomerInfo customerInfo;//

        public CartController (IGenericService<ProductPriceDTO> prodPriceServ, 
            IGenericService<OrderDTO> _orderService, IGenericService<OrderPositionDTO> _orderPosService)
        {
            productPriceService = prodPriceServ;
            orderService = _orderService;
            orderPosService = _orderPosService;
        }


        [HttpPost]
        public ActionResult AddToCart(int id)
        {
            ProductPriceDTO productPriceDTO = productPriceService.Get(id);
            if (productPriceDTO != null)
            {
                GetCart().AddItem(productPriceDTO, 1);
            }
            //  return RedirectToAction("Index", new { returnUrl });
            return Json("OK");
        }
        public RedirectToRouteResult RemoveFromCart(int productPriceId, string returnUrl)
        {
            ProductPriceDTO productPriceDTO = productPriceService.Get(productPriceId);

            if (productPriceDTO != null)
            {
                GetCart().RemoveLine(productPriceDTO);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                CartIndex = GetCart(),
                ReturnUrl = returnUrl
            });
        }


        [HttpPost]
        public ActionResult NewQuantity(int id, int quantity)
        {
            try
            {
                GetCart().ChangeQuantity(id, quantity);
                return Json("OK");
            }
            catch
            {
                return Json("Error");
            }
        }

        //[ChildActionOnly]
        public ActionResult CartCount()
        {
            var cart = GetCart(); //взять карт
            ViewData["CartCount"] = cart.GetCount();//количество товаров
            return PartialView("CartCount");
        }
    }
}