namespace DotNetProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedings : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderModels", "OrderDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderModels", "OrderDate", c => c.DateTime(nullable: false));
        }
    }
}
