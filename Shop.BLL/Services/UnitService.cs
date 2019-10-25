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
    public class UnitService : IGenericService<UnitDTO>
    {
        IGenericRepository<Unit> unitRepository;
        private readonly IMapper _mapper;
        public UnitService(IGenericRepository<Unit> unitRepository)
        {
            this.unitRepository = unitRepository;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Unit, UnitDTO>();
                cfg.CreateMap<UnitDTO, Unit>();
            }).CreateMapper();
        }
        /// </summary>
        /// <returns></returns>
        public UnitDTO AddOrUpdate(UnitDTO obj)
        {
            try
            {
                Unit unit = _mapper.Map<Unit>(obj);
                unitRepository.AddOrUpdate(unit);
                return _mapper.Map<UnitDTO>(unit);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UnitDTO Delete(UnitDTO obj)
        {
            try
            {
                Unit unit = _mapper.Map<Unit>(obj);
                unitRepository.Delete(unit);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<UnitDTO> FindBy(Expression<Func<UnitDTO, bool>> predicate)
        {
            try
            {
                var unitPredicate = _mapper.Map<Expression<Func<Unit, bool>>>(predicate);
                return unitRepository.FindBy(unitPredicate).Select(c => _mapper.Map<UnitDTO>(c));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UnitDTO Get(int id)
        {
            try
            {
                return _mapper.Map<UnitDTO>(unitRepository.Get(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<UnitDTO> GetAll()
        {
            try
            {
                return unitRepository.GetAll().Select(c => _mapper.Map<UnitDTO>(c));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
