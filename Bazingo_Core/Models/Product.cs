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
        [Key]
        public int ProductID { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(0.01 , double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(0 , int.MaxValue)]
        public int Quantity { get; set; }

        public string Images { get; set; } // JSON Array

        public string VideoURL { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Relationships
        [Required]
        public string SellerID { get; set; }
        public User Seller { get; set; }

        [Required]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Auction Auction { get; set; }
    }
}
