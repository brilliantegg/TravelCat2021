using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TravelCat2021.Interfaces;

namespace TravelCat2021.Services
{
  public class CommentService : ICommentService
  {
    public async Task<List<string>> Get()
    {
      //隨便亂打
      return new List<string> { "第一則", "第二則","第三則" };
    }

    public async Task<HttpResponseMessage> Delete() 
    {
      return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
    }
  }
}
