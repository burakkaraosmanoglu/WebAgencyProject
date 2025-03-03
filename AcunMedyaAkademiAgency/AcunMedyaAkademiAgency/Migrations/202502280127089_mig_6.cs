namespace AcunMedyaAkademiAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "BranchID", c => c.Int(nullable: false));
            CreateIndex("dbo.Teams", "BranchID");
            AddForeignKey("dbo.Teams", "BranchID", "dbo.Branches", "BranchID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "BranchID", "dbo.Branches");
            DropIndex("dbo.Teams", new[] { "BranchID" });
            DropColumn("dbo.Teams", "BranchID");
        }
    }
}
