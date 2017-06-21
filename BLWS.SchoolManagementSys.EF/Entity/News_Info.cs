using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLWS.SchoolManagementSys.EF.Entity
{
    /// <summary>
    /// 通知
    /// </summary>
   public class News_Info
    {
        /// <summary>
        /// 通知编号
        /// </summary>
        [Key]
        public Guid InfoID { get; set; }
        /// <summary>
        /// 通知标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 通知内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 上传者
        /// </summary>
        public string UploadBy { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime UploadTime { get; set; }
        /// <summary>
        /// 访问量
        /// </summary>
        public int VisitCount { get; set; }
    }
}
