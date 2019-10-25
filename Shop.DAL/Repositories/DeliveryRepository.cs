using Shop.DAL.DbLayer;
using System.Data.Entity;
using Step.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Repositories
{
 public class DeliveryRepository : GenericRepository<Delivery>
    {
        public DeliveryRepository (DbContext context) : base(context)
        {
        }
    }
}


