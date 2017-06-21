namespace BLWS.SchoolManagementSys.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Class : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classes", "TeacherID", c => c.Guid(nullable: false));
            AddColumn("dbo.Classes", "TeacherName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Classes", "TeacherName");
            DropColumn("dbo.Classes", "TeacherID");
        }
    }
}
