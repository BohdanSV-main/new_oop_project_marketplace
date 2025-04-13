using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace
{
    public class CartItem : IIdentifiable
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

        public CartItem(int id, int userId, int productId, string productName, decimal productPrice)
        {
            Id = id;
            UserId = userId;
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
        }
    }
}