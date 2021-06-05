using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelCat2021.ViewModels
{
  public class AttractionView
  {
  }
  public class AttractionDetailView
  {
    public int AttractionId { get; set; }
    public string AttractionName { get; set; }
    public string Description { get; set; }
    public string Tel { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string Address { get; set; }
    public string ZipCode { get; set; }
    public string Region { get; set; }
    public double? Px { get; set; }
    public double? Py { get; set; }
  }
}
