using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelCat2021.Interfaces;

namespace TravelCat2021.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ExampleController : ControllerBase
  {
    private readonly ICommentService _comment;
    public ExampleController(ICommentService comment)
    {
      //我DI啦
      _comment = comment;
    }

    [HttpGet]
    public async Task<List<string>> Get()
    {
      var res = await _comment.Get();
      return res;
    }

    public async Task Delete() { }
  }
}
