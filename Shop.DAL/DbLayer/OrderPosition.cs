namespace Shop.DAL.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderPosition")]
    public partial class OrderPosition
    {
        [Key]
        public int OrderPosId { get; set; }

        public int ProductId { get; set; }

        [Column(TypeName = "money")]
        public decimal OrderPosPrice { get; set; }

        public int OrderCount { get; set; }

        public int OrderId { get; set; }

        public int OrderPosAmount { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
