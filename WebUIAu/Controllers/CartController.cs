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
        IGenericService<GoodDTO> goodService;



        public CartController (IGenericService<GoodDTO> goodServ)
        {
            goodService = goodServ;
        }

        public RedirectToRouteResult AddToCart(int goodId, string returnUrl)
        {
            GoodDTO goodDTO = goodService.Get(goodId);
            if (goodDTO != null)
            {
                GetCart().AddItem(goodDTO, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int goodId, string returnUrl)
        {
            GoodDTO goodDTO = goodService.Get(goodId);

            if (goodDTO != null)
            {
                GetCart().RemoveLine(goodDTO);
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

    }
}