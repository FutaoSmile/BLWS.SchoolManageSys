using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLWS.SchoolManagementSys.EF.Entity
{
    /// <summary>
    /// 班级辅导员
    /// </summary>
   public class Dep_ClassMaster
    {
        /// <summary>
        /// 唯一标识符
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 学院编号
        /// </summary>
        public Guid DepId { get; set; }
        /// <summary>
        /// 学院名
        /// </summary>
        public string DepName { get; set; }
        /// <summary>
        /// 辅导员用户编号
        /// </summary>
        public Guid ClassMasterID { get; set; }
        /// <summary>
        /// 辅导员用户名
        /// </summary>
        public string ClassMasterName { get; set; }
    }
}
