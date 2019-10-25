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
    public class ProductService : IGenericService<ProductDTO>
    {
        IGenericRepository<Product> productRepository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Product, ProductDTO>()
                 .ForMember("CategoryName", opt => opt.MapFrom(g => g.Category.CategoryName))
                 .ForMember("ManufacturerName", opt => opt.MapFrom(g => g.Manufacturer.ManufacturerName))
                 .ForMember("UnitName", opt => opt.MapFrom(g => g.Unit.UnitName))
                 ;
                cfg.CreateMap<ProductDTO, Product>();
               
            }).CreateMapper();
        }

        public ProductDTO AddOrUpdate(ProductDTO obj)
        {
            try
            {
                Product product = _mapper.Map<Product>(obj);
                productRepository.AddOrUpdate(product);
                return _mapper.Map<ProductDTO>(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductDTO Delete(ProductDTO obj)
        {
            try
            {
                Product product = _mapper.Map<Product>(obj);
                productRepository.Delete(product);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ProductDTO> FindBy(Expression<Func<ProductDTO, bool>> predicate)
        {
            try
            {
                var productPredicate = _mapper.Map<Expression<Func<Product, bool>>>(predicate);
                return productRepository.FindBy(productPredicate).Select(g => _mapper.Map<ProductDTO>(g));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductDTO Get(int id)
        {
            try
            {
                return _mapper.Map<ProductDTO>(productRepository.Get(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            try
            {
                return productRepository.GetAll().Select(g => _mapper.Map<ProductDTO>(g));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
