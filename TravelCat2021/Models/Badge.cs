using System;
using System.Collections.Generic;

#nullable disable

namespace TravelCat2021.Models
{
    public partial class Badge
    {
        public Badge()
        {
            BadgeDetails = new HashSet<BadgeDetail>();
        }

        public int BadgeId { get; set; }
        public string BadgeTitle { get; set; }
        public string BadgePhoto { get; set; }

        public virtual ICollection<BadgeDetail> BadgeDetails { get; set; }
    }
}
