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
            context.Events.AddOrUpdate(
                e => e.Id,
                new Event() { Id = 0, Name = "Made by Few (Day 1)", StartTime = new DateTime(10 / 01 / 15), EndTime = new DateTime(2015, 10, 1, 23, 59, 59) }
                , new Event() { Id = 37, Name = "Made by Few (Day 2)", StartTime = new DateTime(10 / 02 / 15), EndTime = new DateTime(2015, 10, 2, 23, 59, 59) }
                , new Event() { Id = 38, Name = "Made by Few (Day 3)", StartTime = new DateTime(10 / 03 / 15), EndTime = new DateTime(2015, 10, 3, 23, 59, 59) }
                , new Event() { Id = 1, Name = "East Night in Open House", StartTime = new DateTime(10 / 01 / 15), EndTime = new DateTime(2015, 10, 1, 23, 59, 59) }
                , new Event() { Id = 2, Name = "UA Grant to Train Teachers in Computer Science", StartTime = new DateTime(10 / 01 / 15), EndTime = new DateTime(2015, 10, 1, 23, 59, 59) }
                , new Event() { Id = 3, Name = "IT Executive Forum for High School Students", StartTime = new DateTime(10 / 01 / 15), EndTime = new DateTime(2015, 10, 1, 23, 59, 59) }
                , new Event() { Id = 32, Name = "2015 Ozark Mountain Brawl (Day 1)", StartTime = new DateTime(10 / 02 / 15), EndTime = new DateTime(2015, 10, 2, 23, 59, 59) }
                , new Event() { Id = 4, Name = "2015 Ozark Mountain Brawl (Day 2)", StartTime = new DateTime(10 / 03 / 15), EndTime = new DateTime(2015, 10, 3, 23, 59, 59) }
                , new Event() { Id = 5, Name = "AMS Manufacturing Day", StartTime = new DateTime(10 / 02 / 15), EndTime = new DateTime(2015, 10, 2, 23, 59, 59) }
                , new Event() { Id = 6, Name = "Forge Idea", StartTime = new DateTime(10 / 03 / 15), EndTime = new DateTime(2015, 10, 3, 23, 59, 59) }
                , new Event() { Id = 7, Name = "AR STEM Coalition Meeting", StartTime = new DateTime(10 / 05 / 15), EndTime = new DateTime(2015, 10, 5, 23, 59, 59) }
                , new Event() { Id = 8, Name = "Hands on Lab: Analyzing Twitter Data in the Cloud", StartTime = new DateTime(10 / 06 / 15), EndTime = new DateTime(2015, 10, 6, 23, 59, 59) }
                , new Event() { Id = 9, Name = "1 Million Cups", StartTime = new DateTime(10 / 07 / 15), EndTime = new DateTime(2015, 10, 7, 23, 59, 59) }
                , new Event() { Id = 10, Name = "Computer Science Leadership Summit", StartTime = new DateTime(10 / 08 / 15), EndTime = new DateTime(2015, 10, 8, 23, 59, 59) }
                , new Event() { Id = 11, Name = "Arkansas Academy of Computing Banquet", StartTime = new DateTime(10 / 09 / 15), EndTime = new DateTime(2015, 10, 9, 23, 59, 59) }
                , new Event() { Id = 12, Name = "Academy Day at UALR EIT", StartTime = new DateTime(10 / 10 / 15), EndTime = new DateTime(2015, 10, 10, 23, 59, 59) }
                , new Event() { Id = 13, Name = "Venture Center's Catalyst", StartTime = new DateTime(10 / 13 / 15), EndTime = new DateTime(2015, 10, 13, 23, 59, 59) }
                , new Event() { Id = 14, Name = "East Night Out: Open House", StartTime = new DateTime(10 / 13 / 15), EndTime = new DateTime(2015, 10, 13, 23, 59, 59) }
                , new Event() { Id = 15, Name = "1 Million Cups", StartTime = new DateTime(10 / 14 / 15), EndTime = new DateTime(2015, 10, 14, 23, 59, 59) }
                , new Event() { Id = 16, Name = "Hub UB", StartTime = new DateTime(10 / 14 / 15), EndTime = new DateTime(2015, 10, 14, 23, 59, 59) }
                , new Event() { Id = 17, Name = "TechFest Pre-Event", StartTime = new DateTime(10 / 15 / 15), EndTime = new DateTime(2015, 10, 15, 23, 59, 59) }
                , new Event() { Id = 18, Name = "TechFest", StartTime = new DateTime(10 / 16 / 15), EndTime = new DateTime(2015, 10, 16, 23, 59, 59) }
                , new Event() { Id = 19, Name = "Venture Center's Jolt Hackathon", StartTime = new DateTime(10 / 17 / 15), EndTime = new DateTime(2015, 17, 13, 23, 59, 59) }
                , new Event() { Id = 20, Name = "NWA Ed Camp", StartTime = new DateTime(10 / 17 / 15), EndTime = new DateTime(2015, 10, 17, 23, 59, 59) }
                , new Event() { Id = 21, Name = "Family Fun", StartTime = new DateTime(10 / 17 / 15), EndTime = new DateTime(2015, 10, 17, 23, 59, 59) }
                , new Event() { Id = 22, Name = "1 Million Cups", StartTime = new DateTime(10 / 21 / 15), EndTime = new DateTime(2015, 10, 21, 23, 59, 59) }
                , new Event() { Id = 23, Name = "CARL Meetup", StartTime = new DateTime(10 / 21 / 15), EndTime = new DateTime(2015, 10, 21, 23, 59, 59) }
                , new Event() { Id = 24, Name = "Venture Center's Mentor Training", StartTime = new DateTime(10 / 27 / 15), EndTime = new DateTime(2015, 10, 27, 23, 59, 59) }
                , new Event() { Id = 25, Name = "Venture Center's Code-It", StartTime = new DateTime(10 / 27 / 15), EndTime = new DateTime(2015, 10, 27, 23, 59, 59) }
                , new Event() { Id = 26, Name = "1 Million Cups", StartTime = new DateTime(10 / 28 / 15), EndTime = new DateTime(2015, 10, 28, 23, 59, 59) }
                , new Event() { Id = 27, Name = "Maker's Ball @ Capital Hotel", StartTime = new DateTime(10 / 30 / 15), EndTime = new DateTime(2015, 10, 30, 23, 59, 59) }
                , new Event() { Id = 28, Name = "DRA Pitch Event", StartTime = new DateTime(11 / 05 / 15), EndTime = new DateTime(2015, 11, 05, 23, 59, 59) }
                , new Event() { Id = 29, Name = "Venture Center's 2 Days to Startup @ UALR (Day 1)", StartTime = new DateTime(11 / 06 / 15), EndTime = new DateTime(2015, 11, 08, 23, 59, 59) }
                , new Event() { Id = 35, Name = "Venture Center's 2 Days to Startup @ UALR (Day 2)", StartTime = new DateTime(11 / 07 / 15), EndTime = new DateTime(2015, 11, 07, 23, 59, 59) }
                , new Event() { Id = 36, Name = "Venture Center's 2 Days to Startup @ UALR (Day 3)", StartTime = new DateTime(11 / 08 / 15), EndTime = new DateTime(2015, 11, 08, 23, 59, 59) }
                , new Event() { Id = 30, Name = "Schools Without Walls: Tinkering with Innovative Technology Conference (Day 1)", StartTime = new DateTime(11 / 07 / 15), EndTime = new DateTime(2015, 11, 07, 23, 59, 59) }
                , new Event() { Id = 33, Name = "Schools Without Walls: Tinkering with Innovative Technology Conference (Day 2)", StartTime = new DateTime(11 / 08 / 15), EndTime = new DateTime(2015, 11, 08, 23, 59, 59) }
                , new Event() { Id = 34, Name = "Schools Without Walls: Tinkering with Innovative Technology Conference (Day 3)", StartTime = new DateTime(11 / 09 / 15), EndTime = new DateTime(2015, 11, 09, 23, 59, 59) }
                , new Event() { Id = 31, Name = "NWA Tech Summit", StartTime = new DateTime(11 / 10 / 15), EndTime = new DateTime(2015, 11, 10, 23, 59, 59) }
                );
        }
    }
}
