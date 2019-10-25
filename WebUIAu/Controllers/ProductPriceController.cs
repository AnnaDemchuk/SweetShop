using Shop.BLL.Models;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUIAu.Models;

namespace Step.WebUI.Controllers
{
    public class ProductPriceController : Controller
    {
      
        IGenericService<ProductPriceDTO> productPriceService;
        IGenericService<ProductDTO> productService;
        IGenericService<CategoryDTO> categoryService;
        IGenericService<SubCategoryDTO> subCategoryService;
        IGenericService<TasteCategoryDTO> tasteCategoryService;
        IGenericService<ManufacturerDTO> manufacturerService;

        public ProductPriceController(IGenericService<ProductPriceDTO> productPriceService,
             IGenericService<ProductDTO> productService,
             IGenericService<SubCategoryDTO> subCategoryService,
             IGenericService<TasteCategoryDTO> tasteCategoryService,
             IGenericService<ManufacturerDTO> manufacturerService,
             IGenericService<CategoryDTO> categoryService)
        {
            this.productPriceService = productPriceService;
            this.productService = productService;
            this.subCategoryService = subCategoryService;
            this.tasteCategoryService = tasteCategoryService;
            this.manufacturerService = manufacturerService;
            this.categoryService = categoryService;
        }

        public ActionResult IndexHtmlAction(int? id)
        {
            return View();
        }

        public ActionResult IndexListing()
        {
            var model = productPriceService.GetAll();
            return PartialView("IndexListing", model);
        }


        public ActionResult Index(int? id)
        {        
          var model = productPriceService.GetAll().Where(e => e.CategoryId == id);
          return View(model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id = 0)
        {
            var productPrice = (id == 0) ? new ProductPriceDTO() : productPriceService.Get(id);

            ViewBag.ProductId = new SelectList(GetNullProductName().Union(productService.GetAll()), "ProductId", "GoodName", productPrice.ProductId);
            ViewBag.SubCategoryId = new SelectList(GetNullSubCategoryName().Union(subCategoryService.GetAll().Where(c => c.CategoryId == productPrice.CategoryId)), "SubCategoryId", "SubCategoryName", productPrice.SubCategoryId);
            ViewBag.TasteCategoryId = new SelectList(GetNullTasteCategoryName().Union(tasteCategoryService.GetAll().Where(c => c.CategoryId == productPrice.CategoryId)), "TasteCategoryId", "TasteCategoryName", productPrice.TasteCategoryId);
            return View(productPrice);
        }

        [HttpPost]
        public ActionResult Edit(ProductPriceDTO productPrice)
        {
            if (ModelState.IsValid)
            {
                if (productPrice.SubCategoryId == 0) productPrice.SubCategoryId = null;
                if (productPrice.TasteCategoryId == 0) productPrice.TasteCategoryId = null;
                productPriceService.AddOrUpdate(productPrice);
                return RedirectToAction("IndexHtmlAction");
            }
            return View("Edit");
        }


        IEnumerable<ProductDTO> GetNullProductName()
        {
            yield return new ProductDTO() { GoodName = "Input Product" };
        }


        IEnumerable<SubCategoryDTO> GetNullSubCategoryName()
        {
            yield return new SubCategoryDTO() { SubCategoryName = "Input SubCategory" };
        }

        IEnumerable<TasteCategoryDTO> GetNullTasteCategoryName()
        {
            yield return new TasteCategoryDTO() { TasteCategoryName = "Input TasteCategory" };
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                ProductPriceDTO productPrice = productPriceService.Get(id);
                productPriceService.Delete(productPrice);
                return Json("OK");
            }
            catch
            {
                return Json("Error");
            }
        }

        public ActionResult Details(int id)
        {
            return View(productPriceService.Get(id));
        }
    }
}