using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelCat2021.Context;
using TravelCat2021.Interfaces;

namespace TravelCat2021.Services
{
  public class FileService : IFileService
  {
    private readonly TravelDbContext _db;

    public FileService(TravelDbContext db)
    {
      _db = db;
    }

    public async Task<ICollection<string>> GetTourismPhoto(string id)
    {
      var target = await _db.TourismPhotos.Where(x => x.TourismId == id)
        .Select(x => x.PhotoUrl).ToListAsync();
      return target;
    }

  }
}
