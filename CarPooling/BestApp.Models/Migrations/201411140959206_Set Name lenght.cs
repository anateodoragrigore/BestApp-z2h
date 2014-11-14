namespace BestApp.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNamelenght : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Name", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Name", c => c.String());
        }
    }
}
