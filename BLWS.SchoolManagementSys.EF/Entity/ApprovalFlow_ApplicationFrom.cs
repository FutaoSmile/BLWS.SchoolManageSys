using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLWS.SchoolManagementSys.EF.Entity
{
    /// <summary>
    /// 申请表单
    /// </summary>
   public class ApprovalFlow_ApplicationFrom
    {
        /// <summary>
        /// 表单编号
        /// </summary>
        [Key]
        public Guid AFID { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 流程类型编号
        /// </summary>
        public Guid FlowTypeID { get; set; }
        /// <summary>
        /// 审批内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 是否完成
        /// </summary>
        public bool IsFinish { get; set; }
        /// <summary>
        /// 当前节点编号
        /// </summary>
        public Guid CurrentStepID { get; set; }
        /// <summary>
        /// 最终节点编号
        /// </summary>
        public Guid FinalStepID { get; set; }

    }
}
