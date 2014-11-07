using RoomM.Business.Rooms;
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
            RoomDevice dl = RoomDeviceService.GetByID(1);
            Console.WriteLine(dl.ToString());
            dl.Amount = 0;
            RoomDeviceService.Edit(dl);
            RoomDeviceService.Save();
        }
    }
}
