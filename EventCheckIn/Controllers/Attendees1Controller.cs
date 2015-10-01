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
using System.Net.Http.Headers;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web;
using System.Net.Mail;
using System.Configuration;

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
        public dynamic PostAttendee(Attendee attendee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try {
                db.Attendees.Add(attendee);
                db.SaveChanges();
                var qrCode = AttendeesController.GenerateCode(attendee.Id);
                attendee.QrCode = qrCode;
                db.SaveChanges();
                var memoryStream = GenerateBadge(attendee);
                SendEmail(memoryStream, attendee);
                //string result = $"Thanks {attendee.FirstName}! You should receive a confirmation email shortly.";
                //var resp = new HttpResponseMessage(HttpStatusCode.OK);
                //resp.Content = new StringContent(result, System.Text.Encoding.UTF8, "text/plain");
                //return resp;
                var response = new HttpResponseMessage();
                response.Content = new StringContent($"<html><body><h1>Thanks {attendee.FirstName}!</h1><h2>You should receive a confirmation email shortly.</h2></body></html>");
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
                return response;
            }
            catch
            {
                return BadRequest();
            }

        }

        private static MemoryStream GenerateBadge(Attendee attendee)
        {
            Document doc = new Document(PageSize.POSTCARD, 10, 10, 42, 35);
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
            doc.Open();
            Uri imageLocation = new Uri("http://static1.squarespace.com/static/5421d09de4b012de014df4dc/t/55e6ffb1e4b0bef28928ccf4/1441202099710/");
            Image logo = Image.GetInstance(imageLocation);
            logo.Alignment = Element.ALIGN_CENTER;
            logo.ScaleAbsolute(120f, 155.25f);
            doc.Add(logo);
            Paragraph name = new Paragraph($"{attendee.FirstName} {attendee.LastName}");
            name.Alignment = Element.ALIGN_CENTER;
            doc.Add(name);
            Paragraph email = new Paragraph($"{attendee.Email}");
            email.Alignment = Element.ALIGN_CENTER;
            doc.Add(email);
            Image qr = Image.GetInstance(attendee.QrCode);
            qr.Alignment = Element.ALIGN_CENTER;
            doc.Add(qr);
            writer.CloseStream = false;
            doc.Close();
            memoryStream.Position = 0;
            return memoryStream;
        }

        public static void SendEmail(MemoryStream memoryStream, Attendee attendee)
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
            mail.Subject = "Thanks for registering for Techtober!";
            mail.IsBodyHtml = true;
            string st = "Your registration is confirmed. Please have the attached checkin document ready when you arrive at each event.";
            mail.Body = st;
            Attachment attach = new Attachment(memoryStream, new System.Net.Mime.ContentType("application/pdf"));
            mail.Attachments.Add(attach);
            smtp.Send(mail);
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