using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUIAu.Dashboard
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}