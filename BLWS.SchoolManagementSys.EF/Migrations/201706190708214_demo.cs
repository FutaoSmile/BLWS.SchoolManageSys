namespace BLWS.SchoolManagementSys.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class demo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApprovalFlow_FlowSet", "StepName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApprovalFlow_FlowSet", "StepName");
        }
    }
}
