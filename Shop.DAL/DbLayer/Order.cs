namespace Shop.DAL.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderPosition = new HashSet<OrderPosition>();
        }

        public int OrderId { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        public int Total { get; set; }

        public DateTime DateCreateOrder { get; set; }

        public DateTime DateCreateGood { get; set; }

        public int DeliveryId { get; set; }

        [StringLength(128)]
        public string DeliveryAdress { get; set; }

        public int StatusId { get; set; }

        [Required]
        [StringLength(128)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string UserPhone { get; set; }

        [Required]
        [StringLength(50)]
        public string UserEmail { get; set; }

        [StringLength(128)]
        public string OrderComment { get; set; }

        public virtual Delivery Delivery { get; set; }

        public virtual StatusOrder StatusOrder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderPosition> OrderPosition { get; set; }
    }
}
