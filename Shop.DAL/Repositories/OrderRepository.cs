using Shop.DAL.DbLayer;
using Step.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Repositories
{
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository(DbContext context) : base(context)
        {
        }
    }
}
