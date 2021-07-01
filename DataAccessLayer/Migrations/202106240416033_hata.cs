namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abilities", "AbilitBarsValue", c => c.Int(nullable: false));
            AlterColumn("dbo.Abilities", "AbilityName", c => c.String(maxLength: 60));
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abilities", "AbilitBaryValue", c => c.Int(nullable: false));
            AlterColumn("dbo.Abilities", "AbilityName", c => c.String());
            DropColumn("dbo.Abilities", "AbilitBarsValue");
        }
    }
}
