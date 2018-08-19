using System.Data.Entity.Migrations;

namespace Freedi.DataProvider.Migrations
{
    public partial class Photos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Photos",
                    c => new
                    {
                        PhotoId = c.Int(false, true),
                        PhotoPath = c.String(),
                        GoodsId = c.Int(false)
                    })
                .PrimaryKey(t => t.PhotoId)
                .ForeignKey("dbo.Goods", t => t.GoodsId, true)
                .Index(t => t.GoodsId);

            DropColumn("dbo.Goods", "Photo");
        }

        public override void Down()
        {
            AddColumn("dbo.Goods", "Photo", c => c.String());
            DropForeignKey("dbo.Photos", "GoodsId", "dbo.Goods");
            DropIndex("dbo.Photos", new[] {"GoodsId"});
            DropTable("dbo.Photos");
        }
    }
}