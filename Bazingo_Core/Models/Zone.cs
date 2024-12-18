using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Models
{
    public class Zone
    {
        [Key]
        public int ZoneID { get; set; }

        [Required]
        [MaxLength(100)]
        public string ZoneName { get; set; }

        [Required]
        public int CityID { get; set; }
        public City City { get; set; }

        // Relationships
        public ICollection<Shipping> Shippings { get; set; }
    }
}
