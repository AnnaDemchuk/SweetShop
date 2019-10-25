using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Models
{
    public class ProductDTO
    {
        [Display(Name = "№ товара")]
        public int ProductId { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "Товар")]
        public string GoodName { get; set; }

        [StringLength(2000)]
        [Display(Name = "Описание")]
        public string GoodAbout { get; set; }

        [StringLength(128)]
        [Display(Name = "Комментарий")]
        public string GoodComment { get; set; }

        [Display(Name = "№ категории")]
        public int CategoryId { get; set; }

        [Display(Name = "Категория")]
        public string CategoryName { get; set; }

        [Display(Name = "№ производителя")]
        public int ManufacturerId { get; set; }

        [Display(Name = "Производитель")]
        public string ManufacturerName { get; set; }

        [Display(Name = "№ производителя")]
        public int UnitId { get; set; }

        [Display(Name = "Единицы измерения")]
        public string UnitName { get; set; }
    }
}
