using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Shop.BLL.Models;
using Shop.DAL.DbLayer;
using Step.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    public class ProductPriceService : IGenericService<ProductPriceDTO>
    {
        IGenericRepository<ProductPrice> productPriceRepository;
        private readonly IMapper _mapper;
        public ProductPriceService(IGenericRepository<ProductPrice> productPriceRepository)
        {
            this.productPriceRepository = productPriceRepository;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<ProductPrice, ProductPriceDTO>()
                .ForMember("CategoryId", opt => opt.MapFrom(g => g.Product.CategoryId))
                .ForMember("GoodName", opt => opt.MapFrom(g => g.Product.GoodName))
                .ForMember("SubCategoryName", opt => opt.MapFrom(g => g.SubCategory.SubCategoryName))
                .ForMember("ManufacturerId", opt => opt.MapFrom(g => g.Product.ManufacturerId))////
                .ForMember("ManufacturerName", opt => opt.MapFrom(g => g.Product.Manufacturer.ManufacturerName))//
                .ForMember("TasteCategoryName", opt => opt.MapFrom(g => g.TasteCategory.TasteCategoryName))
                 ; 
                cfg.CreateMap<ProductPriceDTO, ProductPrice>();
            }).CreateMapper();
        }
        /// </summary>
        /// <returns></returns>
        public ProductPriceDTO AddOrUpdate(ProductPriceDTO obj)
        {
            try
            {
                ProductPrice productPrice = _mapper.Map<ProductPrice>(obj);
                productPriceRepository.AddOrUpdate(productPrice);
                return _mapper.Map<ProductPriceDTO>(productPrice);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductPriceDTO Delete(ProductPriceDTO obj)
        {
            try
            {
                ProductPrice productPrice = _mapper.Map<ProductPrice>(obj);
                productPriceRepository.Delete(productPrice);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ProductPriceDTO> FindBy(Expression<Func<ProductPriceDTO, bool>> predicate)
        {
            try
            {
                var productPricePredicate = _mapper.Map<Expression<Func<ProductPrice, bool>>>(predicate);
                return productPriceRepository.FindBy(productPricePredicate).Select(c => _mapper.Map<ProductPriceDTO>(c));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductPriceDTO Get(int id)
        {
            try
            {
                return _mapper.Map<ProductPriceDTO>(productPriceRepository.Get(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ProductPriceDTO> GetAll()
        {
            try
            {
                return productPriceRepository.GetAll().Select(c => _mapper.Map<ProductPriceDTO>(c));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
