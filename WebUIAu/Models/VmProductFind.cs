using LinqKit;
using Shop.BLL.Models;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace WebUIAu.Models
{
    public class SubCategoryCheck
    {
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public bool IsCheck { get; set; }
    }
    //TasteCategoryId
    public class TasteCategoryCheck
    {
        public int TasteCategoryId { get; set; }
        public int CategoryId { get; set; }
        public string TasteCategoryName { get; set; }
        public bool IsCheck { get; set; }
    }
    public class ManufacturerCheck
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public bool IsCheck { get; set; }
    }

    public class VmProductFind
    {

        ////for paging
            public PagingInfo paging { get; set; }
            public int CurrentPage { get; set; }

            IGenericService<SubCategoryDTO> subCategoryService;
            IGenericService<ManufacturerDTO> manufacturerService;
            IGenericService<TasteCategoryDTO> tasteCategoryService;
            IGenericService<CategoryDTO> categoryService;
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }

            public List<SubCategoryCheck> SubCategorySelects { get; set; }
            public List<TasteCategoryCheck> TasteCategorySelects { get; set; }
            public List<ManufacturerCheck> ManufacturerSelects { get; set; }

            public VmProductFind() { }
            public VmProductFind(int CategoryId, IGenericService<SubCategoryDTO> subCategoryService,
                                          IGenericService<ManufacturerDTO> manufacturerService,
                                          IGenericService<TasteCategoryDTO> tasteCategoryService, 
                                          IGenericService<CategoryDTO> categoryService)
            {
                paging = new PagingInfo() { CurrentPage = 1, ItemsPerPage = 6 };
                this.CategoryId = CategoryId;
                this.subCategoryService = subCategoryService;
                this.manufacturerService = manufacturerService;
                this.tasteCategoryService = tasteCategoryService;
                this.categoryService = categoryService;
                CategoryName = categoryService.Get(CategoryId).CategoryName;
                SubCategorySelects = subCategoryService.FindBy(c => c.CategoryId == CategoryId)
                   .Select(c => new SubCategoryCheck
                   { SubCategoryId = c.SubCategoryId, SubCategoryName = c.SubCategoryName }).ToList();

                TasteCategorySelects = tasteCategoryService.FindBy(c => c.CategoryId == CategoryId)
                   .Select(c => new TasteCategoryCheck
                   { TasteCategoryId = c.TasteCategoryId, TasteCategoryName = c.TasteCategoryName }).ToList();


                ManufacturerSelects = manufacturerService.GetAll()
                    .Select(c => new ManufacturerCheck
                    { ManufacturerId = c.ManufacturerId, ManufacturerName = c.ManufacturerName }).ToList();
            }

        IEnumerable<ProductPriceDTO> m_products;
        public IEnumerable<ProductPriceDTO> products
        {
            get
            {
                return m_products;
            }

            set
            {
                m_products = value;

                paging.TotalItems = (m_products == null) ? 0 : m_products.Count();
            }
        }
        //Получить записи по фильтру
        public IEnumerable<ProductPriceDTO> ProductOnPage
        {
            get
            {
                return products.OrderBy(c => c.ProductPriceId).Skip((paging.CurrentPage - 1) * paging.ItemsPerPage).Take(paging.ItemsPerPage);
            }
        }
        public Expression<Func<ProductPriceDTO, bool>> Predicate
            {
                get
                {
                    var predicate = PredicateBuilder.New<ProductPriceDTO>(true);

                predicate = predicate.And(g => g.CategoryId == CategoryId); //

                if (ManufacturerSelects.Select(c => c.IsCheck).Count() > 0)
                    {
                        var predicateManufacturer = PredicateBuilder.New<ProductPriceDTO>(true);
                        foreach (var item in ManufacturerSelects)
                        {
                            if (item.IsCheck)
                                predicateManufacturer = predicateManufacturer.Or(c => c.ManufacturerId == item.ManufacturerId);
                        }
                        predicate = predicate.And(predicateManufacturer);
                    }
                    if (SubCategorySelects.Select(c => c.IsCheck).Count() > 0)
                    {
                        var predicateCategory = PredicateBuilder.New<ProductPriceDTO>(true);
                        foreach (var item in SubCategorySelects)
                        {
                            if (item.IsCheck)
                                predicateCategory = predicateCategory.Or(c => c.SubCategoryId == item.SubCategoryId);
                        }
                        predicate = predicate.And(predicateCategory);
                    }
                    if (TasteCategorySelects.Select(c => c.IsCheck).Count() > 0)
                    {
                        var predicateTasteCategory = PredicateBuilder.New<ProductPriceDTO>(true);
                        foreach (var item in TasteCategorySelects)
                        {
                            if (item.IsCheck)
                                predicateTasteCategory = predicateTasteCategory.Or(c => c.TasteCategoryId == item.TasteCategoryId);
                        }
                        predicate = predicate.And(predicateTasteCategory);
                    }

                    return predicate;
                }
            }
        }
    }
