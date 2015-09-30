using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Newtonsoft.Json;
using System.Data.Entity;

namespace EventCheckIn.Models
{
    public class Attendee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string QrCode { get; set; }

        [JsonIgnore]
        public virtual List<Event> Events { get; set; } 
    }

}