namespace Freedi.DataProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
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
