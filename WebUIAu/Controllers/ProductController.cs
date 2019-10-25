using Shop.BLL.Models;
using Shop.BLL.Services; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Step.WebUI.Controllers
{
  
    public class ProductController : Controller
    {
       
        IGenericService<ProductDTO> productService;
        IGenericService<CategoryDTO> categoryService;
        IGenericService<ManufacturerDTO> manufacturerService;
        IGenericService<UnitDTO> unitService;

        public ProductController(IGenericService<ProductDTO> productService,          
             IGenericService<CategoryDTO> categoryService,
             IGenericService<ManufacturerDTO> manufacturerService,
             IGenericService<UnitDTO> unitService)
        {         
            this.productService = productService;
            this.categoryService = categoryService;
            this.manufacturerService = manufacturerService;
            this.unitService = unitService;
        }

        public ActionResult Index()
        {
            var model = productService.GetAll();
            return View(model);
        }

        public ActionResult IndexHtmlAction()
        {
            return View();
        }

        public ActionResult IndexListing()
        {
            var model = productService.GetAll();
            return PartialView("IndexListing", model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id = 0)
        {
            var product = (id == 0) ? new ProductDTO() : productService.Get(id);
            ViewBag.CategoryId = new SelectList(GetNullCategoryName().Union(categoryService.GetAll()), "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(GetNullManufacturerName().Union(manufacturerService.GetAll()), "ManufacturerId", "ManufacturerName", product.ManufacturerId);
            ViewBag.UnitId = new SelectList(GetNullUnitName().Union(unitService.GetAll()), "UnitId", "UnitName", product.UnitId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                productService.AddOrUpdate(product);
                //  return RedirectToAction("Index");
                // return RedirectToAction("Edit", "ProductPrice", new { area = " " });
                  return RedirectToAction("IndexHtmlAction");
            }
            return View("Edit");
        }

        IEnumerable<CategoryDTO> GetNullCategoryName()
        {
            yield return new CategoryDTO() { CategoryName = "Input Category" };
        }

        IEnumerable<ManufacturerDTO> GetNullManufacturerName()
        {
            yield return new ManufacturerDTO() { ManufacturerName = "Input Manufacturer" };
        }

        IEnumerable<UnitDTO> GetNullUnitName()
        {
            yield return new UnitDTO() { UnitName = "Input UnitName" };
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                ProductDTO product = productService.Get(id);
                productService.Delete(product);
                return Json("OK");
            }
            catch
            {
                return Json("Error");
            }
        }

        public ActionResult Details(int id)
        {
            return View(productService.Get(id));
        }
    }
   
}
