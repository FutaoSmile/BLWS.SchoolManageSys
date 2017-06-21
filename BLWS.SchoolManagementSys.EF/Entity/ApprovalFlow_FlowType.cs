using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLWS.SchoolManagementSys.EF.Entity
{
    /// <summary>
    /// 流程类型
    /// </summary>
   public class ApprovalFlow_FlowType
    {
        /// <summary>
        /// 流程类型编号
        /// </summary>
        [Key]
        public Guid FlowTypeID { get; set; }
        /// <summary>
        /// 流程类型名称
        /// </summary>
        public string FlowTypeName { get; set; }
        /// <summary>
        /// 流程优先级
        /// </summary>
        public int FlowTypePriority { get; set; }
    }
}
