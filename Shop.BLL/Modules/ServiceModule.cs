using Autofac;
using Shop.BLL.Models;
using Shop.BLL.Services;
using Shop.DAL.DbLayer;
using Shop.DAL.Repositories;
using Step.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(ShopContext))
         .As(typeof(DbContext));

            // Category
            builder.RegisterType(typeof(CategoryService))
             .As(typeof(IGenericService<CategoryDTO>));
            builder.RegisterType(typeof(CategoryRepository))
             .As(typeof(IGenericRepository<Category>));

            //Delivery
            builder.RegisterType(typeof(DeliveryService))
            .As(typeof(IGenericService<DeliveryDTO>));
            builder.RegisterType(typeof(DeliveryRepository))
        .As(typeof(IGenericRepository<Delivery>));

            //Manufacturer
            builder.RegisterType(typeof(ManufacturerService))
            .As(typeof(IGenericService<ManufacturerDTO>));
            builder.RegisterType(typeof(ManufacturerRepository))
        .As(typeof(IGenericRepository<Manufacturer>));


            //OrderPosition
            builder.RegisterType(typeof(OrderPositionService))
             .As(typeof(IGenericService<OrderPositionDTO>));
            builder.RegisterType(typeof(OrderPositionRepository))
            .As(typeof(IGenericRepository<OrderPosition>));

            //Order
            builder.RegisterType(typeof(OrderService))
             .As(typeof(IGenericService<OrderDTO>));
            builder.RegisterType(typeof(OrderRepository))
            .As(typeof(IGenericRepository<Order>));

            // Photo
            builder.RegisterType(typeof(PhotoRepository)).As(typeof(IGenericRepository<Photo>));
            builder.RegisterType(typeof(PhotoService)).As(typeof(IGenericService<PhotoDTO>));

            //Product
            builder.RegisterType(typeof(ProductService))
             .As(typeof(IGenericService<ProductDTO>));
            builder.RegisterType(typeof(ProductRepository))
           .As(typeof(IGenericRepository<Product>));

            //ProductPrice
            builder.RegisterType(typeof(ProductPriceService))
             .As(typeof(IGenericService<ProductPriceDTO>));
            builder.RegisterType(typeof(ProductPriceRepository))
           .As(typeof(IGenericRepository<ProductPrice>));


            //StatusOrder
            builder.RegisterType(typeof(StatusOrderService))
             .As(typeof(IGenericService<StatusOrderDTO>));
            builder.RegisterType(typeof(StatusOrderRepository))
           .As(typeof(IGenericRepository<StatusOrder>));


            //SubCategory
            builder.RegisterType(typeof(SubCategoryService))
            .As(typeof(IGenericService<SubCategoryDTO>));
            builder.RegisterType(typeof(SubCategoryRepository))
        .As(typeof(IGenericRepository<SubCategory>));

            //TasteCategory
            builder.RegisterType(typeof(TasteCategoryService))
            .As(typeof(IGenericService<TasteCategoryDTO>));
            builder.RegisterType(typeof(TasteCategoryRepository))
        .As(typeof(IGenericRepository<TasteCategory>));

            //Unit
            builder.RegisterType(typeof(UnitService))
            .As(typeof(IGenericService<UnitDTO>));
            builder.RegisterType(typeof(UnitRepository))
        .As(typeof(IGenericRepository<Unit>));










        }
    }
}
