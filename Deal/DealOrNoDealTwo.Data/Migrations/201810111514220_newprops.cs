namespace DealOrNoDealTwo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newprops : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "EndingSum", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "EndingSum");
        }
    }
}
