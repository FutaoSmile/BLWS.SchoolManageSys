namespace BLWS.SchoolManagementSys.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _17614 : DbMigration
    {
        public override void Up()
        { 
            CreateTable(
                "dbo.Student_Class",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClassID = c.Guid(nullable: false),
                        ClassName = c.String(),
                        StudentID = c.Guid(nullable: false),
                        StudentName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
           
        }
    }
}
