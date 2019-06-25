using Shop.BLL.Models;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
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

        public ActionResult Edit(int id = 0)
        {
            var model = (id == 0) ? new CategoryDTO() : categoryService.Get(id);
      
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(),
                              "CategoryId", "CategoryName", model.CategoryId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                categoryService.AddOrUpdate(category);
                return RedirectToAction("Index");
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


    }
}