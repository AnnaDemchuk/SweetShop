using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Models
{
  public  class TasteCategoryDTO
    {
        [Display(Name = "№ вкус")]
        public int TasteCategoryId { get; set; }

        [Display(Name = "№ категории")]
        public int CategoryId { get; set; }

        [Display(Name = "Категория")]
        public string CategoryName { get; set; }

        [Required]
        [StringLength(32)]
        [Display(Name = "Вкус")]
        public string TasteCategoryName { get; set; }

        [StringLength(128)]
        [Display(Name = "Фото")]
        public string TasteCategoryPathPhoto { get; set; }
    }
}
