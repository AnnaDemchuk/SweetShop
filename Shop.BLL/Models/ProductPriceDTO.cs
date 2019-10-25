using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Models
{
  public  class ProductPriceDTO
    {
        [Display(Name = "№ товара/цена")]
        public int ProductPriceId { get; set; }

        [Display(Name = "№ товара")]
        public int ProductId { get; set; }

        [Display(Name = "Товар")]
        public string GoodName { get; set; }

        [Display(Name = "№ категории")]
        public int CategoryId { get; set; }

        [Display(Name = "№ подкатегории")]
        public int? SubCategoryId { get; set; }

        [Display(Name = "Подкатегория")]
        public string SubCategoryName { get; set; }

        [Display(Name = "№ производитель")]
        public int ManufacturerId { get; set; }

        [Display(Name = "Производитель")]
        public string ManufacturerName { get; set; }


        [Display(Name = "№ вкус")]
        public int? TasteCategoryId { get; set; }

        [Display(Name = "Вкус")]
        public string TasteCategoryName { get; set; }

        [Display(Name = "Цена")]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}
