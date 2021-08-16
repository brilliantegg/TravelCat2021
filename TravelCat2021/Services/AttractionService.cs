using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelCat2021.Context;
using TravelCat2021.Interfaces;
using TravelCat2021.Models;
using TravelCat2021.ViewModels;
using TravelCat2021.Enums;

namespace TravelCat2021.Services
{
  public class AttractionService : IAttractionService
  {
    private readonly TravelDbContext _db;

    public AttractionService(TravelDbContext db)
    {
      _db = db;
    }

    //public async Task<AttractionDetailView> Get(int id)
    //{
    //  var res = new AttractionDetailView
    //  {
    //    AttractionId = 1,
    //    AttractionName = "宏亞食品巧克力觀光工廠",
    //    Description = "宏亞食品巧克力觀光工廠是一座以巧克力為主題的觀光工廠，建築設計、展場文字、陳列物、戶外景觀及相關造型皆與巧克力密不可分，全棟為綠建築，展場設計依照建築外觀之透光與否進行規劃，節能省碳，此外，展場更提供豐富的巧克力相關知識(含巧克力3500年歷史)為一寓教於樂之專業型廠館，是休閒娛樂絕佳去處。",
    //    Tel = "886-3-3656555",
    //    City = "桃園市",
    //    District = "八德區",
    //    Address = "桃園縣八德市建國路386號",
    //    Region = "北部",
    //    ZipCode = "33451",
    //    Px = 121.297187,
    //    Py = 24.943325
    //  };
    //  return res;
    //}

    public async Task<Activity> GetActivity(string id)
    {
      var target = await _db.Activities.Where(x => x.ActivityId == id).FirstOrDefaultAsync();
      return target;
    }

    public async Task<(ICollection<Activity> ActivityList, int Total)> GetActivityList(string search, string city, string district,
      int page, int limit, OrderType orderType = OrderType.Default)
    {
      var query = _db.Activities.AsQueryable();

      if (!string.IsNullOrEmpty(search))
      {
        query = query.Where(x => EF.Functions.Like(x.District, $"%{search}%") ||
        EF.Functions.Like(x.City, $"%{search}%") ||
        EF.Functions.Like(x.AddressDetail, $"%{search}%") ||
        EF.Functions.Like(x.ActivityTitle, $"%{search}%"));
      }
      if (!string.IsNullOrEmpty(city))
      {
        query = query.Where(x => EF.Functions.Like(x.City, $"%{city}%"));
      }
      if (!string.IsNullOrEmpty(district))
      {
        query = query.Where(x => EF.Functions.Like(x.District, $"%{district}%"));
      }

      switch (orderType)
      {
        case OrderType.City:
          query = query.OrderBy(x => x.City);
          break;
        case OrderType.BeginDate:
          query = query.OrderBy(x => x.BeginDate);
          break;
        case OrderType.EndDate:
          query = query.OrderBy(x => x.EndDate);
          break;
        case OrderType.Comment:
          var commentQuery = _db.Comments.AsNoTracking();
          query = query.OrderByDescending(x => commentQuery.Count(y => y.TourismId == x.ActivityId));
          break;
        default:
          break;
      }

      var activityList = await query.Skip(limit * (page - 1)).Take(limit).ToListAsync();
      return (activityList, await query.CountAsync());
    }

    public async Task<Hotel> GetHotel(string id)
    {
      var target = await _db.Hotels.Where(x => x.HotelId == id).FirstOrDefaultAsync();
      return target;
    }

    public async Task<Restaurant> GetRestaurant(string id)
    {
      var target = await _db.Restaurants.Where(x => x.RestaurantId == id).FirstOrDefaultAsync();
      return target;
    }

    public async Task<Spot> GetSpot(string id)
    {
      var target = await _db.Spots.Where(x => x.SpotId == id).FirstOrDefaultAsync();
      return target;
    }
  }
}
