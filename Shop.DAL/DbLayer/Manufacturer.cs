namespace Shop.DAL.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Manufacturer")]
    public partial class Manufacturer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Manufacturer()
        {
            Product = new HashSet<Product>();
        }

        public int ManufacturerId { get; set; }

        [Required]
        [StringLength(32)]
        public string ManufacturerName { get; set; }

        public string ManufacturerAbout { get; set; }

        [StringLength(50)]
        public string ManufacturerSite { get; set; }

        [StringLength(10)]
        public string ManufacturerPhone { get; set; }

        [StringLength(50)]
        public string ManufacturerEmail { get; set; }

        [StringLength(50)]
        public string ManufacturerPhotoPath { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
