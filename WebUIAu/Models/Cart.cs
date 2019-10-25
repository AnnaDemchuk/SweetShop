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
        public void AddItem(ProductPriceDTO productPriceDTO, int quantity)
        {
            CartLine line = lineCollection.Where(g => g.ProductPricecart.ProductPriceId == productPriceDTO.ProductPriceId).FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    ProductPricecart = productPriceDTO,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(ProductPriceDTO productPriceDTO)
        {
            lineCollection.RemoveAll(l =>l.ProductPricecart.ProductPriceId == productPriceDTO.ProductPriceId);
        }

         public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.ProductPricecart.Price * e.Quantity);
        }

  //товаров в корзине штук    
        public int GetCount()
        {
            int? count = 0;
            foreach (var item in lineCollection)
            {               
                    count += item.Quantity;
            }
            return count ?? 0;
        }
//

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

        public void ChangeQuantity(int id, int quantity)
        {
            foreach (var item in lineCollection)
            {
                if(item.ProductPricecart.ProductId==id)
                {
                    item.Quantity = quantity;
                }
            }
           
        }


    }
}