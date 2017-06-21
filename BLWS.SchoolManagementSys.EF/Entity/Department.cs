using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLWS.SchoolManagementSys.EF.Entity
{
    /// <summary>
    /// 学院
    /// </summary>
   public class Department
    {
        /// <summary>
        /// 学院编号
        /// </summary>
        [Key]
        public Guid DepID { get; set; }
        /// <summary>
        /// 学院名称
        /// </summary>
        public string DepName { get; set; }
        /// <summary>
        /// 院长编号
        /// </summary>
        public Guid Dep_ManagerID { get; set; }
        /// <summary>
        /// 院长姓名
        /// </summary>
        public string Dep_Manage_Name { get; set; }

    }
}
