namespace Shop.DAL.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderPosition = new HashSet<OrderPosition>();
            Photo = new HashSet<Photo>();
            ProductPrice = new HashSet<ProductPrice>();
        }

        public int ProductId { get; set; }

        [Required]
        [StringLength(128)]
        public string GoodName { get; set; }

        [StringLength(2000)]
        public string GoodAbout { get; set; }

        [StringLength(128)]
        public string GoodComment { get; set; }

        public int CategoryId { get; set; }

        public int ManufacturerId { get; set; }

        public int UnitId { get; set; }

        public virtual Category Category { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderPosition> OrderPosition { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Photo> Photo { get; set; }

        public virtual Unit Unit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductPrice> ProductPrice { get; set; }
    }
}
