using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventCheckIn.Models;
using System.Net.Mail;
using System.Configuration;

namespace EventCheckIn.Controllers
{
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events
        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }

        // GET: ChooseEvent
        public ActionResult ChooseEvent(int? id)
        {
            DateTime time = DateTime.Now.AddHours(-5);
            var todaysEvents = db.Events.Where(e => DbFunctions.TruncateTime(e.StartTime) == time.Date);
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            List<TodaysEventsVM> MyEvents = new List<TodaysEventsVM>();
            foreach (var e in todaysEvents)
            {
                MyEvents.Add(new TodaysEventsVM() {AttendeeId = id, EventId = e.Id, EventName = e.Name});
            }
            return View(MyEvents);
        }

        // POST: ChooseEvent
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChooseEvent(TodaysEventsVM myEvent)
        {
            if (ModelState.IsValid)
            {
                var attendee = db.Attendees.FirstOrDefault(a => a.Id == myEvent.AttendeeId);
                Event thisEvent = db.Events.FirstOrDefault(e => e.Id == myEvent.EventId);
                if(thisEvent.Attendees != null && thisEvent.Attendees.Any(a => a.Id == attendee.Id))
                {
                    TempData["message"] = $"{attendee.FirstName} has already checked into this event({thisEvent.Name}).";
                    return RedirectToAction("ChooseEvent");
                }
                attendee.Events.Add(thisEvent);
                db.SaveChanges();
                SendConfirmation(attendee, thisEvent);
                return RedirectToAction("Confirmation");
            }
           
            return View();
        }

        [ChildActionOnly]
        public ActionResult TempMessage()
        {
            return PartialView();
        }

        public ActionResult Confirmation()
        {
            return View();
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,StartTime,EndTime")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,StartTime,EndTime")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FormTest()
        {
            return View();
        }

        public static void SendConfirmation(Attendee attendee, Event myEvent)
        {
            string email = ConfigurationManager.AppSettings["email"];
            string password = ConfigurationManager.AppSettings["password"];
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(email);
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(mail.From.ToString(), password);
            smtp.Host = "smtp.gmail.com";
            mail.To.Add(new MailAddress($"{attendee.Email}"));
            mail.Subject = "Thanks for checking in!";
            mail.IsBodyHtml = true;
            string st = $"<div align='center'><img src='http://i.imgur.com/DSS1t1X.jpg' /></div><br /><div align='justified'><p>Your check-in for {myEvent.Name} is confirmed. You have attended {attendee.Events.Count()} events so far. <strong>Thank you</strong> for supporting the Little Rock tech scene!</p></div><footer><sub>Event check-in backend services created for Techtober by <a href='mailto:esfergus@gmail.com?Subject=Event%20Check-in%20Service' target='_top'>Scott Ferguson</a> in Little Rock, AR.</sub></footer>";
            mail.Body = st;
            smtp.Send(mail);
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
