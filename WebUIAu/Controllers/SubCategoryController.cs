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
    public class SubCategoryController : Controller
    {
        IGenericService<SubCategoryDTO> subCategoryService;
        IGenericService<CategoryDTO> categoryService;

        public SubCategoryController(IGenericService<SubCategoryDTO> subCategoryService, 
            IGenericService<CategoryDTO> categoryService)
        {
            this.subCategoryService = subCategoryService;
            this.categoryService = categoryService;
        }


        public ActionResult IndexHtmlAction()
        {
            return View();
        }

        public ActionResult IndexListing()
        {
            var model = subCategoryService.GetAll();
            return PartialView("IndexListing", model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id = 0)
        {
            var subCategory = (id == 0) ? new SubCategoryDTO() : subCategoryService.Get(id);
            ViewBag.CategoryId = new SelectList(GetNullCategoryName().Union(categoryService.GetAll()), "CategoryId", "CategoryName", subCategory.CategoryId);
            return View(subCategory);
        }

        [HttpPost]
        public ActionResult Edit(SubCategoryDTO subCategory)
        {
            if (ModelState.IsValid)
            {
                subCategoryService.AddOrUpdate(subCategory);
                return RedirectToAction("IndexHtmlAction");
            }
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                SubCategoryDTO subCategory = subCategoryService.Get(id);
                subCategoryService.Delete(subCategory);
                return Json("OK");
            }
            catch
            {
                return Json("Error");
            }
        }

        IEnumerable<CategoryDTO> GetNullCategoryName()
        {
            yield return new CategoryDTO() { CategoryName = "Input CategoryName" };
        }

        [HttpPost]
        public ActionResult UploadPhoto(HttpPostedFileBase fileUpload)
        {
            string Id = Request.Params["id"];

            if (fileUpload != null)
            {
                SubCategoryDTO subCategory = subCategoryService.Get(Convert.ToInt32(Id));
                subCategory.SubCategoryPathPhoto = "/Images/" + fileUpload.FileName;
                subCategoryService.AddOrUpdate(subCategory);
            }
            string path = Path.Combine(Server.MapPath("~/Images/"), fileUpload.FileName);
            fileUpload.SaveAs(path);
            return RedirectToAction("Edit", "SubCategory", new { id = Convert.ToInt32(Id) });
        }
    }
}