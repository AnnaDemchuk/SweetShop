namespace Shop.DAL.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductPrice")]
    public partial class ProductPrice
    {
        public int ProductPriceId { get; set; }

        public int ProductId { get; set; }

        public int? SubCategoryId { get; set; }

        public int? TasteCategoryId { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public virtual Product Product { get; set; }

        public virtual SubCategory SubCategory { get; set; }

        public virtual TasteCategory TasteCategory { get; set; }
    }
}
