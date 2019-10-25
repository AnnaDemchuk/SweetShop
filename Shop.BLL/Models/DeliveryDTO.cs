using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Models
{
  public  class DeliveryDTO
    {
        [Display(Name = "№ доставки")]
        public int DeliveryId { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "Тип доставки")]
        public string DeliveryName { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Стоимость")]
        public decimal DeliveryPrice { get; set; }
    }
}
