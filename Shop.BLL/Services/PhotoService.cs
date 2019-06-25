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
    public class PhotoService : IGenericService<PhotoDTO>
    {
        IGenericRepository<Photo> photoRepository;
        readonly IMapper _mapper;

        public PhotoService(IGenericRepository<Photo> photoRepository)
        {
            this.photoRepository = photoRepository;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Photo, PhotoDTO>();
                cfg.CreateMap<PhotoDTO, Photo>();
            }).CreateMapper();
        }
        public PhotoDTO AddOrUpdate(PhotoDTO obj)
        {
            try
            {
                Photo photo = _mapper.Map<Photo>(obj);
                photoRepository.AddOrUpdate(photo);
                return _mapper.Map<PhotoDTO>(photo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PhotoDTO Delete(PhotoDTO obj)
        {
            try
            {
                Photo photo = _mapper.Map<Photo>(obj);
                photoRepository.Delete(photo);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<PhotoDTO> FindBy(Expression<Func<PhotoDTO, bool>> predicate)
        {
            try
            {
                var photoPredicate = _mapper.Map<Expression<Func<Photo, bool>>>(predicate);
                return photoRepository.FindBy(photoPredicate).Select(p => _mapper.Map<PhotoDTO>(p));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PhotoDTO Get(int id)
        {
            try
            {
                return _mapper.Map<PhotoDTO>(photoRepository.Get(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<PhotoDTO> GetAll()
        {
            try
            {
                return photoRepository.GetAll().Select(p => _mapper.Map<PhotoDTO>(p));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
