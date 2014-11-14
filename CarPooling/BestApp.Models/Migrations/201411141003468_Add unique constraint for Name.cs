namespace BestApp.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdduniqueconstraintforName : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.User", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.User", new[] { "Name" });
        }
    }
}
