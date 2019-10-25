namespace Shop.DAL.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TasteCategory")]
    public partial class TasteCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TasteCategory()
        {
            ProductPrice = new HashSet<ProductPrice>();
        }

        public int TasteCategoryId { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [StringLength(32)]
        public string TasteCategoryName { get; set; }

        [StringLength(128)]
        public string TasteCategoryPathPhoto { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductPrice> ProductPrice { get; set; }
    }
}
