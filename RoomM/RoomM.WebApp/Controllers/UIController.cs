using RoomM.Business;
using RoomM.Models.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoomM.WebApp.Controllers
{
    public class UIController : Controller
    {
        //
        // GET: /UI/

        
        public ActionResult Index()
        {
            var data = StaffService.GetByID(1);
            return View(data);
        }


        [HttpPost]
        public string ProcessForm(Staff obj)
        {
            var data = StaffService.GetByID((int)obj.ID);
            data.Name = obj.Name;
            // save to db
            return "<h2>Staff updated successfully!</h2>";
        }


        [HttpPost]
        public string ProcessLink()
        {
            return "<h2>This is a response from action method!</h2>";
        }

        //
        // GET: /UI/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /UI/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UI/Create

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
        // GET: /UI/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /UI/Edit/5

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
        // GET: /UI/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /UI/Delete/5

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
