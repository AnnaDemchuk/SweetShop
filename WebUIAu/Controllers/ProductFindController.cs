using Shop.BLL.Models;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUIAu.Models;

namespace WebUIAu.Controllers
{
    public class ProductFindController : Controller
    {
        IGenericService<ProductPriceDTO> productPriceService;
        IGenericService<ProductDTO> productService;
        IGenericService<CategoryDTO> categoryService;
        IGenericService<SubCategoryDTO> subCategoryService;
        IGenericService<TasteCategoryDTO> tasteCategoryService;
        IGenericService<ManufacturerDTO> manufacturerService;

        public ProductFindController(IGenericService<ProductPriceDTO> productPriceService,
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
        public ActionResult Index(int id = 1)
        {
            VmProductFind model = new VmProductFind(id, subCategoryService, manufacturerService, tasteCategoryService, categoryService);
            return View(model);
        }
        public ActionResult LoadData(VmProductFind data)
        {
            TempData["data"] = data;
            return Json("OK");
        }
        public ActionResult ProductFindByFilter()
        {
            VmProductFind model = (VmProductFind)TempData["data"];
            //VmGoodFindByFilter model = new VmGoodFindByFilter(goodService, photoService, data);
            var products = productPriceService.FindBy(model.Predicate);
            if (model.CurrentPage > 0)
                model.paging.CurrentPage = model.CurrentPage;
            model.products = products;
            return PartialView(model);
        }

    }
}