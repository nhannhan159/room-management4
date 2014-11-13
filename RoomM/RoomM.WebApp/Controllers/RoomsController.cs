using RoomM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoomM.Models.Rooms;
using System.Net;
using RoomM.Business;

namespace RoomM.WebApp.Controllers
{
    public class RoomsController : Controller
    {
      
        public ActionResult Index(string roomType, string searchString)
        {
            IList<Room> rooms = RoomService.GetAll();
            IList<Room> roomsR = new List<Room>();


            ViewBag.roomType = new SelectList(RoomService.GetAllRoomTypeName());


            if (!String.IsNullOrEmpty(searchString))
            {
                // rooms = rooms.Where(s => s.Name.Contains(searchString));


                foreach (Room r in rooms)
                {
                    if (r.Name.Contains(searchString))
                        roomsR.Add(r);
                }

                return View(roomsR);
            }
            else
            {


                foreach (Room r in rooms)
                {
                    Console.WriteLine("# " + r.Name);
                }

                return View(roomsR);
            }
        }

      

        public ActionResult Details(int id)
        {
            Room room = RoomService.GetByID(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        //
        // GET: /Rooms/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Room room = RoomService.GetByID(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,DateCreate,RoomTypeId")] Room room)
        {
            if (ModelState.IsValid)
            {
                // RoomService.Save(room);
                // db.Entry(student).State = EntityState.Modified;
                // db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(room);
        }


        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Room room = RoomService.GetByID(id);
            if (room == null) 
            {
                return HttpNotFound();
            }
            return View(room);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Room room = RoomService.GetByID(id);
            // remove room


            return RedirectToAction("Index");
        }
    }
}
