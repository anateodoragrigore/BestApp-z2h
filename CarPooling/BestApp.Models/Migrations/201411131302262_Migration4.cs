namespace BestApp.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Track", "PhoneNumber", c => c.String());
            AddColumn("dbo.Track", "EmailAddress", c => c.String());
            AddColumn("dbo.Track", "UserOwnerId", c => c.Int());
            CreateIndex("dbo.Track", "UserOwnerId", name: "IX_UserOwner_Id");
            AddForeignKey("dbo.Track", "UserOwnerId", "dbo.User", "Id");
            DropColumn("dbo.Track", "UserType");
            DropColumn("dbo.User", "PhoneNumber");
            DropColumn("dbo.User", "EmailAddress");
            DropColumn("dbo.UserTrack", "JoinHour");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserTrack", "JoinHour", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.User", "EmailAddress", c => c.String());
            AddColumn("dbo.User", "PhoneNumber", c => c.String());
            AddColumn("dbo.Track", "UserType", c => c.Int(nullable: false));
            DropForeignKey("dbo.Track", "UserOwnerId", "dbo.User");
            DropIndex("dbo.Track", "IX_UserOwner_Id");
            DropColumn("dbo.Track", "UserOwnerId");
            DropColumn("dbo.Track", "EmailAddress");
            DropColumn("dbo.Track", "PhoneNumber");
        }
    }
}
