namespace WebStokTakip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnatationsAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Shelves", "Number", c => c.String(nullable: false));
            AlterColumn("dbo.Warehouses", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Warehouses", "Name", c => c.String());
            AlterColumn("dbo.Shelves", "Number", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
        }
    }
}
