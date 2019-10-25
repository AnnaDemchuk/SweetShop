using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebUIAu.Models
{
   
    public class VMProductAllCreate
    {

        [Display(Name = "№ ProductId")]
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Товар")]
        public string GoodName { get; set; }

        [StringLength(2000)]
        [Display(Name = "Описание")]
        public string GoodAbout { get; set; }

        [StringLength(128)]
        [Display(Name = "Комментарий")]
        public string GoodComment { get; set; }

        [Display(Name = "№ Категории")]
        public int CategoryId { get; set; }

        [Display(Name = "№ Производителя")]
        public int ManufacturerId { get; set; }

        [Display(Name = "№ Единицы измерения")]
        public int UnitId { get; set; }

        //
        [Display(Name = "№ ProductPriceId")]
        public int ProductPriceId { get; set; }


        [Display(Name = "Id подкатегории")]
        public int? SubCategoryId { get; set; }

   
        [Display(Name = "Id вкус")]
        public int? TasteCategoryId { get; set; }

        [Display(Name = "Вкус")]
        public string TasteCategoryName { get; set; }

        [Display(Name = "Цена")]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}