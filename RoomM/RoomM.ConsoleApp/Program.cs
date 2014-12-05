using RoomM.Business;
using RoomM.Models.Rooms;
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
            AssetsReportToExcel reportDemo = new AssetsReportToExcel("sgu university", "roomM", "templates/book1.xls");
            reportDemo.setupExport();
            reportDemo.save("reports/myreport.xls");
        }
    }
}
