using System;
using System.Collections.Generic;

#nullable disable

namespace TravelCat2021.Models
{
    public partial class FollowList
    {
        public int Id { get; set; }
        public string MemberId { get; set; }
        public string FollowedId { get; set; }
        public DateTime FollowDate { get; set; }

        public virtual Member Member { get; set; }
    }
}
