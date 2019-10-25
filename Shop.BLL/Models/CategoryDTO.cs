using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Models
{
    public class CategoryDTO
    {
        [Display(Name = "№ категории")]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(32)]
        [Display(Name = "Категория")]
        public string CategoryName { get; set; }

        [StringLength(128)]
        [Display(Name = "Фото")]
        public string CategoryPathPhoto { get; set; }
    }
}
