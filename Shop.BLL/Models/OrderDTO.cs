using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Models
{
    public class OrderDTO
    {
        [Display(Name = "№ заказа")]
        public int OrderId { get; set; }

        [Display(Name = "№ пользователя")]
        [StringLength(128)]
        public string UserId { get; set; }

        [Display(Name = "Итого")]
        public int Total { get; set; }

        [Display(Name = "Дата заказа")]
        public DateTime DateCreateOrder { get; set; }

        [Display(Name = "Дата получения товара")]
        public DateTime DateCreateGood { get; set; }

        [Display(Name = "№ доставки")]
        public int DeliveryId { get; set; }

        [Display(Name = "Тип доставки")]
        public string DeliveryName { get; set; }

        [StringLength(128)]
        [Display(Name = "Адрес")]
        public string DeliveryAdress { get; set; }

        [Display(Name = "№ статуса")]
        public int StatusId { get; set; }

        [Display(Name = "Статус заказа")]
        public string StatusName { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "Имя")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Телефон")]
        public string UserPhone { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Эл.почта")]
        public string UserEmail { get; set; }

        [StringLength(128)]
        [Display(Name = "Комментарий к доставке")]
        public string OrderComment { get; set; }
    }
}
