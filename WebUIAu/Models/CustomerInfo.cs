using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUIAu.Models
{
    public enum Delivery
    {
        [Description("Самовывоз")]
        Pickup,
        [Description("Доставка курьером по Киеву")]
        Courier

    }
    public class CustomerInfo
    {

        [Required]
        [StringLength(128)]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Эл.почта")]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Display(Name = "Доставка")]
        public Delivery DeliveryInfo { get; set; }
    }
}