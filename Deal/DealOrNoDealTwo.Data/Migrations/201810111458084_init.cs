namespace DealOrNoDealTwo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Briefcases",
                c => new
                    {
                        BriefCaseId = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BriefCaseId);
            
            CreateTable(
                "dbo.Rounds",
                c => new
                    {
                        RoundId = c.Int(nullable: false, identity: true),
                        BankerPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.RoundId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BackStory = c.String(),
                    })
                .PrimaryKey(t => t.PlayerId);
            
            CreateTable(
                "dbo.RoundBriefcases",
                c => new
                    {
                        Round_RoundId = c.Int(nullable: false),
                        Briefcase_BriefCaseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Round_RoundId, t.Briefcase_BriefCaseId })
                .ForeignKey("dbo.Rounds", t => t.Round_RoundId, cascadeDelete: true)
                .ForeignKey("dbo.Briefcases", t => t.Briefcase_BriefCaseId, cascadeDelete: true)
                .Index(t => t.Round_RoundId)
                .Index(t => t.Briefcase_BriefCaseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoundBriefcases", "Briefcase_BriefCaseId", "dbo.Briefcases");
            DropForeignKey("dbo.RoundBriefcases", "Round_RoundId", "dbo.Rounds");
            DropIndex("dbo.RoundBriefcases", new[] { "Briefcase_BriefCaseId" });
            DropIndex("dbo.RoundBriefcases", new[] { "Round_RoundId" });
            DropTable("dbo.RoundBriefcases");
            DropTable("dbo.Players");
            DropTable("dbo.Rounds");
            DropTable("dbo.Briefcases");
        }
    }
}
