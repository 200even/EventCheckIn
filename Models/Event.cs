using System;
using System.Collections.Generic;

namespace QRCheckIn.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan EvenTimeSpan => EndTime - StartTime;
        public List<Attendee> Attendees { get; set; } 
    }
}