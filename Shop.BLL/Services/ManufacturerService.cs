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
    public class ManufacturerService : IGenericService<ManufacturerDTO>
    {
        IGenericRepository<Manufacturer> manufacturerRepository;
        private readonly IMapper _mapper;
        public ManufacturerService(IGenericRepository<Manufacturer> manufacturerRepository)
        {
            this.manufacturerRepository = manufacturerRepository;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Manufacturer, ManufacturerDTO>();
                cfg.CreateMap<ManufacturerDTO, Manufacturer>();

            }).CreateMapper();
        }
        public ManufacturerDTO AddOrUpdate(ManufacturerDTO obj)
        {
            try
            {
                Manufacturer manufacturer = _mapper.Map<Manufacturer>(obj);
                manufacturerRepository.AddOrUpdate(manufacturer);
                return _mapper.Map<ManufacturerDTO>(manufacturer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ManufacturerDTO Delete(ManufacturerDTO obj)
        {
            try
            {
                Manufacturer manufacturer = _mapper.Map<Manufacturer>(obj);
                manufacturerRepository.Delete(manufacturer);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ManufacturerDTO> FindBy(Expression<Func<ManufacturerDTO, bool>> predicate)
        {
            try
            {
                var manufacturerPredicate = _mapper.Map<Expression<Func<Manufacturer, bool>>>(predicate);
                return manufacturerRepository.FindBy(manufacturerPredicate).Select(m => _mapper.Map<ManufacturerDTO>(m));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ManufacturerDTO Get(int id)
        {
            try
            {
                return _mapper.Map<ManufacturerDTO>(manufacturerRepository.Get(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ManufacturerDTO> GetAll()
        {
            try
            {
                return manufacturerRepository.GetAll().Select(m => _mapper.Map<ManufacturerDTO>(m));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
