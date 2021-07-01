using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public ShoppingCart() : this(string.Empty)
        {

        }

        public ShoppingCart(string userName)
        {
            UserName = userName;
            ShoppingCartItems = new List<ShoppingCartItem>();
        }


        public string UserName { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public decimal TotalPrice => ShoppingCartItems.Sum(x => x.Price * x.Quantity);
    }
}
