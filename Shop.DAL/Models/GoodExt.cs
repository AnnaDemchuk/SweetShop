using Step.Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.DbLayer
{
    public partial class Good : Entity<int>
    {
        //[Column("GoodId")]
        //public override int Id { get; set; }
        [NotMapped]
        public override int Id
        {
            get
            {
                return GoodId;
            }
            set
            {
                GoodId = value;
            }
        }
    }
    public partial class Manufacturer : Entity<int>
    {
        //[Column("ManufacturerId")]
        //public override int Id { get; set; }
        [NotMapped]
        public override int Id
        {
            get
            {
                return ManufacturerId;
            }
            set
            {
                ManufacturerId = value;
            }
        }
    }
    public partial class Sale : Entity<int>
    {
        //[Column("SaleId")]
        //public override int Id { get; set; }
        [NotMapped]
        public override int Id
        {
            get
            {
                return SaleId;
            }
            set
            {
                SaleId = value;
            }
        }

    }


    public partial class SaleDetail : Entity<int>
    {
        //[Column("SaleposId")]
        //public override int Id { get; set; }
        [NotMapped]
        public override int Id
        {
            get
            {
                return SaleDetailId;
            }
            set
            {
                SaleDetailId = value;
            }
        }

    }

    public partial class Photo : Entity<int>
    {
        [NotMapped]
        public override int Id
        {
            get
            {
                return PhotoId;
            }
            set
            {
                PhotoId = value;
            }
        }
    }
}
