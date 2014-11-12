namespace BestApp.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Name", c => c.String());
            AddColumn("dbo.UserTrack", "UserType", c => c.Int(nullable: false));
            AddColumn("dbo.UserTrack", "JoinHour", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.UserTrack", "TrackId", c => c.Int());
            AddColumn("dbo.UserTrack", "UserId", c => c.Int());
            CreateIndex("dbo.UserTrack", "TrackId", name: "IX_Track_Id");
            CreateIndex("dbo.UserTrack", "UserId", name: "IX_User_Id");
            AddForeignKey("dbo.UserTrack", "TrackId", "dbo.Track", "Id");
            AddForeignKey("dbo.UserTrack", "UserId", "dbo.User", "Id");
            DropColumn("dbo.User", "FirstName");
            DropColumn("dbo.User", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "LastName", c => c.String());
            AddColumn("dbo.User", "FirstName", c => c.String());
            DropForeignKey("dbo.UserTrack", "UserId", "dbo.User");
            DropForeignKey("dbo.UserTrack", "TrackId", "dbo.Track");
            DropIndex("dbo.UserTrack", "IX_User_Id");
            DropIndex("dbo.UserTrack", "IX_Track_Id");
            DropColumn("dbo.UserTrack", "UserId");
            DropColumn("dbo.UserTrack", "TrackId");
            DropColumn("dbo.UserTrack", "JoinHour");
            DropColumn("dbo.UserTrack", "UserType");
            DropColumn("dbo.User", "Name");
        }
    }
}
