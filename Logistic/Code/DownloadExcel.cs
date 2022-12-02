using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Logistic.Data;

namespace Logistic.Code
{
    public class DownloadExcel : IDownload
    {
        VipPonyContext db;

        public DownloadExcel(
            VipPonyContext _db
            )
        {
            db = _db;
        }


        public void ImportSte(Stream stream)
        {
            XSSFWorkbook hssfwb;
            //using (FileStream file = new FileStream(local_file, FileMode.Open, FileAccess.Read))
            {
                hssfwb = new XSSFWorkbook(stream);
            }
            ISheet sheet = hssfwb.GetSheetAt(0);
            var rowIndex = 0;
            var pony = new List<DataPony>();
            db.DataPonies.RemoveRange(db.DataPonies);
            db.SaveChanges();
            while (rowIndex == 10000)
            {
                pony.Add(new DataPony
                {
                    Id = Guid.NewGuid(),
                    CategoryWork = Convert.ToInt16(sheet.GetRow(rowIndex).GetCell(1)),
                    //AreaId = Convert.ToInt16(sheet.GetRow(rowIndex).GetCell(2)),
                    //SubareaId = Convert.ToInt16(sheet.GetRow(rowIndex).GetCell(3)),
                    //RouteId = new Guid(sheet.GetRow(rowIndex).GetCell(4).ToString()),
                    //StartDate = sheet.GetRow(rowIndex).GetCell(5).ToString(),
                    //EndDate = sheet.GetRow(rowIndex).GetCell(6).ToString(),
                    //PointId = new Guid(sheet.GetRow(rowIndex).GetCell(7).ToString()),
                    //Latitude = Convert.ToDecimal(sheet.GetRow(rowIndex).GetCell(8)),
                    //Longitde = Convert.ToDecimal(sheet.GetRow(rowIndex).GetCell(9)),
                    //Date = Convert.ToDateTime(sheet.GetRow(rowIndex).GetCell(10)),
                    //UserId = Convert.ToInt16(sheet.GetRow(rowIndex).GetCell(11).ToString()),
                    //OrderNum = Convert.ToInt16(sheet.GetRow(rowIndex).GetCell(12).ToString()),

                });
                rowIndex++;
            }
            db.DataPonies.AddRange(pony);
            db.SaveChanges();
        }
    }
}
