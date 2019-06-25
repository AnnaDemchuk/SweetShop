using Shop.BLL.Models;
using Shop.BLL.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Step.WebUI.Controllers
{
    public class GoodController : Controller
    {

        //  UserCart userCart;
        IGenericService<GoodDTO> goodService;
        IGenericService<ManufacturerDTO> manufacturerService;
        IGenericService<CategoryDTO> categoryService;
        public GoodController(IGenericService<GoodDTO> goodService,
             IGenericService<ManufacturerDTO> manufacturerService,
             IGenericService<CategoryDTO> categoryService)
        {
            this.goodService = goodService;
            this.manufacturerService = manufacturerService;
            this.categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var model = goodService.GetAll();
            return View(model);
        }

        public ActionResult Edit(int id = 0)
        {
            var model = (id == 0) ? new GoodDTO() : goodService.Get(id);
            /*  ViewBag.ManufacturerId = new SelectList(GetNullManufacturer().Union(manufacturerService.GetAll()),
                              "ManufacturerId", "ManufacturerName", model.ManufacturerId);
              ViewBag.CategoryId = new SelectList(GetNullCategory().Union(categoryService.GetAll()),
                              "CategoryId", "CategoryName", model.CategoryId);
                               */
                

            ViewBag.ManufacturerId = new SelectList(manufacturerService.GetAll(),
                                "ManufacturerId", "ManufacturerName", model.ManufacturerId);
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(),
                              "CategoryId", "CategoryName", model.CategoryId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(GoodDTO good)
        {
            if (ModelState.IsValid)
            {
                goodService.AddOrUpdate(good);
                return RedirectToAction("Index");
            }
            return View("Edit");
        }

        /*
              IEnumerable<ManufacturerDTO> GetNullManufacturer()
              {
                  yield return new ManufacturerDTO() { ManufacturerName = "Input Manufacturer" };
              }


              IEnumerable<CategoryDTO> GetNullCategory()
              {
                  yield return new CategoryDTO() { CategoryName = "Input Category" };
              }
      */
        public ActionResult Details(int id)
        {
            return View(goodService.Get(id));
        }
        

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                GoodDTO good = goodService.Get(id);
                goodService.Delete(good);
                return Json("OK");
            }
            catch
            {
                return Json("Error");
            }
        }

    }
}