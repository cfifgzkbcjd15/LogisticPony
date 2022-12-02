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

        public VipPonyController(IDownload _download, VipPonyContext _db)
        {
            download = _download;
            db = _db;
        }
        //[HttpPost("FilerList")]
        //public async Task GetFilterList(RequestFilterModel model)
        //{
        //    var data = new List<ResponsePony>();
        //    if (model.IsMore)
        //    {
        //        IQueryable<ResponsePony> query = db.DataPonies.Where(x=>x.StartDate>=model.DateStart&&x.EndDate<=model.DateEnd);
        //        if (model.AreaId>0)
                    
        //    }
        //    else
        //    {

        //    }
        //    var buildingMap = new BuildingMap();
        //    buildingMap.FiltrMap();
        //}
        [HttpGet("GetFilter")]
        public async Task<ResponseFilterModel> Get()
        {
            var data = new ResponseFilterModel
            {
                AreaId = await db.DataPonies.AsNoTracking().Select(x => x.AreaId).Distinct().OrderBy(x=>x).ToListAsync(),
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
                return "error";
            }
            return "";
        }
    }

}
