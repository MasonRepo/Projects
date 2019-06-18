namespace DotNetProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zzz : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderNumber = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        ContactID = c.Int(nullable: false),
                        OrderDescription = c.String(),
                        OrderAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OrderModels");
            DropTable("dbo.ContactModels");
        }
    }
}
