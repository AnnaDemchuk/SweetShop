using Step.Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.DbLayer
{
    public partial class Product : Entity<int>
    {
        //[Column("ProductId")]
        //public override int Id { get; set; }
        [NotMapped]
        public override int Id
        {
            get
            {
                return ProductId;
            }
            set
            {
                ProductId = value;
            }
        }
    }

}
