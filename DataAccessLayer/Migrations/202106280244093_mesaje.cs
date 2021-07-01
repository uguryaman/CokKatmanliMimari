namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mesaje : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "UserName", c => c.String(maxLength: 100));
            AddColumn("dbo.Contacts", "UserMail", c => c.String(maxLength: 250));
            AddColumn("dbo.Contacts", "Subject", c => c.String(maxLength: 100));
            AlterColumn("dbo.Contacts", "Message", c => c.String());
            DropColumn("dbo.Contacts", "ContactName");
            DropColumn("dbo.Contacts", "Mail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Mail", c => c.String(maxLength: 250));
            AddColumn("dbo.Contacts", "ContactName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Contacts", "Message", c => c.String(maxLength: 1000));
            DropColumn("dbo.Contacts", "Subject");
            DropColumn("dbo.Contacts", "UserMail");
            DropColumn("dbo.Contacts", "UserName");
        }
    }
}
