using Shop.BLL.Models;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUIAu.Controllers
{
    public class PhotoController : Controller
    {
        IGenericService<PhotoDTO> photoService;

        public PhotoController(IGenericService<PhotoDTO> photoService)
        {
            this.photoService = photoService;
        }
        public ActionResult ShowPhoto(int id)
        {
            var photo = photoService.FindBy(p => p.GoodId == id);
            ViewBag.GoodId = id;
            return View(photo);
        }

        public ActionResult UploadPhoto(int id)
        {
            ViewBag.GoodId = id;
            return View();
        }

        [HttpPost]
        public ActionResult UploadPhoto(IEnumerable<HttpPostedFileBase> fileUpload)
        {
            string Id = Request.Params["id"];

            foreach (var item in fileUpload)
            {
                PhotoDTO photo = new PhotoDTO
                {
                    PhotoId = 0,
                    PathPhoto = "/Images/" + item.FileName,
                    GoodId = Convert.ToInt32(Id)
                };
                photoService.AddOrUpdate(photo);
                string path = Path.Combine(Server.MapPath("~/Images/"), item.FileName);
                item.SaveAs(path);
            }
            return RedirectToAction("Details", "Good", new { id = Convert.ToInt32(Id) });
        }
    }
}