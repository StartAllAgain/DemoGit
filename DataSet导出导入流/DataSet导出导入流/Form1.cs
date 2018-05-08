using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataSet导出导入流
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        //获取DataSet
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {//;select * from Test_ItemResult;select *  from Base_Dict
                ds = DBHelper.ExcuteDataSet("select * from Test_ItemResult");
            }
            catch (Exception ex)
            {

            }
            finally
            {
            }

        }
        //导出流文件
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 流操作.导出流(ds);
                SthOperate.SerializeObject(ds);
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // ds.ReadXml(@"d:\1.txt");
            SthOperate.解析流("F:\\");
        }
        //创建流
        private void button4_Click(object sender, EventArgs e)
        {
            string type = "";
            StringBuilder str = new StringBuilder();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                str.Append("Create table " + ds.Tables[0].TableName + "_Syn (");
                foreach (DataColumn dr in ds.Tables[0].Columns)
                {
                    GetDBType(dr.DataType);
                    switch (dr.DataType.ToString().ToLower())
                    {
                        case "system.string":
                            type = "nvarchar(max)";
                            break;
                        case "system.guid":
                            type = "uniqueidentifier";
                            break;
                        case "system.int32":
                            type = "int";
                            break;
                        case "system.int":
                            type = "int";
                            break;
                        case "system.datetime":
                            type = "datetime";
                            break;
                        case "system.byte[]":
                            type = "binary";
                            break;
                        case "system.bool":
                            type = "bit";
                            break;
                        case "system.decimal":
                            type = "decimal";
                            break;
                    }
                    str.Append("[" + dr.ColumnName + "]  " + type + "   " + "NULL,");
                }
                str.Remove(str.ToString().Length - 1, 1);
                str.Append(")");
                DBHelper.ExecuteNonQuery(str.ToString(), null);
            }
            SqlConnection d = DBHelper.Conn;
            SqlCommand commandRowCount = new SqlCommand("SELECT COUNT(*) FROM " + "dbo.BulkCopyDemoMatchingColumns;", d);
            long countStart = System.Convert.ToInt32(commandRowCount.ExecuteScalar());

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(d))
            {
                bulkCopy.DestinationTableName = ds.Tables[0].TableName + "_Syn";
                bulkCopy.WriteToServer(ds.Tables[0]);
            }
            long countEnd = System.Convert.ToInt32(commandRowCount.ExecuteScalar());
        }

        private SqlDbType GetDBType(System.Type theType)
        {
            SqlParameter p1;
            System.ComponentModel.TypeConverter tc;
            p1 = new SqlParameter();
            tc = System.ComponentModel.TypeDescriptor.GetConverter(p1.DbType);
            if (tc.CanConvertFrom(theType))
            {
                p1.DbType = (DbType)tc.ConvertFrom(theType.Name);
            }
            else
            {        //Try brute force    
                try
                {
                    p1.DbType = (DbType)tc.ConvertFrom(theType.Name);
                }
                catch (Exception ex)
                {                //Do Nothing    
                }
            }
            return p1.SqlDbType;
        }
    }
}
