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
    public class StatusOrderService : IGenericService<StatusOrderDTO>
    {
        IGenericRepository<StatusOrder> statusOrderRepository;
        private readonly IMapper _mapper;
        public StatusOrderService(IGenericRepository<StatusOrder> statusOrderRepository)
        {
            this.statusOrderRepository = statusOrderRepository;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<StatusOrder, StatusOrderDTO>();
                cfg.CreateMap<StatusOrderDTO, StatusOrder>();
            }).CreateMapper();
        }
        /// </summary>
        /// <returns></returns>
        public StatusOrderDTO AddOrUpdate(StatusOrderDTO obj)
        {
            try
            {
                StatusOrder statusOrder = _mapper.Map<StatusOrder>(obj);
                statusOrderRepository.AddOrUpdate(statusOrder);
                return _mapper.Map<StatusOrderDTO>(statusOrder);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public StatusOrderDTO Delete(StatusOrderDTO obj)
        {
            try
            {
                StatusOrder statusOrder = _mapper.Map<StatusOrder>(obj);
                statusOrderRepository.Delete(statusOrder);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<StatusOrderDTO> FindBy(Expression<Func<StatusOrderDTO, bool>> predicate)
        {
            try
            {
                var statusOrderPredicate = _mapper.Map<Expression<Func<StatusOrder, bool>>>(predicate);
                return statusOrderRepository.FindBy(statusOrderPredicate).Select(c => _mapper.Map<StatusOrderDTO>(c));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public StatusOrderDTO Get(int id)
        {
            try
            {
                return _mapper.Map<StatusOrderDTO>(statusOrderRepository.Get(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<StatusOrderDTO> GetAll()
        {
            try
            {
                return statusOrderRepository.GetAll().Select(c => _mapper.Map<StatusOrderDTO>(c));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
