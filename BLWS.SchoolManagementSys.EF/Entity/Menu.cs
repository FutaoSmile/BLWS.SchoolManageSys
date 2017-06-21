using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLWS.SchoolManagementSys.EF.Entity
{
    /// <summary>
    /// 菜单
    /// </summary>
   public class Menu
    {
        /// <summary>
        /// 菜单编号
        /// </summary>
        [Key]
        public Guid MenuID { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 父菜单编号
        /// </summary>
        public Guid ParentMenuID { get; set; }
        /// <summary>
        /// 页面地址
        /// </summary>
        public string PagePath { get; set; }
        /// <summary>
        /// 菜单顺序值
        /// </summary>
        public int OrderNum { get; set; }
    }
}
