using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public int BaseCurrencyID { get; set; }
        public string SellerID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Images { get; set; } // JSON Array
        public string VideoURL { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public virtual AppUser Seller { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Auction Auction { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
        public virtual ICollection<PriceHistory> PriceHistories { get; set; }
        public virtual ICollection<ItemUnit> ItemUnits { get; set; }
    }
}
