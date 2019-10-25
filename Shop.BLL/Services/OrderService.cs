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
    public class OrderService :  IGenericService<OrderDTO>
    {
        IGenericRepository<Order> orderRepository;
        private readonly IMapper _mapper;
        public OrderService(IGenericRepository<Order> orderRepository)
        {
            this.orderRepository = orderRepository;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Order, OrderDTO>()
                  .ForMember("DeliveryName", opt => opt.MapFrom(g => g.Delivery.DeliveryName))//
                 .ForMember("StatusName", opt => opt.MapFrom(g => g.StatusOrder.StatusName))//
                 ;
                cfg.CreateMap<OrderDTO, Order>();

            }).CreateMapper();
        }

        public OrderDTO AddOrUpdate(OrderDTO obj)
        {
            try
            {
                Order order = _mapper.Map<Order>(obj);
                orderRepository.AddOrUpdate(order);
                var result = _mapper.Map<OrderDTO>(order);
                //result.OrderId = order.OrderId;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrderDTO Delete(OrderDTO obj)
        {
            try
            {
                Order order = _mapper.Map<Order>(obj);
                orderRepository.Delete(order);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<OrderDTO> FindBy(Expression<Func<OrderDTO, bool>> predicate)
        {
            try
            {
                var orderPredicate = _mapper.Map<Expression<Func<Order, bool>>>(predicate);
                return orderRepository.FindBy(orderPredicate).Select(s => _mapper.Map<OrderDTO>(s));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrderDTO Get(int id)
        {
            try
            {
                return _mapper.Map<OrderDTO>(orderRepository.Get(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            try
            {
                return orderRepository.GetAll().Select(s => _mapper.Map<OrderDTO>(s));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
