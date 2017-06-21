using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLWS.SchoolManagementSys.EF.Entity
{
    /// <summary>
    /// 学生与班级关系表
    /// </summary>
   public class Student_Class
    {
        /// <summary>
        /// 唯一标识符
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 班级编号
        /// </summary>
        public Guid ClassID { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 学生编号
        /// </summary>
        public Guid StudentID { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string StudentName { get; set; }
    }
}
