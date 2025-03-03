namespace AcunMedyaAkademiAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectDetails", "ProjectID", c => c.Int(nullable: false));
            CreateIndex("dbo.ProjectDetails", "ProjectID");
            AddForeignKey("dbo.ProjectDetails", "ProjectID", "dbo.Projects", "ProjectID", cascadeDelete: true);
            DropColumn("dbo.ProjectDetails", "ProjectName");
            DropColumn("dbo.ProjectDetails", "Title");
            DropColumn("dbo.ProjectDetails", "ImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectDetails", "ImageUrl", c => c.String());
            AddColumn("dbo.ProjectDetails", "Title", c => c.String());
            AddColumn("dbo.ProjectDetails", "ProjectName", c => c.String());
            DropForeignKey("dbo.ProjectDetails", "ProjectID", "dbo.Projects");
            DropIndex("dbo.ProjectDetails", new[] { "ProjectID" });
            DropColumn("dbo.ProjectDetails", "ProjectID");
        }
    }
}
