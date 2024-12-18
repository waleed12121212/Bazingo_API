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
        [Key]
        public int ShoppingCartItemID { get; set; }

        [Required]
        public string BuyerID { get; set; }
        public User Buyer { get; set; }

        [Required]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        [Required]
        [Range(1 , int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01 , double.MaxValue)]
        public decimal TotalPrice { get; set; }
    }
}
