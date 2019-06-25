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
    public class SaleService :  IGenericService<SaleDTO>
    {
        IGenericRepository<Sale> saleRepository;
        private readonly IMapper _mapper;
        public SaleService(IGenericRepository<Sale> saleRepository)
        {
            this.saleRepository = saleRepository;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Sale, SaleDTO>();
                cfg.CreateMap<SaleDTO, Sale>();

            }).CreateMapper();
        }

        public SaleDTO AddOrUpdate(SaleDTO obj)
        {
            try
            {
                Sale sale = _mapper.Map<Sale>(obj);
                saleRepository.AddOrUpdate(sale);
                return _mapper.Map<SaleDTO>(sale);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SaleDTO Delete(SaleDTO obj)
        {
            try
            {
                Sale sale = _mapper.Map<Sale>(obj);
                saleRepository.Delete(sale);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<SaleDTO> FindBy(Expression<Func<SaleDTO, bool>> predicate)
        {
            try
            {
                var salePredicate = _mapper.Map<Expression<Func<Sale, bool>>>(predicate);
                return saleRepository.FindBy(salePredicate).Select(s => _mapper.Map<SaleDTO>(s));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SaleDTO Get(int id)
        {
            try
            {
                return _mapper.Map<SaleDTO>(saleRepository.Get(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<SaleDTO> GetAll()
        {
            try
            {
                return saleRepository.GetAll().Select(s => _mapper.Map<SaleDTO>(s));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
