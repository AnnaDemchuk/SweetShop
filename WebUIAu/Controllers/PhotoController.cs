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

        public ActionResult ShowPhotoDelete(int id)
        {
           
            var photo = photoService.FindBy(p => p.ProductId == id);
            ViewBag.ProductId = id;//
             return PartialView(photo);//
          //  return View(photo);
        }

        public ActionResult ShowPhoto(int id)
        {
            var photo = photoService.FindBy(p => p.ProductId == id);
            ViewBag.ProductId = id;
            return View(photo);
        }
     
        public ActionResult FirstPhoto(int id)
        {
            var photo = photoService.FindBy(p => p.ProductId == id).FirstOrDefault();
            return PartialView(photo);
        }
        
        public ActionResult UploadPhoto(int id)
        {
            ViewBag.ProductId = id;
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
                    ProductId = Convert.ToInt32(Id) //
                };
                photoService.AddOrUpdate(photo);
                string path = Path.Combine(Server.MapPath("~/Images/"), item.FileName);
                item.SaveAs(path);
            }
            //  return RedirectToAction("Details", "ProductPrice", new { id = Convert.ToInt32(Id) });
            return RedirectToAction("Edit", "Product", new { id = Convert.ToInt32(Id) });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
              
                PhotoDTO photo = photoService.Get(id);
                photoService.Delete(photo);
                return Json("OK");
            }
            catch
            {
                return Json("Error");
            }
        }
    }
}