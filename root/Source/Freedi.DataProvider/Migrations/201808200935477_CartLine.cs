namespace Freedi.DataProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartLine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "ClientName", c => c.String());
            AddColumn("dbo.CartLines", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.Order", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.CartLines", "Quantity");
            DropColumn("dbo.Order", "ClientName");
        }
    }
}
