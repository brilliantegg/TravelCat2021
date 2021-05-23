using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelCat2021.Interfaces;

namespace TravelCat2021.Services
{
  public class CommentService : ICommentService
  {
    public async Task<List<string>> Get()
    {
      return new List<string> { "第一則", "第二則" };
    }
  }
}
