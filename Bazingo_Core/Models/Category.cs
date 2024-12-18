using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }

        public int? ParentCategoryID { get; set; }
        public Category ParentCategory { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<Category> SubCategories { get; set; }
    }
}
