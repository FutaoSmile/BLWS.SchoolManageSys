using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLWS.SchoolManagementSys.EF.Entity
{
    /// <summary>
    /// 流程节点配置
    /// </summary>
   public class ApprovalFlow_FlowSet
    {
        /// <summary>
        /// 流程节点编号
        /// </summary>
        [Key]
        public Guid StepID { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string StepName { get; set; }
        /// <summary>
        /// 节点序号
        /// </summary>
        public int StepNum { get; set; }
        /// <summary>
        /// 流程类型编号
        /// </summary>
        public Guid FlowTypeID { get; set; }
        /// <summary>
        /// 前一节点编号
        /// </summary>
        public Guid PreviousStepID { get; set; }
    }
}
