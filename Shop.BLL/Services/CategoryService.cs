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
    public class CategoryService : IGenericService<CategoryDTO>
    {
        IGenericRepository<Category> categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Category, CategoryDTO>();
                cfg.CreateMap<CategoryDTO, Category>();
            }).CreateMapper();
        }
        /// </summary>
        /// <returns></returns>
        public CategoryDTO AddOrUpdate(CategoryDTO obj)
        {
            try
            {
                Category category = _mapper.Map<Category>(obj);
                categoryRepository.AddOrUpdate(category);
                return _mapper.Map<CategoryDTO>(category);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CategoryDTO Delete(CategoryDTO obj)
        {
            try
            {
                Category category = _mapper.Map<Category>(obj);
                categoryRepository.Delete(category);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<CategoryDTO> FindBy(Expression<Func<CategoryDTO, bool>> predicate)
        {
            try
            {
                var categoryPredicate = _mapper.Map<Expression<Func<Category, bool>>>(predicate);
                return categoryRepository.FindBy(categoryPredicate).Select(c => _mapper.Map<CategoryDTO>(c));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CategoryDTO Get(int id)
        {
            try
            {
                return _mapper.Map<CategoryDTO>(categoryRepository.Get(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            try
            {
                return categoryRepository.GetAll().Select(c => _mapper.Map<CategoryDTO>(c));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
