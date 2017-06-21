using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLWS.SchoolManagementSys.EF.Entity
{
    /// <summary>
    /// 课程
    /// </summary>
   public class Course
    {
        /// <summary>
        /// 课程编号
        /// </summary>
        [Key]
        public Guid CourseID { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        public string CourseName { get; set; }
        /// <summary>
        /// 学分
        /// </summary>
        public int Credit { get; set; }
        /// <summary>
        /// 描述/介绍
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 所属学院编号
        /// </summary>
        public Guid DepID { get; set; }
        public string DepName { get; set; }
        public Guid TeacherID { get; set; }
        public string TeacherName { get; set; }
    }
}
