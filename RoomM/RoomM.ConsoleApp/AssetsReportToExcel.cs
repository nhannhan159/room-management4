using NPOI.SS.UserModel;
using RoomM.Models.Assets;
using RoomM.Models.Rooms;
using RoomM.Repositories.Assets;
using RoomM.Repositories.RepositoryFramework;
using RoomM.Repositories.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.ConsoleApp
{
    public class AssetsReportToExcel : ReportToExcel
    {

        IRoomAssetRepository roomAssetsRepo = RepositoryFactory.GetRepository<IRoomAssetRepository, RoomAsset>();

        public AssetsReportToExcel(String companyName, String subject, String template)
            : base(companyName, subject, template)
        {
            
        }


        public override void setupExport()
        {
            IList<RoomAsset> roomAssetsList = roomAssetsRepo.GetAll();

            Sheet sheet1 = hssfworkbook.GetSheet("Sheet1");

            int startRow = 3;
            int index = 1;

            foreach(RoomAsset rAsset in roomAssetsList) 
            {
                if (null != sheet1.GetRow(startRow).GetCell(1))
                    sheet1.GetRow(startRow).GetCell(1).SetCellValue(index);
                else
                    sheet1.GetRow(startRow).CreateCell(1).SetCellValue(index);

                if (null != sheet1.GetRow(startRow).GetCell(2))
                    sheet1.GetRow(startRow).GetCell(2).SetCellValue(rAsset.ID);
                else
                    sheet1.GetRow(startRow).CreateCell(2).SetCellValue(rAsset.ID);

                if (null != sheet1.GetRow(startRow).GetCell(3))
                    sheet1.GetRow(startRow).GetCell(3).SetCellValue(rAsset.Asset.Name);
                else
                    sheet1.GetRow(startRow).CreateCell(3).SetCellValue(rAsset.Asset.Name);

                if (null != sheet1.GetRow(startRow).GetCell(4))
                    sheet1.GetRow(startRow).GetCell(4).SetCellValue(rAsset.Room.Name);
                else
                    sheet1.GetRow(startRow).CreateCell(4).SetCellValue(rAsset.Room.Name);

                

                startRow++;
                index++;
            }

            //Force excel to recalculate all the formula while open
            sheet1.ForceFormulaRecalculation = true;
        }
    }
}
