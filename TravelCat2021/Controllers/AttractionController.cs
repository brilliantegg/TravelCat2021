using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelCat2021.Interfaces;
using TravelCat2021.Models;
using TravelCat2021.ViewModels;

namespace TravelCat2021.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AttractionController : ControllerBase
  {
    private readonly IAttractionService _attraction;
    private readonly IFileService _file;

    public AttractionController(IAttractionService attraction, IFileService file)
    {
      _attraction = attraction;
      _file = file;
    }

    // GET: api/<AttractionController>
    //[HttpGet]
    //public async Task<ICollection<string>> Get()
    //{
    //  return new List<string> { "value" };
    //}


    /// <summary>
    /// 依編號取得景點
    /// </summary>
    /// <param name="id">景點id</param>
    /// <returns></returns>
    // GET api/<AttractionController>/5
    [HttpGet("Activity/{id}")]
    public async Task<Activity> Get(string id)
    {
      var res = await _attraction.Get(id);
      return res;
    }

    /// <summary>
    /// 依編號取得景點圖片
    /// </summary>
    /// <param name="id">景點id</param>
    /// <returns></returns>
    [HttpGet("Activity/{id}/Photo")]
    public async Task<ICollection<string>> Photo(string id)
    {
      var res = await _file.GetTourismPhoto(id);
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
