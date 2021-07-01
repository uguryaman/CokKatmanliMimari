namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sertifika2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abilities", "AbilitBarValue", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abilities", "AbilitBarValue");
        }
    }
}
