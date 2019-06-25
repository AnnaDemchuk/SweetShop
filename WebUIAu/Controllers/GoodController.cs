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

        public ActionResult Edit(int id)
        {
            GoodDTO good = (id == 0) ? new GoodDTO() : goodService.Get(id);

            ViewBag.CategoryId = new SelectList(categoryService.GetAll(),
                    "CategoryId", "CategoryName", good.CategoryName);
            ViewBag.ManufacturerId = new SelectList(manufacturerService.GetAll(),
                                "ManufacturerId", "ManufacturerName", good.ManufacturerName);
   
            return View(good);
        }

        [HttpPost]
        public ActionResult Edit(GoodDTO good)
        {
            if (ModelState.IsValid)
            {
                goodService.AddOrUpdate(good);
                return RedirectToAction("Index");
            }
            return View(good);
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

        public ActionResult Details(int id)
        {
            return View(goodService.Get(id));
        }



    }
}