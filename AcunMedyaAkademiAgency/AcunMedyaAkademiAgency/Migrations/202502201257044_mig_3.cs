﻿namespace AcunMedyaAkademiAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Name", c => c.String());
            AddColumn("dbo.Admins", "Surname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "Surname");
            DropColumn("dbo.Admins", "Name");
        }
    }
}
