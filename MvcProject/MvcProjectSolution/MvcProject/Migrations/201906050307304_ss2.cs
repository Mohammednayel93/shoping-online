namespace MvcProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ContactUs");
            AlterColumn("dbo.ContactUs", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ContactUs", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ContactUs");
            AlterColumn("dbo.ContactUs", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ContactUs", "Id");
        }
    }
}
