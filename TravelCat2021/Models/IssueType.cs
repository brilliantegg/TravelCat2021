using System;
using System.Collections.Generic;

#nullable disable

namespace TravelCat2021.Models
{
    public partial class IssueType
    {
        public IssueType()
        {
            Issues = new HashSet<Issue>();
        }

        public int IssueId { get; set; }
        public string IssueName { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }
    }
}
