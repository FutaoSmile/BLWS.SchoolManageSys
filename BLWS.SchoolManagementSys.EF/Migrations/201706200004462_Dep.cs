namespace BLWS.SchoolManagementSys.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dep : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "Dep_ManagerID", c => c.Guid(nullable: false));
            AddColumn("dbo.Departments", "Dep_Manage_Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "Dep_Manage_Name");
            DropColumn("dbo.Departments", "Dep_ManagerID");
        }
    }
}
