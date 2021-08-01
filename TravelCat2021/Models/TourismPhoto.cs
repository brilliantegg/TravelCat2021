using System;
using System.Collections.Generic;

#nullable disable

namespace TravelCat2021.Models
{
    public partial class TourismPhoto
    {
        public long Id { get; set; }
        public string TourismId { get; set; }
        public string PhotoUrl { get; set; }
    }
}
