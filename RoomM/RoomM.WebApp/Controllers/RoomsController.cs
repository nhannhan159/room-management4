using RoomM.Models;
using RoomM.Models.Rooms;
using RoomM.Business.Rooms;
using RoomM.WebApp.Models.Room;
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
            
            GetAllRoomModel m = new GetAllRoomModel();

            m.RoomCommons = RoomService.GetAll().Select(p => new RoomCommon
            {
                Id = p.Id,
                Name = p.Name,
                DateCreate = p.DateCreate
            }).ToList();

            return View(m);


            /* IList<Room> rooms = RoomService.GetAll();

            foreach (Room r in rooms) {
                Console.WriteLine("# " + r.Name);
            }


            return View(rooms);*/
        }

        public ActionResult Details(int id)
        {
            /*Room room = context.Rooms.SingleOrDefault(b => b.Id == id);

            if (room == null)
            {
                return HttpNotFound();
            }
            Room room = RoomService.GetByID(id);
            return View(room);*/

            return View();
        }

    }
}
