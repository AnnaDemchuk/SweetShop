using Shop.BLL.Models;
using Shop.DAL.DbLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUIAu.Models
{
    public class Cart
    {
        public List<CartLine> lineCollection = new List<CartLine>();
        public void AddItem(GoodDTO goodDTO, int quantity)
        {
            CartLine line = lineCollection.Where(g => g.Goodcart.GoodId == goodDTO.GoodId).FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Goodcart = goodDTO,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(GoodDTO  goodDTO)
        {
            lineCollection.RemoveAll(l => l.Goodcart.GoodId == goodDTO.GoodId);
        }
         public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Goodcart.Price * e.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }
}