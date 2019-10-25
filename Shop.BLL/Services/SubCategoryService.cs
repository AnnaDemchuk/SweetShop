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
    public class SubCategoryService : IGenericService<SubCategoryDTO>
    {
        IGenericRepository<SubCategory> subCategoryRepository;
        private readonly IMapper _mapper;
        public SubCategoryService(IGenericRepository<SubCategory> subCategoryRepository)
        {
            this.subCategoryRepository = subCategoryRepository;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<SubCategory, SubCategoryDTO>()
                .ForMember("CategoryName", opt => opt.MapFrom(g => g.Category.CategoryName))
                ;
                cfg.CreateMap<SubCategoryDTO, SubCategory>();

            }).CreateMapper();
        }
        public SubCategoryDTO AddOrUpdate(SubCategoryDTO obj)
        {
            try
            {
                SubCategory subCategory = _mapper.Map<SubCategory>(obj);
                subCategoryRepository.AddOrUpdate(subCategory);
                return _mapper.Map<SubCategoryDTO>(subCategory);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SubCategoryDTO Delete(SubCategoryDTO obj)
        {
            try
            {
                SubCategory subCategory = _mapper.Map<SubCategory>(obj);
                subCategoryRepository.Delete(subCategory);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<SubCategoryDTO> FindBy(Expression<Func<SubCategoryDTO, bool>> predicate)
        {
            try
            {
                var subCategoryPredicate = _mapper.Map<Expression<Func<SubCategory, bool>>>(predicate);
                return subCategoryRepository.FindBy(subCategoryPredicate).Select(m => _mapper.Map<SubCategoryDTO>(m));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SubCategoryDTO Get(int id)
        {
            try
            {
                return _mapper.Map<SubCategoryDTO>(subCategoryRepository.Get(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<SubCategoryDTO> GetAll()
        {
            try
            {
                return subCategoryRepository.GetAll().Select(m => _mapper.Map<SubCategoryDTO>(m));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
