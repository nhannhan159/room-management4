﻿using RoomM.Model;
using RoomM.Model.Rooms;
using RoomM.Models.Devices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Begin");
            Database.SetInitializer(new RoomMgrContextCustomInitializer());        
            using (var db = new EFDataContext())
            {
                db.Database.Initialize(false);
            }
            Console.WriteLine("Successfully");
            Console.ReadLine();
        }
    }
}
