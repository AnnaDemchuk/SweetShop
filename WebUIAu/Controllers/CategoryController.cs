using Shop.BLL.Models;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Step.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        IGenericService<CategoryDTO> categoryService;

        public CategoryController(IGenericService<CategoryDTO> categoryService)
        {
            this.categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var model = categoryService.GetAll();
            return View(model);
        }


        public ActionResult IndexHtmlAction()
        {
            return View();
        }

        public ActionResult IndexListing()
        {
            var model = categoryService.GetAll();
            return PartialView("IndexListing", model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id = 0)
        {
            var model = (id == 0) ? new CategoryDTO() : categoryService.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                categoryService.AddOrUpdate(category);
                return RedirectToAction("IndexHtmlAction");
            }
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                CategoryDTO category = categoryService.Get(id);
                categoryService.Delete(category);
                return Json("OK");
            }
            catch
            {
                return Json("Error");
            }
        }

        public ActionResult UploadPhoto(int id)
        {
            ViewBag.ItemId = id;
            return View();
        }

        [HttpPost]
        public ActionResult UploadPhoto(HttpPostedFileBase fileUpload)
        {
            string Id = Request.Params["id"];

            if (fileUpload != null)
            {
                CategoryDTO category = categoryService.Get(Convert.ToInt32(Id));
                category.CategoryPathPhoto = "/Images/" + fileUpload.FileName;
                categoryService.AddOrUpdate(category);
            }
            string path = Path.Combine(Server.MapPath("~/Images/"), fileUpload.FileName);
            fileUpload.SaveAs(path);
            return RedirectToAction("Edit", "Category", new { id = Convert.ToInt32(Id) });
        }

    }
}