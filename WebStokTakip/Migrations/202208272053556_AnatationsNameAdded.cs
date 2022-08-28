namespace WebStokTakip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnatationsNameAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shelves", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Shelves", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shelves", "Number", c => c.String(nullable: false));
            DropColumn("dbo.Shelves", "Name");
        }
    }
}
