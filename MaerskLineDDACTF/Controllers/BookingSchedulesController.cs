using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MaerskLineDDACTF.Models;

namespace MaerskLineDDACTF.Controllers
{
    public class BookingSchedulesController : Controller
    {
        private MaerskLineDDACTFContext db = new MaerskLineDDACTFContext();

        // GET: BookingSchedules
        public ActionResult Index()
        {
            var bookingSchedules = db.BookingSchedules.Include(b => b.Container).Include(b => b.Ship).Include(b => b.Yard).Include(b => b.Yard1);
            return View(bookingSchedules.ToList());
        }

        // GET: BookingSchedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingSchedule bookingSchedule = db.BookingSchedules.Find(id);
            if (bookingSchedule == null)
            {
                return HttpNotFound();
            }
            return View(bookingSchedule);
        }

        // GET: BookingSchedules/Create
        public ActionResult Create()
        {
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "Description");
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName");
            ViewBag.YardID = new SelectList(db.Yards, "YardID", "YardName");
            ViewBag.Yard1ID = new SelectList(db.Yards, "YardID", "YardName");
            return View();
        }

        // POST: BookingSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingScheduleID,ShipID,ContainerID,DepartureDate,ArrivalDate,YardID,Yard1ID,TotalPrice")] BookingSchedule bookingSchedule)
        {
            if (ModelState.IsValid)
            {
                db.BookingSchedules.Add(bookingSchedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "Description", bookingSchedule.ContainerID);
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName", bookingSchedule.ShipID);
            ViewBag.YardID = new SelectList(db.Yards, "YardID", "YardName", bookingSchedule.YardID);
            ViewBag.Yard1ID = new SelectList(db.Yards, "YardID", "YardName", bookingSchedule.Yard1ID);
            return View(bookingSchedule);
        }

        // GET: BookingSchedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingSchedule bookingSchedule = db.BookingSchedules.Find(id);
            if (bookingSchedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "Description", bookingSchedule.ContainerID);
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName", bookingSchedule.ShipID);
            ViewBag.YardID = new SelectList(db.Yards, "YardID", "YardName", bookingSchedule.YardID);
            ViewBag.Yard1ID = new SelectList(db.Yards, "YardID", "YardName", bookingSchedule.Yard1ID);
            return View(bookingSchedule);
        }

        // POST: BookingSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingScheduleID,ShipID,ContainerID,DepartureDate,ArrivalDate,YardID,Yard1ID,TotalPrice")] BookingSchedule bookingSchedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingSchedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "Description", bookingSchedule.ContainerID);
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName", bookingSchedule.ShipID);
            ViewBag.YardID = new SelectList(db.Yards, "YardID", "YardName", bookingSchedule.YardID);
            ViewBag.Yard1ID = new SelectList(db.Yards, "YardID", "YardName", bookingSchedule.Yard1ID);
            return View(bookingSchedule);
        }

        // GET: BookingSchedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingSchedule bookingSchedule = db.BookingSchedules.Find(id);
            if (bookingSchedule == null)
            {
                return HttpNotFound();
            }
            return View(bookingSchedule);
        }

        // POST: BookingSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingSchedule bookingSchedule = db.BookingSchedules.Find(id);
            db.BookingSchedules.Remove(bookingSchedule);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
