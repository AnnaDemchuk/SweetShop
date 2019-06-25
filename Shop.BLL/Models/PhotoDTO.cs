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
        public int PhotoId { get; set; }

        public int GoodId { get; set; }

        [Required]
        [StringLength(128)]
        public string PathPhoto { get; set; }
    }
}
