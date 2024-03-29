﻿using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Logistic.Data;
using Logistic.Models;
using System.Globalization;

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


        public async Task ImportSte(Stream stream)
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
            while (rowIndex != 1)
            {
                //var date = Convert.ToDateTime(sheet.GetRow(rowIndex).GetCell(4).ToString());
                //var date2 = Convert.ToDateTime(sheet.GetRow(rowIndex).GetCell(5).ToString());
                //var date3 = Convert.ToDateTime(sheet.GetRow(rowIndex).GetCell(9).ToString());
                pony.Add(new DataPony
                {
                    Id = Guid.NewGuid(),
                    CategoryWork = Convert.ToInt16(sheet.GetRow(rowIndex).GetCell(0).ToString()),
                    AreaId = Convert.ToInt16(sheet.GetRow(rowIndex).GetCell(1).ToString()),
                    SubareaId = Convert.ToInt16(sheet.GetRow(rowIndex).GetCell(2).ToString()),
                    RouteId = new Guid(sheet.GetRow(rowIndex).GetCell(3).ToString()),
                    StartDate = Convert.ToDateTime(sheet.GetRow(rowIndex).GetCell(4).ToString()),
                    EndDate = Convert.ToDateTime(sheet.GetRow(rowIndex).GetCell(5).ToString()),
                    PointId = new Guid(sheet.GetRow(rowIndex).GetCell(6).ToString()),
                    Latitude = decimal.Parse(sheet.GetRow(rowIndex).GetCell(7).ToString(), CultureInfo.InvariantCulture),
                    Longitde = decimal.Parse(sheet.GetRow(rowIndex).GetCell(8).ToString(), CultureInfo.InvariantCulture),
                    Date = Convert.ToDateTime(sheet.GetRow(rowIndex).GetCell(9).ToString()),
                    UserId = Convert.ToInt16(sheet.GetRow(rowIndex).GetCell(10).ToString()),
                    OrderNum = Convert.ToInt16(sheet.GetRow(rowIndex).GetCell(11).ToString()),

                });
                rowIndex++;
            }
            db.DataPonies.AddRange(pony);
            db.SaveChanges();
        }
    }
}
