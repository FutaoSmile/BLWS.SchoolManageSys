using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLWS.SchoolManagementSys.EF.Entity
{
    /// <summary>
    /// 审批记录
    /// </summary>
   public class ApprovalFlow_ApprovalLog
    {
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// 审批表单编号
        /// </summary>
        public Guid AFID { get; set; }
        /// <summary>
        /// 审批人
        /// </summary>
        public string ApprovalBy { get; set; }
        /// <summary>
        /// 审批人所属部门
        /// </summary>
        public string ApprovalByDep { get; set; }
        /// <summary>
        /// 审批结果
        /// </summary>
        public string ApprovalResult { get; set; }
        /// <summary>
        /// 审批时间
        /// </summary>
        public DateTime ApprovalTime { get; set; }
    }
}
