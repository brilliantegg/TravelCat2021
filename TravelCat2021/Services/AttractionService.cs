using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelCat2021.Interfaces;
using TravelCat2021.ViewModels;

namespace TravelCat2021.Services
{
  public class AttractionService : IAttractionService
  {
    public async Task<AttractionDetailView> Get(int id)
    {
      var res = new AttractionDetailView
      {
        AttractionId = 1,
        AttractionName = "宏亞食品巧克力觀光工廠",
        Description = "宏亞食品巧克力觀光工廠是一座以巧克力為主題的觀光工廠，建築設計、展場文字、陳列物、戶外景觀及相關造型皆與巧克力密不可分，全棟為綠建築，展場設計依照建築外觀之透光與否進行規劃，節能省碳，此外，展場更提供豐富的巧克力相關知識(含巧克力3500年歷史)為一寓教於樂之專業型廠館，是休閒娛樂絕佳去處。",
        Tel = "886-3-3656555",
        City = "桃園市",
        District = "八德區",
        Address = "桃園縣八德市建國路386號",
        Region = "北部",
        ZipCode = "33451",
        Px = 121.297187,
        Py = 24.943325
      };
      return res;
    }

  }


}
