using Logistic.Code;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic.Controllers
{
    
    [ApiController]
    [Route("api/VipPony")]
    public class VipPonyController : ControllerBase
    {
        private IDownload download;

        public VipPonyController(IDownload _download)
        {
            download = _download;
        }
        [HttpGet]
        public string Test()
        {
            var test = new BuildingMap();
            test.FiltrMap();
            return "";
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
            catch(Exception err)
            {
                return "error";
            }
            return "";
        }
    }

}
