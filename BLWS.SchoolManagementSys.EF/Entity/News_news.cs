using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLWS.SchoolManagementSys.EF.Entity
{
    /// <summary>
    /// 新闻
    /// </summary>
   public class News_news
    {
        /// <summary>
        /// 新闻编号
        /// </summary>
        [Key]
        public Guid NewsID { get; set; }
        /// <summary>
        /// 新闻标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 新闻内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime UploadTime { get; set; }
        /// <summary>
        /// 上传者
        /// </summary>
        public string UploadBy { get; set; }
        /// <summary>
        /// 访问量
        /// </summary>
        public int VisitCount { get; set; }
    }
}
