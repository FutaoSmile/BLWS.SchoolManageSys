using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLWS.SchoolManagementSys.EF.Entity
{
    /// <summary>
    /// 教师授课信息
    /// </summary>
   public class Teacher_Course
    {
        [Key]
        public int Teacher_Course_ID { get; set; }
        /// <summary>
        /// 教师编号/User编号
        /// </summary>
        public Guid TeacherID { get; set; }
        /// <summary>
        /// 课程编号
        /// </summary>
        public Guid CourseID { get; set; }

    }
}
