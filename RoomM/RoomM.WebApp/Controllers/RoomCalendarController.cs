using RoomM.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoomM.WebApp.Controllers
{
    public class RoomCalendarController : Controller
    {
        //
        // GET: /RoomCalendar/
        public ActionResult Index(string name, int number = 100)
        {
            // ViewData.Model = greeting;
            // ViewData.Add("get", "This is get string");
            /* ViewData.Add("one", "one value");
            ViewData.Add("two", "two value");
            ViewData.Add("three", "three value");
            */

            var roomCals = RoomCalendarService.GetAll();

            ViewResult particalR = View("next");
            return View(roomCals);


            // return HttpUtility.HtmlEncode("Hello " + name + ", number: " + number);


        }

        //
        // GET: /RoomCalendar/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /RoomCalendar/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /RoomCalendar/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /RoomCalendar/Edit/5

        public ActionResult Edit(int id)
        {


            return View();
        }

        //
        // POST: /RoomCalendar/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /RoomCalendar/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /RoomCalendar/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
