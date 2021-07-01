namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hş : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Admins", "Salt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "Salt", c => c.String());
        }
    }
}
