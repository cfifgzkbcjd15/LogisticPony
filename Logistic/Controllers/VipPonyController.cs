using Logistic.Code;
using Logistic.Data;
using Logistic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Logistic.Controllers
{

    [ApiController]
    [Route("api/VipPony")]
    public class VipPonyController : ControllerBase
    {
        private IDownload download;
        private VipPonyContext db;
        private IWebHostEnvironment env;

        public VipPonyController(IDownload _download, VipPonyContext _db,IWebHostEnvironment _env)
        {
            download = _download;
            db = _db;
            env = _env;
        }
        [HttpPost("FilerList")]
        public async Task GetFilterList(RequestFilterModel model)
        {
            if (model.IsMore)
            {

                IQueryable<DataPony> reports = db.DataPonies.Where(x => x.StartDate >= model.DateStart && x.EndDate <= model.DateEnd);

                if (model.AreaId > 0)
                    reports.Where(x => x.AreaId == model.AreaId);

                var data = await reports
                    .AsNoTracking()
                    .Select(x => new Reports
                    {
                        CategoryWork = x.CategoryWork,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        PointId = x.PointId,
                        RouteId = x.RouteId,
                        UserId = x.UserId,
                        Latitude = x.Latitude,
                        Longitde = x.Longitde
                    }).Take(50)
                .Skip(model.Page * 50)
                .OrderBy(x => x.Latitude)
                .ThenBy(x => x.Longitde)
                .ToListAsync();

                var buildingMap = new BuildingMap();
                var html = buildingMap.FiltrMap(data.Select(x => new List<decimal> {x.Latitude, x.Longitde }).ToList());
                var query = new ResponsePony
                {
                    Reports = data,
                    Html = html
                };

            }
            else
            {
                IQueryable<DataPony> reports = db.DataPonies.Where(x => x.StartDate >= model.DateStart && x.EndDate <= model.DateEnd);

                if (model.UserId > 0)
                    reports.Where(x => x.UserId == model.UserId);
                if (model.AreaId > 0)
                    reports.Where(x => x.AreaId == model.AreaId);

                var data = await reports
                    .AsNoTracking()
                    .Select(x => new Reports
                    {
                        CategoryWork = x.CategoryWork,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        PointId = x.PointId,
                        RouteId = x.RouteId,
                        UserId = x.UserId,
                        Latitude = x.Latitude,
                        Longitde = x.Longitde
                    }).Take(100)
                .Skip(model.Page * 100)
                .OrderBy(x => x.Latitude)
                .ThenBy(x => x.Longitde)
                .ToListAsync();

                var buildingMap = new BuildingMap();
                var html = buildingMap.FiltrMap(data.Select(x => new List<decimal> { x.Latitude, x.Longitde }).ToList());
                var query = new ResponsePony
                {
                    Reports = data,
                    Html = html
                };
            }
        }
        [HttpGet("GetFilter")]
        public async Task<ResponseFilterModel> Get()
        {
            var data = new ResponseFilterModel
            {
                AreaId = await db.DataPonies.AsNoTracking().Select(x => x.AreaId).Distinct().OrderBy(x => x).ToListAsync(),
                UserId = await db.DataPonies.AsNoTracking().Select(x => x.UserId).Distinct().OrderBy(x => x).ToListAsync()
            };
            return data; ;
        }
        [HttpPost]
        [RequestSizeLimit(100_000_000_000)]
        public async Task<string> SaveFile()
        {
            var uploadedFile = Request.Form.Files.First();
            try
            {
                if (uploadedFile != null)
                {
                    using (var stream = uploadedFile.OpenReadStream())
                    {
                        await download.ImportSte(stream);
                    }
                    return "Success";
                }
            }
            catch (Exception err)
            {
                return err.Message;
            }
            return "";
        }
    }

}
