using RoomM.Business;
using RoomM.Model.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.ConsoleApp
{
    // debug on console screen
    class Program
    {
        static void Main(string[] args)
        {
            RoomAsset dl = RoomAssetService.GetByID(1);
            Console.WriteLine(dl.ToString());
            dl.Amount = 0;
            RoomAssetService.Edit(dl);
            RoomAssetService.Save();
        }
    }
}
