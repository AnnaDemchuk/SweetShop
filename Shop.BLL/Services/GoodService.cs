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
    public class GoodService : IGenericService<GoodDTO>
    {
        IGenericRepository<Good> goodRepository;
        private readonly IMapper _mapper;
        public GoodService(IGenericRepository<Good> goodRepository)
        {
            this.goodRepository = goodRepository;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Good, GoodDTO>()
                 .ForMember("CategoryName", opt => opt.MapFrom(g => g.Category.CategoryName))
                 .ForMember("ManufacturerName", opt => opt.MapFrom(g => g.Manufacturer.ManufacturerName))
                 ;
                cfg.CreateMap<GoodDTO, Good>();
               
            }).CreateMapper();
        }

        public GoodDTO AddOrUpdate(GoodDTO obj)
        {
            try
            {
                Good good = _mapper.Map<Good>(obj);
                goodRepository.AddOrUpdate(good);
                return _mapper.Map<GoodDTO>(good);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GoodDTO Delete(GoodDTO obj)
        {
            try
            {
                Good good = _mapper.Map<Good>(obj);
                goodRepository.Delete(good);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<GoodDTO> FindBy(Expression<Func<GoodDTO, bool>> predicate)
        {
            try
            {
                var goodPredicate = _mapper.Map<Expression<Func<Good, bool>>>(predicate);
                return goodRepository.FindBy(goodPredicate).Select(g => _mapper.Map<GoodDTO>(g));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GoodDTO Get(int id)
        {
            try
            {
                return _mapper.Map<GoodDTO>(goodRepository.Get(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<GoodDTO> GetAll()
        {
            try
            {
                return goodRepository.GetAll().Select(g => _mapper.Map<GoodDTO>(g));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
