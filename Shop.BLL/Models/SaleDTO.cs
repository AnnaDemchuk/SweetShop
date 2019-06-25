using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Models
{
    public class SaleDTO
    {
      //  public int SaleId { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }

        public DateTime DateCreate { get; set; }

        [Column(TypeName = "money")]
        public decimal Summa { get; set; }
    }
}
