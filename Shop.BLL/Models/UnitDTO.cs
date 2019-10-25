using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Models
{
    public class UnitDTO
    {
        [Display(Name = "№ ед. изм.")]
        public int UnitId { get; set; }

        [Required]
        [StringLength(32)]
        [Display(Name = "Единицы измерения")]
        public string UnitName { get; set; }
    }
}
