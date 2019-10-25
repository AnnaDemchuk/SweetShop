using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Models
{
  public  class SubCategoryDTO
    {
        [Display(Name = "№ подкатегории")]
        public int SubCategoryId { get; set; }

        [Display(Name = "№ категория")]
        public int CategoryId { get; set; }

        [Display(Name = "Категория")]
        public string CategoryName { get; set; }

        [Required]
        [StringLength(32)]
        [Display(Name = "Подкатегория")]
        public string SubCategoryName { get; set; }

        [StringLength(128)]
        [Display(Name = "Фото")]
        public string SubCategoryPathPhoto { get; set; }
    }
}
