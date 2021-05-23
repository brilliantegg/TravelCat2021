using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelCat2021.Interfaces
{
  public interface ICommentService
  {
    Task<List<string>> Get();
  }
}
