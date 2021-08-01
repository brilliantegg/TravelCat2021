using System;
using System.Collections.Generic;

#nullable disable

namespace TravelCat2021.Models
{
    public partial class CollectionType
    {
        public CollectionType()
        {
            CollectionsDetails = new HashSet<CollectionsDetail>();
        }

        public int CollectionTypeId { get; set; }
        public string CollectionTypeTitle { get; set; }

        public virtual ICollection<CollectionsDetail> CollectionsDetails { get; set; }
    }
}
