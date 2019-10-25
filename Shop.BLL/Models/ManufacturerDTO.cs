using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Models
{
    public class ManufacturerDTO
    {
        [Display(Name = "№ производителя")]
        public int ManufacturerId { get; set; }

        [Required]
        [StringLength(32)]
        [Display(Name = "Производитель")]
        public string ManufacturerName { get; set; }

        [Display(Name = "Описание")]
        public string ManufacturerAbout { get; set; }

        [StringLength(50)]
        [Display(Name = "Сайт")]
        public string ManufacturerSite { get; set; }

        [StringLength(10)]
        [Display(Name = "Телефон")]
        public string ManufacturerPhone { get; set; }

        [StringLength(50)]
        [Display(Name = "Емайл")]
        public string ManufacturerEmail { get; set; }

        [StringLength(50)]
        [Display(Name = "Фото")]
        public string ManufacturerPhotoPath { get; set; }
    }
}
