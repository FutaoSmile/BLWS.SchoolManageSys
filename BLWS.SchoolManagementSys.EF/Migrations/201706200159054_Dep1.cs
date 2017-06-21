namespace BLWS.SchoolManagementSys.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dep1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dep_Teacher",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Dep_ID = c.Guid(nullable: false),
                        Dep_Name = c.String(),
                        Teacher_ID = c.Guid(nullable: false),
                        Teacher_Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dep_Teacher");
        }
    }
}
