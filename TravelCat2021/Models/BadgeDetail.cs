using System;
using System.Collections.Generic;

#nullable disable

namespace TravelCat2021.Models
{
    public partial class BadgeDetail
    {
        public int Id { get; set; }
        public string MemberId { get; set; }
        public int BadgeId { get; set; }

        public virtual Badge Badge { get; set; }
        public virtual Member Member { get; set; }
    }
}
