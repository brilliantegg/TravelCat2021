using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelCat2021.Enums;
using TravelCat2021.Models;
using TravelCat2021.ViewModels;

namespace TravelCat2021.Interfaces
{
  public interface IAttractionService
  {
    Task<Activity> GetActivity(string id);

    /// <summary>
    /// 取得景點清單
    /// </summary>
    /// <param name="search">關鍵字搜尋(會搜尋名稱、縣市、行政區、地址)</param>
    /// <param name="city">若只要特定縣市</param>
    /// <param name="district">若只要特定行政區(要給city)</param>
    /// <param name="orderType">排序方式</param>
    /// <param name="page">頁數(預設為1)</param>
    /// <param name="limit">每頁數量(預設10)</param>
    /// <returns></returns>
    Task<(ICollection<Activity> ActivityList, int Total)> GetActivityList(string search, string city, string district,
      int page, int limit, OrderType orderType = OrderType.Default);
  }
}
