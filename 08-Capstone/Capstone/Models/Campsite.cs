using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    class Campsite
    {
        public int CampsiteId { get; set; }
        public string Name { get; set; }
        public int SiteNumber { get; set; }
        public int MaxOccupancy { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
