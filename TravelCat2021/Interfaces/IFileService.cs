using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelCat2021.Interfaces
{
  public interface IFileService
  {
    Task<ICollection<string>> GetTourismPhoto(string id);
  }
}
