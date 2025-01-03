using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemID { get; set; }
        public string BuyerID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual AppUser Buyer { get; set; }
        public virtual Product Product { get; set; }
    }
}
