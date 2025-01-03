﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Models
{
    public class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<Zone> Zones { get; set; }
    }
}
