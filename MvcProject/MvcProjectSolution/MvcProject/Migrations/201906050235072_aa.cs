namespace MvcProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContactUs", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ContactUs", "Message", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContactUs", "Message", c => c.String());
            AlterColumn("dbo.ContactUs", "Email", c => c.String(maxLength: 50));
        }
    }
}
