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
    public class SaleDetailService : IGenericService<SaleDetailDTO>
    {
        IGenericRepository<SaleDetail> saleDetailRepository;
        readonly IMapper _mapper;

        public SaleDetailService(IGenericRepository<SaleDetail> saleDetailRepository)
        {
            this.saleDetailRepository = saleDetailRepository;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<SaleDetail, SaleDetailDTO>();
                cfg.CreateMap<SaleDetailDTO, SaleDetail>();
            }).CreateMapper();
        }
        public SaleDetailDTO AddOrUpdate(SaleDetailDTO obj)
        {
            try
            {
                SaleDetail saleDetail = _mapper.Map<SaleDetail>(obj);
                saleDetailRepository.AddOrUpdate(saleDetail);
                return _mapper.Map<SaleDetailDTO>(saleDetail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SaleDetailDTO Delete(SaleDetailDTO obj)
        {
            try
            {
                SaleDetail saleDetail = _mapper.Map<SaleDetail>(obj);
                saleDetailRepository.Delete(saleDetail);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<SaleDetailDTO> FindBy(Expression<Func<SaleDetailDTO, bool>> predicate)
        {
            try
            {
                var saleDetailPredicate = _mapper.Map<Expression<Func<SaleDetail, bool>>>(predicate);
                return saleDetailRepository.FindBy(saleDetailPredicate).Select(sd => _mapper.Map<SaleDetailDTO>(sd));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SaleDetailDTO Get(int id)
        {
            try
            {
                return _mapper.Map<SaleDetailDTO>(saleDetailRepository.Get(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<SaleDetailDTO> GetAll()
        {
            try
            {
                return saleDetailRepository.GetAll().Select(sd => _mapper.Map<SaleDetailDTO>(sd));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
