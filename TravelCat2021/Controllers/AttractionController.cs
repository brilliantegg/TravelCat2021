using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelCat2021.Enums;
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
    public async Task<Activity> GetActivity(string id)
    {
      var res = await _attraction.GetActivity(id);
      return res;
    }

    /// <summary>
    /// 景點清單
    /// </summary>
    /// <remarks>
    /// 預設每頁10筆
    /// 
    /// 說明：
    /// - 頁數不給的話預設為1
    /// - 每頁個數不給的話預設為10
    /// - 排序類別目前除了4(comment)以外，皆為順向排序(asc)
    /// 
    /// 搜尋：
    /// - search可搜尋標題、城市、行政區、地址
    /// - city搜尋城市
    /// - district搜尋行政區
    /// - city建議可以跟district一起使用
    /// 
    /// 排序：
    /// 0 預設
    /// 1 城市
    /// 2 開始日期
    /// 3 結束日期
    /// 4 留言數 ( 努力中QQ )
    /// </remarks>
    /// <param name="search">搜尋關鍵字</param>
    /// <param name="city">城市</param>
    /// <param name="district">行政區</param>
    /// <param name="page">頁數</param>
    /// <param name="limit">每頁個數</param>
    /// <param name="orderType">排序類別</param>
    /// <returns></returns>
    [HttpGet("ActivityList")]
    public async Task<AttractionListView<Activity>> GetActivityList(string search, string city, string district, int page = 1, int limit = 10,
      OrderType orderType = OrderType.Default)
    {
      var res = new AttractionListView<Activity>();
      (res.Attractions, res.Total) = await _attraction.GetActivityList(search, city, district, page, limit, orderType);
      return res;
    }

    /// <summary>
    /// 依編號取得景點圖片
    /// </summary>
    /// <param name="id">景點id</param>
    /// <returns></returns>
    [HttpGet("Photo/{id}")]
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
