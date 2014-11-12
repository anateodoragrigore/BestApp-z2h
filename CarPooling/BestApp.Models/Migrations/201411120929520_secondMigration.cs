namespace BestApp.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class secondMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tracks", newName: "Track");
            RenameTable(name: "dbo.Users", newName: "User");
            CreateTable(
                "dbo.UserTrack",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Track", "Start", c => c.Geography());
            AddColumn("dbo.Track", "Stop", c => c.Geography());
            AddColumn("dbo.Track", "CarSeats", c => c.Int(nullable: false));
            AddColumn("dbo.Track", "UserType", c => c.Int(nullable: false));
            DropColumn("dbo.Track", "Latitude");
            DropColumn("dbo.Track", "Longitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Track", "Longitude", c => c.Double(nullable: false));
            AddColumn("dbo.Track", "Latitude", c => c.Double(nullable: false));
            DropColumn("dbo.Track", "UserType");
            DropColumn("dbo.Track", "CarSeats");
            DropColumn("dbo.Track", "Stop");
            DropColumn("dbo.Track", "Start");
            DropTable("dbo.UserTrack");
            RenameTable(name: "dbo.User", newName: "Users");
            RenameTable(name: "dbo.Track", newName: "Tracks");
        }
    }
}
