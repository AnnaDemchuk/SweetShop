namespace Shop.DAL.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SaleDetail
    {
        public int SaleDetailId { get; set; }

        public int SaleId { get; set; }

        public int GoodId { get; set; }

        public int GoodAmount { get; set; }

        public virtual Good Good { get; set; }

        public virtual Sale Sale { get; set; }
    }
}
