using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Models
{
    public class PhotoDTO
    {
        [Display(Name = "№ фото")]
        public int PhotoId { get; set; }

        [Display(Name = "№ продукта")]
        public int ProductId { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "Фото")]
        public string PathPhoto { get; set; }
    }
}
