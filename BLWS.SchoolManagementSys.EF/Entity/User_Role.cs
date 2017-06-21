using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLWS.SchoolManagementSys.EF.Entity
{
    /// <summary>
    /// 用户——角色关系表
    /// </summary>
   public class User_Role
    {
        [Key]
        public int User_Role_ID { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public Guid UserID { get; set; }
        /// <summary>
        /// 角色编号
        /// </summary>
        public Guid RoleID { get; set; }
    }
}
