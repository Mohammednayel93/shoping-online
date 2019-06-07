namespace MvcProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Image", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Image", c => c.String(maxLength: 50));
        }
    }
}
