using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLWS.SchoolManagementSys.EF.Entity
{
    /// <summary>
    /// 学院所拥有的教师
    /// </summary>
   public class Dep_Teacher
    {
        public int ID { get; set; }
        public Guid Dep_ID { get; set; }
        public string Dep_Name { get; set; }
        public Guid Teacher_ID { get; set; }
        public string Teacher_Name { get; set; }
    }
}
