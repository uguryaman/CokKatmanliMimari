namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class salt2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminSalt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "AdminSalt");
        }
    }
}
