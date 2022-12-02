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
        [HttpPost]
        [RequestSizeLimit(100_000_000_000)]
        public string SaveFile()
        {
            var uploadedFile = Request.Form.Files.First();
            try
            {
                if (uploadedFile != null)
                {
                    using (var stream = uploadedFile.OpenReadStream())
                    {
                        download.ImportSte(stream);
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
