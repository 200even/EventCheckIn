namespace QRCheckIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventAttendees",
                c => new
                    {
                        Event_Id = c.Int(nullable: false),
                        Attendee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Event_Id, t.Attendee_Id })
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .ForeignKey("dbo.Attendees", t => t.Attendee_Id, cascadeDelete: true)
                .Index(t => t.Event_Id)
                .Index(t => t.Attendee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventAttendees", "Attendee_Id", "dbo.Attendees");
            DropForeignKey("dbo.EventAttendees", "Event_Id", "dbo.Events");
            DropIndex("dbo.EventAttendees", new[] { "Attendee_Id" });
            DropIndex("dbo.EventAttendees", new[] { "Event_Id" });
            DropTable("dbo.EventAttendees");
            DropTable("dbo.Events");
            DropTable("dbo.Attendees");
        }
    }
}
