using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;

namespace BLWS.SchoolManagementSys.WebApi.Controllers
{
    /// <summary>
    /// 实现excel导入数据库
    /// </summary>
    public class ExcelController : ApiController
    {
        /// <summary>
        /// 上传Excel文件并将数据存入数据库
        /// </summary>
        /// <param name="strExcelFileName">文件的本地地址</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult UploadExcel(string strExcelFileName) {
           string strSheetName = "sheet1";
            //数据源
            string strConn= "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + strExcelFileName + ";" + "Extended Properties='Excel 12.0;HDR=YES;IMEX=1;'";
            //Sql语句
            string strExcel = "select * from   [sheet1$]";
            //定义存放的数据表  
            DataSet ds = new DataSet();
            //连接数据源  
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();

            //适配到数据源  
            OleDbDataAdapter adapter = new OleDbDataAdapter(strExcel, strConn);
            adapter.Fill(ds, strSheetName);

            conn.Close();
            return Ok(ds.Tables[strSheetName]);
        }

    }
}
