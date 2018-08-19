using System.Data.Entity.Migrations;

namespace Freedi.DataProvider.Migrations
{
    public partial class AddSexClientProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientProfiles", "Sex", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.ClientProfiles", "Sex");
        }
    }
}