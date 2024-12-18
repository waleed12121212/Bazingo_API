using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Models
{
    public class Unit
    {
        [Key]
        public int UnitID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        // Relationships
        public ICollection<ItemsUnit> ItemUnits { get; set; }
    }
}
