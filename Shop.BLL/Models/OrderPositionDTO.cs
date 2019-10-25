using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shop.BLL.Models
{
    public class OrderPositionDTO
    {
        [Display(Name = "№ позиции")]
        public int OrderPosId { get; set; }

        [Display(Name = "№ продукта")]
        public int ProductId { get; set; }

        [Display(Name = "Цена за единицу")]
        [Column(TypeName = "money")]
        public decimal OrderPosPrice { get; set; }

        [Display(Name = "Товар")]
        public string GoodName { get; set; }

        [Display(Name = "Количество")]
        public int OrderCount { get; set; }

        [Display(Name = "№ заказа")]
        public int OrderId { get; set; }

        [Display(Name = "Всего")]
        public int OrderPosAmount { get; set; }
    }
}
