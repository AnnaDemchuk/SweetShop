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
    public class TasteCategoryController : Controller
    {
        IGenericService<TasteCategoryDTO> tasteCategoryService;
        IGenericService<CategoryDTO> categoryService;

        public TasteCategoryController(IGenericService<TasteCategoryDTO> tasteCategoryService,
            IGenericService<CategoryDTO> categoryService)
        {
            this.tasteCategoryService = tasteCategoryService;
            this.categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var model = tasteCategoryService.GetAll();
            return View(model);
        }

        public ActionResult IndexHtmlAction()
        {
            return View();
        }

        public ActionResult IndexListing()
        {
            var model = tasteCategoryService.GetAll();
            return PartialView("IndexListing", model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id = 0)
        {
            var model = (id == 0) ? new TasteCategoryDTO() : tasteCategoryService.Get(id);
            ViewBag.TasteCategoryId = id;
            ViewBag.CategoryId = new SelectList(GetNullCategoryName().Union(categoryService.GetAll()), "CategoryId", "CategoryName", model.CategoryId); ;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(TasteCategoryDTO tasteCategory)
        {
            if (ModelState.IsValid)
            {
                tasteCategoryService.AddOrUpdate(tasteCategory);
                return RedirectToAction("IndexHtmlAction");
            }
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                TasteCategoryDTO tasteCategory = tasteCategoryService.Get(id);
                tasteCategoryService.Delete(tasteCategory);
                return Json("OK");
            }
            catch
            {
                return Json("Error");
            }
        }

        [HttpPost]
        public ActionResult DeletePhoto(int id)
        {
            try
            {
                TasteCategoryDTO tasteCategory = tasteCategoryService.Get(id);
                tasteCategory.TasteCategoryPathPhoto = null;
                tasteCategoryService.AddOrUpdate(tasteCategory);
                return Json("OK");
            }
            catch
            {
                return Json("Error");
            }
        }


        IEnumerable<CategoryDTO> GetNullCategoryName()
        {
            yield return new CategoryDTO() { CategoryName = "Input Category" };
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
                TasteCategoryDTO tasteCategory = tasteCategoryService.Get(Convert.ToInt32(Id));
                tasteCategory.TasteCategoryPathPhoto = "/Images/" + fileUpload.FileName;
                tasteCategoryService.AddOrUpdate(tasteCategory);
            }
            string path = Path.Combine(Server.MapPath("~/Images/"), fileUpload.FileName);
            fileUpload.SaveAs(path);

            return RedirectToAction("Edit", "TasteCategory", new { id = Convert.ToInt32(Id) });
        }
    }
}