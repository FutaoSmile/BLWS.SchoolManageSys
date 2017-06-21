namespace BLWS.SchoolManagementSys.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class demo1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApprovalFlow_FlowSet", "StepNum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApprovalFlow_FlowSet", "StepNum");
        }
    }
}
