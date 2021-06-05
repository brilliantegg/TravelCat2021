using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelCat2021.ViewModels;

namespace TravelCat2021.Interfaces
{
  public interface IAttractionService
  {
    Task<AttractionDetailView> Get(int id);
  }
}
