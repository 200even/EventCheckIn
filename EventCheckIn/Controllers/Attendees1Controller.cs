using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EventCheckIn.Models;

namespace EventCheckIn.Controllers
{
    public class Attendees1Controller : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Attendees1
        public IQueryable<Attendee> GetAttendees()
        {
            return db.Attendees;
        }

        // GET: api/Attendees1/5
        [ResponseType(typeof(Attendee))]
        public IHttpActionResult GetAttendee(int id)
        {
            Attendee attendee = db.Attendees.Find(id);
            if (attendee == null)
            {
                return NotFound();
            }

            return Ok(attendee);
        }

        // PUT: api/Attendees1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAttendee(int id, Attendee attendee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != attendee.Id)
            {
                return BadRequest();
            }

            db.Entry(attendee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Attendees1
        [ResponseType(typeof(Attendee))]
        public IHttpActionResult PostAttendee(Attendee attendee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Attendees.Add(attendee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = attendee.Id }, attendee);
        }

        // DELETE: api/Attendees1/5
        [ResponseType(typeof(Attendee))]
        public IHttpActionResult DeleteAttendee(int id)
        {
            Attendee attendee = db.Attendees.Find(id);
            if (attendee == null)
            {
                return NotFound();
            }

            db.Attendees.Remove(attendee);
            db.SaveChanges();

            return Ok(attendee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AttendeeExists(int id)
        {
            return db.Attendees.Count(e => e.Id == id) > 0;
        }
    }
}