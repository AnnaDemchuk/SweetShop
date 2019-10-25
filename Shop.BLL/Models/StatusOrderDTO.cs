using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Models
{
  public  class StatusOrderDTO
    {
        [Display(Name = "№ статус")]
        public int StatusId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Статус")]
        public string StatusName { get; set; }
    }
}
