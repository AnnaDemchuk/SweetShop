using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Shop.BLL.Models;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebUIAu.Helpers;
using WebUIAu.Models;

namespace WebUIAu.Controllers
{
    public class CartTestController : Controller
    {
        IGenericService<OrderDTO> orderService;
        IGenericService<OrderPositionDTO> orderPositionService;

        //для idUser
        //private ApplicationSignInManager _signInManager;
        //private ApplicationUserManager _userManager;

        //public ApplicationSignInManager SignInManager
        //{
        //    get
        //    {
        //        return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
        //    }
        //    private set
        //    {
        //        _signInManager = value;
        //    }
        //}
        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}
        //


        public CartTestController(IGenericService<OrderDTO> orderService,
            IGenericService<OrderPositionDTO> orderPositionService)
        {
            this.orderService = orderService;
            this.orderPositionService = orderPositionService;

        }

        // GET: CartTest
        public ActionResult Edit()
        {
            CustomerInfo model = new CustomerInfo();
            ViewBag.DeliveryInfo = new SelectList(EnumEditorHtmlHelper.createSelectList(typeof(Delivery)), "Value", "Text");
            //new SelectList(GetNullProductName().Union(productService.GetAll()), "ProductId", "GoodName", productPrice.ProductId);

            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(CustomerInfo info)
        {
            Cart cart = GetCartMy();
            OrderDTO tmp;

            if (User.Identity.GetUserId()!=null)
            {
                tmp = new OrderDTO()
                {
                    UserId = User.Identity.GetUserId(),
                    //UserId = "Anonim",
                    DateCreateOrder = DateTime.Now,
                    DateCreateGood = DateTime.Now.AddDays(3),//за 3 дня заказ
                    DeliveryId = 1,
                    StatusId = 1,
                    UserName = info.Name,
                    UserPhone = info.Phone,
                    UserEmail = info.Email,
                    Total = 0 //
                };
            }
            else
            {
                tmp = new OrderDTO()
                {
                   // UserId = User.Identity.GetUserId(),
                    UserId = "Anonim",
                    DateCreateOrder = DateTime.Now,
                    DateCreateGood = DateTime.Now.AddDays(3),//за 3 дня заказ
                    DeliveryId = 1,
                    StatusId = 1,
                    UserName = info.Name,
                    UserPhone = info.Phone,
                    UserEmail = info.Email,
                    Total = 0 //
                };
            }
          
            OrderDTO order = orderService.AddOrUpdate(tmp);

            int _total = 0;
            string _order = "";
            foreach (var el in cart.Lines)
            {
                OrderPositionDTO orderPos = new OrderPositionDTO()
                {
                    OrderId = order.OrderId,
                    ProductId = el.ProductPricecart.ProductId,
                    OrderCount = el.Quantity,
                    OrderPosPrice = el.ProductPricecart.Price,//
                    OrderPosAmount = (el.Quantity) *(int)(el.ProductPricecart.Price),//
                };
                orderPositionService.AddOrUpdate(orderPos);
                _total += orderPos.OrderPosAmount;
                _order += el.ProductPricecart.GoodName + " - " + el.Quantity 
                    + " шт " + " по "+(int)el.ProductPricecart.Price 
                    + " грн "+ " - " + orderPos.OrderPosAmount + "грн <br>";
            }
            order.Total = _total;//
            OrderDTO ordernew= orderService.AddOrUpdate(order);



            string _customer = "<h3> Добрый день, " + info.Name + "! </h3>"
                + " Заказ № " + ordernew.OrderId + " от " + ordernew.DateCreateOrder + " отправлен на обработку. <br>"
                + _order  
               +" Итого " + _total+ " грн. <br>"
               + " В ближайшее время вам перезвонит менеджер для уточнения деталей. <br>"
               + "_________________________________________________________________ <br>"
               + " Интернет магазин <a href=\"http://anysite.ru\"> BigCake.somee.com </a>,<br>" +
               "  BigCake.somee@gmail.com,<br>" +
               " т.066-200-00-00";

            string _manager = "<h3> Добрый день ! </h3> "
                + "Покупатель ожидает звонка. <br>"
                + "Имя: " + info.Name + "<br>"
                + "почта: " + info.Email + "<br>"
                + "телефон: " + info.Phone + "<br>"
                + "Заказ № " + ordernew.OrderId + " от " + ordernew.DateCreateOrder + " отправлен на обработку. <br>"
                + _order
               + " Итого " + _total + " грн. <br>";

            string _manageremail="mailinator3000@mailinator.com";

            SendLetterAfterOrder(ordernew.UserEmail, _customer);
            SendLetterAfterOrder(_manageremail, _manager);

            cart.Clear();//очистить
            return RedirectToAction("Index", "Category");
        }

        public Cart GetCartMy()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        //потому что не асинхронный)

        public void SendLetterAfterOrder(string emailTo, string letter)
        {

            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("letterbox1303@gmail.com", "BigCake");
            // кому отправляем
            //  MailAddress to = new MailAddress("letterbox1303@mailinator.com");

            //  MailAddress to = new MailAddress("emailTo");
            MailAddress to = new MailAddress(emailTo);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Заказ в магазине BigCake принят";
           
            // текст письма
            m.Body = letter;
            //m.Body = "<h2>Спасибо за обращение. " +
            //    "В ближайшее время вам перезвонит менеджер для уточнения деталей </h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("letterbox1303@gmail.com", "SanDiego");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}