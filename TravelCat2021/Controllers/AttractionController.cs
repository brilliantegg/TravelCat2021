using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelCat2021.Interfaces;
using TravelCat2021.ViewModels;

namespace TravelCat2021.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AttractionController : ControllerBase
  {
    private readonly IAttractionService _attraction;

    public AttractionController(IAttractionService attraction)
    {
      _attraction = attraction;
    }

    // GET: api/<AttractionController>
    //[HttpGet]
    //public async Task<ICollection<string>> Get()
    //{
    //  return new List<string> { "value" };
    //}


    /// <summary>
    /// 依編號取得景點(現在只有1號)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // GET api/<AttractionController>/5
    [HttpGet("{id}")]
    public async Task<AttractionDetailView> Get(int id = 1)
    {
      var res = await _attraction.Get(id);
      return res;
    }

    //// POST api/<AttractionController>
    //[HttpPost]
    //public void Post([FromBody] string value)
    //{
    //}

    //// PUT api/<AttractionController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    //// DELETE api/<AttractionController>/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}
  }
}
