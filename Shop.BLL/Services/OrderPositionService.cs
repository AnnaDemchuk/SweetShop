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
    public class OrderPositionService : IGenericService<OrderPositionDTO>
    {
        IGenericRepository<OrderPosition> orderPositionRepository;
        readonly IMapper _mapper;

        public OrderPositionService(IGenericRepository<OrderPosition> orderPositionRepository)
        {
            this.orderPositionRepository = orderPositionRepository;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<OrderPosition, OrderPositionDTO>()
                 .ForMember("GoodName", opt => opt.MapFrom(g => g.Product.GoodName))
                 ;
                cfg.CreateMap<OrderPositionDTO, OrderPosition>();
            }).CreateMapper();
        }

        public OrderPositionDTO AddOrUpdate(OrderPositionDTO obj)
        {
            try
            {
                OrderPosition orderPosition = _mapper.Map<OrderPosition>(obj);
                orderPositionRepository.AddOrUpdate(orderPosition);
                return _mapper.Map<OrderPositionDTO>(orderPosition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrderPositionDTO Delete(OrderPositionDTO obj)
        {
            try
            {
                OrderPosition orderPosition = _mapper.Map<OrderPosition>(obj);
                orderPositionRepository.Delete(orderPosition);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<OrderPositionDTO> FindBy(Expression<Func<OrderPositionDTO, bool>> predicate)
        {
            try
            {
                var orderPositionPredicate = _mapper.Map<Expression<Func<OrderPosition, bool>>>(predicate);
                return orderPositionRepository.FindBy(orderPositionPredicate).Select(sd => _mapper.Map<OrderPositionDTO>(sd));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrderPositionDTO Get(int id)
        {
            try
            {
                return _mapper.Map<OrderPositionDTO>(orderPositionRepository.Get(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<OrderPositionDTO> GetAll()
        {
            try
            {
                return orderPositionRepository.GetAll().Select(sd => _mapper.Map<OrderPositionDTO>(sd));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
