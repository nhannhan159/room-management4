﻿using RoomM.Models;
using RoomM.Models.Entities;
using RoomM.Business.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoomM.WebApp.Controllers
{
    public class RoomsController : Controller
    {
      
        public ActionResult Index()
        {
            
            IList<Room> rooms = RoomService.GetAll();

            foreach (Room r in rooms) {
                Console.WriteLine("# " + r.Name);
            }


            return View(rooms);
        }

        public ActionResult Details(int id)
        {
            Room room = RoomService.GetByID(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);

            return View();
        }

    }
}
