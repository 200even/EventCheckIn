using QRCheckIn.Models;

namespace QRCheckIn.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QRCheckIn.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(QRCheckIn.Models.ApplicationDbContext context)
        {
            context.Attendees.AddOrUpdate(
                a => a.Email,
                new Attendee { FirstName = "Scott", LastName = "Ferguson", Email = "esfergus@gmail.com"}
                );
            context.Events.AddOrUpdate(
                e => new { e.Name, e.StartTime },
                new Event { Name = "Made by Few (Day 1)", StartTime = new DateTime(2015, 10, 01), EndTime = new DateTime(2015, 10, 01, 23, 59, 59) }
                , new Event { Name = "Made by Few (Day 2)", StartTime = new DateTime(2015, 10, 02), EndTime = new DateTime(2015, 10, 02, 23, 59, 59) }
                , new Event { Name = "Made by Few (Day 3)", StartTime = new DateTime(2015, 10, 03), EndTime = new DateTime(2015, 10, 03, 23, 59, 59) }
                , new Event { Name = "East Night in Open House", StartTime = new DateTime(2015, 10, 01), EndTime = new DateTime(2015, 10, 01, 23, 59, 59) }
                , new Event { Name = "UA Grant to Train Teachers in Computer Science", StartTime = new DateTime(2015, 10, 01), EndTime = new DateTime(2015, 10, 01, 23, 59, 59) }
                , new Event { Name = "IT Executive Forum for High School Students", StartTime = new DateTime(2015, 10, 01), EndTime = new DateTime(2015, 10, 01, 23, 59, 59) }
                , new Event { Name = "2015 Ozark Mountain Brawl (Day 1)", StartTime = new DateTime(2015, 10, 02), EndTime = new DateTime(2015, 10, 02, 23, 59, 59) }
                , new Event { Name = "2015 Ozark Mountain Brawl (Day 2)", StartTime = new DateTime(2015, 10, 03), EndTime = new DateTime(2015, 10, 03, 23, 59, 59) }
                , new Event { Name = "AMS Manufacturing Day", StartTime = new DateTime(2015, 10, 02), EndTime = new DateTime(2015, 10, 02, 23, 59, 59) }
                , new Event { Name = "Forge Idea", StartTime = new DateTime(2015, 10, 03), EndTime = new DateTime(2015, 10, 03, 23, 59, 59) }
                , new Event { Name = "AR STEM Coalition Meeting", StartTime = new DateTime(2015, 10, 05), EndTime = new DateTime(2015, 10, 05, 23, 59, 59) }
                , new Event { Name = "Hands on Lab: Analyzing Twitter Data in the Cloud", StartTime = new DateTime(2015, 10, 06), EndTime = new DateTime(2015, 10, 06, 23, 59, 59) }
                , new Event { Name = "1 Million Cups", StartTime = new DateTime(2015, 10, 07), EndTime = new DateTime(2015, 10, 07, 23, 59, 59) }
                , new Event { Name = "Computer Science Leadership Summit", StartTime = new DateTime(2015, 10, 08), EndTime = new DateTime(2015, 10, 08, 23, 59, 59) }
                , new Event { Name = "Arkansas Academy of Computing Banquet", StartTime = new DateTime(2015, 10, 09), EndTime = new DateTime(2015, 10, 09, 23, 59, 59) }
                , new Event { Name = "Academy Day at UALR EIT", StartTime = new DateTime(2015, 10, 10), EndTime = new DateTime(2015, 10, 10, 23, 59, 59) }
                , new Event { Name = "Venture Center's Catalyst", StartTime = new DateTime(2015, 10, 13), EndTime = new DateTime(2015, 10, 13, 23, 59, 59) }
                , new Event { Name = "East Night Out: Open House", StartTime = new DateTime(2015, 10, 13), EndTime = new DateTime(2015, 10, 13, 23, 59, 59) }
                , new Event { Name = "1 Million Cups", StartTime = new DateTime(2015, 10, 14), EndTime = new DateTime(2015, 10, 14, 23, 59, 59) }
                , new Event { Name = "Hub UB", StartTime = new DateTime(2015, 10, 14), EndTime = new DateTime(2015, 10, 14, 23, 59, 59) }
                , new Event { Name = "TechFest Pre-Event", StartTime = new DateTime(2015, 10, 15), EndTime = new DateTime(2015, 10, 15, 23, 59, 59) }
                , new Event { Name = "TechFest", StartTime = new DateTime(2015, 10, 16), EndTime = new DateTime(2015, 10, 16, 23, 59, 59) }
                , new Event { Name = "Venture Center's Jolt Hackathon", StartTime = new DateTime(2015, 10, 17), EndTime = new DateTime(2015, 10, 17, 23, 59, 59) }
                , new Event { Name = "NWA Ed Camp", StartTime = new DateTime(2015, 10, 17), EndTime = new DateTime(2015, 10, 17, 23, 59, 59) }
                , new Event { Name = "Family Fun", StartTime = new DateTime(2015, 10, 17), EndTime = new DateTime(2015, 10, 17, 23, 59, 59) }
                , new Event { Name = "1 Million Cups", StartTime = new DateTime(2015, 10, 21), EndTime = new DateTime(2015, 10, 21, 23, 59, 59) }
                , new Event { Name = "CARL Meetup", StartTime = new DateTime(2015, 10, 21), EndTime = new DateTime(2015, 10, 21, 23, 59, 59) }
                , new Event { Name = "Venture Center's Mentor Training", StartTime = new DateTime(2015, 10, 27), EndTime = new DateTime(2015, 10, 27, 23, 59, 59) }
                , new Event { Name = "Venture Center's Code-It", StartTime = new DateTime(2015, 10, 27), EndTime = new DateTime(2015, 10, 27, 23, 59, 59) }
                , new Event { Name = "1 Million Cups", StartTime = new DateTime(2015, 10, 28), EndTime = new DateTime(2015, 10, 28, 23, 59, 59) }
                , new Event { Name = "Maker's Ball @ Capital Hotel", StartTime = new DateTime(2015, 10, 30), EndTime = new DateTime(2015, 10, 30, 23, 59, 59) }
                , new Event { Name = "DRA Pitch Event", StartTime = new DateTime(2015, 11, 05), EndTime = new DateTime(2015, 11, 05, 23, 59, 59) }
                , new Event { Name = "Venture Center's 2 Days to Startup @ UALR (Day 1)", StartTime = new DateTime(2015, 11, 06), EndTime = new DateTime(2015, 11, 08, 23, 59, 59) }
                , new Event { Name = "Venture Center's 2 Days to Startup @ UALR (Day 2)", StartTime = new DateTime(2015, 11, 07), EndTime = new DateTime(2015, 11, 07, 23, 59, 59) }
                , new Event { Name = "Venture Center's 2 Days to Startup @ UALR (Day 3)", StartTime = new DateTime(2015, 11, 08), EndTime = new DateTime(2015, 11, 08, 23, 59, 59) }
                , new Event { Name = "Schools Without Walls: Tinkering with Innovative Technology Conference (Day 1)", StartTime = new DateTime(2015, 11, 07), EndTime = new DateTime(2015, 11, 07, 23, 59, 59) }
                , new Event { Name = "Schools Without Walls: Tinkering with Innovative Technology Conference (Day 2)", StartTime = new DateTime(2015, 11, 08), EndTime = new DateTime(2015, 11, 08, 23, 59, 59) }
                , new Event { Name = "Schools Without Walls: Tinkering with Innovative Technology Conference (Day 3)", StartTime = new DateTime(2015, 11, 09), EndTime = new DateTime(2015, 11, 09, 23, 59, 59) }
                , new Event { Name = "NWA Tech Summit", StartTime = new DateTime(2015, 11, 10), EndTime = new DateTime(2015, 11, 10, 23, 59, 59) }
                );
            context.SaveChanges();
        }
    }
}
