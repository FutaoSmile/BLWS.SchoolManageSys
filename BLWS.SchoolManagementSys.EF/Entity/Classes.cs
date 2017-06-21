using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLWS.SchoolManagementSys.EF.Entity
{
    /// <summary>
    /// 班级
    /// </summary>
   public class Classes
    {
        /// <summary>
        /// 班级编号
        /// </summary>
        [Key]
        public Guid ClassID { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 班级所属学院编号
        /// </summary>
        public Guid DepID { get; set; }
        public Guid TeacherID { get; set; }
        public string TeacherName { get; set; }
    }
}
