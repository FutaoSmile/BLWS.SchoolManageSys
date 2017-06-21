using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLWS.SchoolManagementSys.EF.Entity
{
    /// <summary>
    /// 新闻评论
    /// </summary>
   public class News_Comment
    {
        [Key]
        public int CommentID { get; set; }
        /// <summary>
        /// 新闻编号 
        /// </summary>
        public Guid NewsID { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public Guid UserID { get; set; }
        /// <summary>
        /// 评论时间    
        /// </summary>
        public DateTime Time { get; set; }
    }
}
