using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLWS.SchoolManagementSys.EF.Entity
{
    /// <summary>
    /// 成绩表
    /// </summary>
   public class Score
    {
        [Key]
        public int ScoreID { get; set; }
        /// <summary>
        /// 学生编号/用户编号
        /// </summary>
        public Guid StudentID { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// 课程编号
        /// </summary>
        public Guid CourseID { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        public string CourseName { get; set; }
        /// <summary>
        /// 教师编号/用户编号
        /// </summary>
        public Guid TeacherID { get; set; }
        /// <summary>
        /// 教师名称
        /// </summary>
        public string TeacherName { get; set; }
        /// <summary>
        /// 分数
        /// </summary>
        public float Scores { get; set; }
    }
}
