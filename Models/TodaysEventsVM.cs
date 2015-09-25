using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRCheckIn.Models
{
    public class TodaysEventsVM
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public int? AttendeeId { get; set; }
        public string AttendeeFirstName { get; set; }
        public string AttendeeLastName { get; set; }
        public string AttendeeEmail { get; set; } 
    }
}