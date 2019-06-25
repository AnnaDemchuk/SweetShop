namespace Shop.DAL.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sale")]
    public partial class Sale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sale()
        {
            Salepos = new HashSet<SaleDetail>();
        }

        public int SaleId { get; set; }

        public int UserId { get; set; }

        public DateTime DateCreate { get; set; }

        [Column(TypeName = "money")]
        public decimal Summa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleDetail> Salepos { get; set; }
    }
}
