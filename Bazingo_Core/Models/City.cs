using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Models
{
    public class City
    {
        [Key]
        public int CityID { get; set; }

        [Required]
        [MaxLength(100)]
        public string CityName { get; set; }

        // Relationships
        public ICollection<Zone> Zones { get; set; }
    }
}
