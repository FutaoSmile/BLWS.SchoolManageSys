using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLWS.SchoolManagementSys.EF.Entity
{
    /// <summary>
    /// 角色——菜单表
    /// </summary>
   public class Role_Menu
    {
        [Key]
        public int Role_Menu_ID { get; set; }
        /// <summary>
        /// 角色编号
        /// </summary>
        public Guid RoleID { get; set; }
        /// <summary>
        /// 菜单编号
        /// </summary>
        public Guid MenuID { get; set; }
    }
}
