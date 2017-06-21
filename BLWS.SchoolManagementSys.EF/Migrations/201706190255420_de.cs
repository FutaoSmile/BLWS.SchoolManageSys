namespace BLWS.SchoolManagementSys.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class de : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "DepName", c => c.String());
            AddColumn("dbo.Courses", "TeacherID", c => c.Guid(nullable: false));
            AddColumn("dbo.Courses", "TeacherName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "TeacherName");
            DropColumn("dbo.Courses", "TeacherID");
            DropColumn("dbo.Courses", "DepName");
        }
    }
}
