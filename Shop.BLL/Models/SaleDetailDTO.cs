using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Models
{
    public class SaleDetailDTO
    {
        public int SaleDetailId { get; set; }

        public int SaleId { get; set; }

        public int GoodId { get; set; }

        public int GoodAmount { get; set; }
    }
}
