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
    public class DeliveryService : IGenericService<DeliveryDTO>
    {
        IGenericRepository<Delivery> deliveryRepository;
        private readonly IMapper _mapper;
        public DeliveryService(IGenericRepository<Delivery> deliveryRepository)
        {
            this.deliveryRepository = deliveryRepository;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Delivery, DeliveryDTO>();
                cfg.CreateMap<DeliveryDTO, Delivery>();
            }).CreateMapper();
        }
        /// </summary>
        /// <returns></returns>
        public DeliveryDTO AddOrUpdate(DeliveryDTO obj)
        {
            try
            {
                Delivery delivery = _mapper.Map<Delivery>(obj);
                deliveryRepository.AddOrUpdate(delivery);
                return _mapper.Map<DeliveryDTO>(delivery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DeliveryDTO Delete(DeliveryDTO obj)
        {
            try
            {
                Delivery delivery = _mapper.Map<Delivery>(obj);
                deliveryRepository.Delete(delivery);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<DeliveryDTO> FindBy(Expression<Func<DeliveryDTO, bool>> predicate)
        {
            try
            {
                var deliveryPredicate = _mapper.Map<Expression<Func<Delivery, bool>>>(predicate);
                return deliveryRepository.FindBy(deliveryPredicate).Select(c => _mapper.Map<DeliveryDTO>(c));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DeliveryDTO Get(int id)
        {
            try
            {
                return _mapper.Map<DeliveryDTO>(deliveryRepository.Get(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<DeliveryDTO> GetAll()
        {
            try
            {
                return deliveryRepository.GetAll().Select(c => _mapper.Map<DeliveryDTO>(c));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
