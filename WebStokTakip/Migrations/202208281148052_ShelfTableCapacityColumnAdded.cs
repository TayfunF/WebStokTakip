namespace WebStokTakip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShelfTableCapacityColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shelves", "Capacity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shelves", "Capacity");
        }
    }
}
