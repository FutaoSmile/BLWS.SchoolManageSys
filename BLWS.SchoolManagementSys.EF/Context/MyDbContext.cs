using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BLWS.SchoolManagementSys.EF.Entity;

namespace BLWS.SchoolManagementSys.EF.Context
{
  public  class MyDbContext : DbContext
    {
        public MyDbContext():base("name=DBConn")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
        static MyDbContext()
        {
            //一：数据库不存在时重新创建数据库[默认]
            Database.SetInitializer(new CreateDatabaseIfNotExists<MyDbContext>());
            //二：每次启动应用程序时创建数据库
            //Database.SetInitializer<testContext>(new DropCreateDatabaseAlways<SpreadtrumPMMContext>());
            //三：策略三：模型更改时重新创建数据库
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CodeFirstDBContext>());
            //策略四：从不创建数据库 
            //Database.SetInitializer<CodeFirstDBContext>(null);
        }
        #region 审批流
        public virtual DbSet<ApprovalFlow_ApplicationFrom> ApprovalFlow_ApplicationFrom { get; set; }
        public virtual DbSet<ApprovalFlow_ApprovalLog> ApprovalFlow_ApprovalLog { get; set; }
        public virtual DbSet<ApprovalFlow_FlowSet> ApprovalFlow_FlowSet { get; set; }
        public virtual DbSet<ApprovalFlow_FlowStepUsers> ApprovalFlow_FlowStepUsers { get; set; }
        public virtual DbSet<ApprovalFlow_FlowType> ApprovalFlow_FlowType { get; set; }
        #endregion
        #region 新闻评论通知
        public virtual DbSet<News_Comment> News_Comment { get; set; }
        public virtual DbSet<News_Info> News_Info { get; set; }
        public virtual DbSet<News_news> News_news { get; set; }
        #endregion
        #region 系统
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Role_Menu> Role_Menu { get; set; }
        public virtual DbSet<Score> Score { get; set; }
        public virtual DbSet<Teacher_Course> Teacher_Course { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<User_Role> User_Role { get; set; }
        public virtual DbSet<Student_Class> Student_Class { get; set; }
        public virtual DbSet<Dep_Teacher> Dep_Teacher { get; set; }
        public virtual DbSet<Dep_ClassMaster> Dep_ClassMaster { get; set; }
        
        #endregion

    }
}
