namespace QRCheckIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QrCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendees", "QrCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendees", "QrCode");
        }
    }
}
