using Step.Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.DbLayer
{
    public partial class Delivery : Entity<int>
    {
       
        [NotMapped]
        public override int Id
        {
            get
            {
                return DeliveryId;
            }
            set
            {
                DeliveryId = value;
            }
        }
      
    }

}

