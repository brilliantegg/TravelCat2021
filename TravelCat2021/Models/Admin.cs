using System;
using System.Collections.Generic;

#nullable disable

namespace TravelCat2021.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Issues = new HashSet<Issue>();
        }

        public int AdminId { get; set; }
        public string AdminAccount { get; set; }
        public string AdminPassword { get; set; }
        public string AdminEmail { get; set; }
        public bool? EmailConfirmed { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }
    }
}
