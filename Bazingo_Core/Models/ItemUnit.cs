using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Models
{
    public class ItemUnit
    {
        [Key]
        public int ItemUnitID { get; set; }

        [Required]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        [Required]
        public int UnitID { get; set; }
        public Unit Unit { get; set; }

        [Required]
        [Range(0.01 , double.MaxValue)]
        public decimal QuantityPerUnit { get; set; }
    }
}
