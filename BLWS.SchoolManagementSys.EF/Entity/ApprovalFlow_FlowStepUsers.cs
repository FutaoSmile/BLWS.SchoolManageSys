using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLWS.SchoolManagementSys.EF.Entity
{
    /// <summary>
    /// 流程节点人员配置
    /// </summary>
   public class ApprovalFlow_FlowStepUsers
    {
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public Guid UserID { get; set; }
        /// <summary>
        /// 节点编号
        /// </summary>
        public Guid StepID { get; set; }
    }
}
