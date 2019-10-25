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
    public class TasteCategoryService : IGenericService<TasteCategoryDTO>
    {
        IGenericRepository<TasteCategory> tasteCategoryRepository;
        private readonly IMapper _mapper;
        public TasteCategoryService(IGenericRepository<TasteCategory> tasteCategoryRepository)
        {
            this.tasteCategoryRepository = tasteCategoryRepository;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<TasteCategory, TasteCategoryDTO>()
                .ForMember("CategoryName", opt => opt.MapFrom(g => g.Category.CategoryName))
                 ;
                cfg.CreateMap<TasteCategoryDTO, TasteCategory>();

            }).CreateMapper();
        }


        public TasteCategoryDTO AddOrUpdate(TasteCategoryDTO obj)
        {
            try
            {
                TasteCategory tasteCategory = _mapper.Map<TasteCategory>(obj);
                tasteCategoryRepository.AddOrUpdate(tasteCategory);
                return _mapper.Map<TasteCategoryDTO>(tasteCategory);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TasteCategoryDTO Delete(TasteCategoryDTO obj)
        {
            try
            {
                TasteCategory tasteCategory = _mapper.Map<TasteCategory>(obj);
                tasteCategoryRepository.Delete(tasteCategory);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TasteCategoryDTO> FindBy(Expression<Func<TasteCategoryDTO, bool>> predicate)
        {
            try
            {
                var tasteCategoryPredicate = _mapper.Map<Expression<Func<TasteCategory, bool>>>(predicate);
                return tasteCategoryRepository.FindBy(tasteCategoryPredicate).Select(m => _mapper.Map<TasteCategoryDTO>(m));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TasteCategoryDTO Get(int id)
        {
            try
            {
                return _mapper.Map<TasteCategoryDTO>(tasteCategoryRepository.Get(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TasteCategoryDTO> GetAll()
        {
            try
            {
                return tasteCategoryRepository.GetAll().Select(m => _mapper.Map<TasteCategoryDTO>(m));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
