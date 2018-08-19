using System.Data.Entity.Migrations;

namespace Freedi.DataProvider.Migrations
{
    public partial class fixmodel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Goods", "Unit");
            DropColumn("dbo.Goods", "SKU");
        }

        public override void Down()
        {
            AddColumn("dbo.Goods", "SKU", c => c.String());
            AddColumn("dbo.Goods", "Unit", c => c.String());
        }
    }
}