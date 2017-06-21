namespace BLWS.SchoolManagementSys.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class classMaster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dep_ClassMaster",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DepId = c.Guid(nullable: false),
                        DepName = c.String(),
                        ClassMasterID = c.Guid(nullable: false),
                        ClassMasterName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dep_ClassMaster");
        }
    }
}
