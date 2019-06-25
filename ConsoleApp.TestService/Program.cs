using Autofac;
using Shop.BLL.Models;
using Shop.BLL.Modules;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.TestService
{
    public class Cart
    {
        public int GoodId { get; set; }
        public int GoodAmount { get; set; }
    }
    class Program
    {

        static List<Cart>  GetCarts()
        {
           return new List<Cart>()
            {
                new Cart{  GoodId =1, GoodAmount=2},
                new Cart{  GoodId =4, GoodAmount=3},
                new Cart{  GoodId =14, GoodAmount=1}
            };
        }
        static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ServiceModule>();
            return builder.Build();
        }

        static void Main(string[] args)
        {
            var container = BuildContainer();
            var categoryService = container.Resolve<IGenericService<CategoryDTO>>();

            var collection = categoryService.GetAll();
            foreach (var item in collection)
            {
                Console.WriteLine($"{item.Id}, {item.CategoryName}");
            }
            Console.WriteLine("---------- Delete record");
            CategoryDTO category = new CategoryDTO { Id = 7, CategoryName = "test" };
            var c = categoryService.Delete(category);
            Console.WriteLine($"Delete record from table Category Id=={c.Id}");

            Console.WriteLine("---------- Add record");
            CategoryDTO categoryNew = new CategoryDTO { CategoryName = "test SERVICE UPD" };
            var catNew = categoryService.AddOrUpdate(categoryNew);
            Console.WriteLine($"Add record to table Category Id=={catNew.Id}, Name={catNew.CategoryName}");


            //var goodsService = container.Resolve<IGenericService<GoodDTO>>();
            //var saleService = container.Resolve<IGenericService<SaleDTO>>();
            //var saleposService = container.Resolve<IGenericService<SaleposDTO>>();


            //using (var tran = new TransactionScope())
            //{
            //    try
            //    {
            //SaleDTO sale = new SaleDTO { UserId = 1, DateCreate = DateTime.Now };
            //var saleresult = saleService.AddOrUpdate(sale);
            //var carts = GetCarts();
            //foreach (var cart in carts)
            //{
            //    GoodDTO good = goodsService.Get(cart.GoodId);
            //    good.GoodCount -= cart.GoodAmount;
            //    goodsService.AddOrUpdate(good);
            //    saleposService.AddOrUpdate(new SaleposDTO
            //    {
            //        GoodId = cart.GoodId,
            //        GoodAmount = cart.GoodAmount,
            //        SaleId = saleresult
            //    .SaleId
            //    });
            //}
            ////tran.Complete();
            //Console.WriteLine("Transaction OK");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine(ex.StackTrace);
            //}
            //}



        }
    }
}
