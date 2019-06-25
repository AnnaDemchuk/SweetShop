using Shop.BLL.Models;
using Shop.DAL.DbLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUIAu.Models
{
    public class CartLine
    {
        public GoodDTO Goodcart { get; set; }
        public int Quantity { get; set; }
    }
}