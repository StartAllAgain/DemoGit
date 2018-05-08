using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//导入命名空间
using System.Data.SqlClient;
using System.Data;
//导入配置文件命名空间
using System.Configuration;

namespace DataSet导出导入流
{
    /// <summary>
    /// DBHelper类，封装访问数据库的各类方法
    /// </summary>
    public class DBHelper
    {
        //定义数据库连接对象
        private static SqlConnection conn;
        public static SqlConnection Conn
        {
            get
            {
                if (conn == null)
                {
                    //从配置文件读入数据库连接字符串
                    //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
                    conn = new SqlConnection("Data Source=10.0.2.114;Initial Catalog=PEIS_0601;User ID=sa;Password=123;");
                }
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                return conn;
            }
        }

        /// <summary>
        /// 执行插入、修改、删除操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static bool ExecuteNonQuery(string sql, CommandType type, SqlParameter[] paras)
        {
            int iReturn = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(sql, Conn);
                cmd.CommandType = type;
                if (paras != null && paras.Length > 0)
                    cmd.Parameters.AddRange(paras);
                iReturn = cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                Conn.Close();
            }
            return iReturn > 0 ? true : false;
        }

        public static bool ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, CommandType.Text, null);
        }

        public static bool ExecuteNonQuery(string sql, SqlParameter[] paras)
        {
            return ExecuteNonQuery(sql, CommandType.Text, paras);
        }

        /// <summary>
        /// 使用事务执行多条SQL语句
        /// </summary>
        /// <param name="cmds">SQL语句执行对象数组</param>
        /// <returns></returns>
        public static bool ExecuteTransaction(SqlCommand[] cmds)
        {
            SqlCommand cmdComm = new SqlCommand();
            SqlTransaction myTran = null;
            try
            {
                //开始事务
                myTran = Conn.BeginTransaction();
                for (int i = 0; i < cmds.Length; i++)
                {
                    //循环执行每条SQL语句（更新）
                    cmds[i].Connection = Conn;
                    cmds[i].Transaction = myTran;
                    cmds[i].ExecuteNonQuery();
                }
                //全部执行成功则提交事务
                myTran.Commit();
                return true;
            }
            catch (Exception)
            {
                //执行失败则回滚事务
                myTran.Rollback();
                return false;
            }
            finally
            {
                Conn.Close();
            }
        }



        /// <summary>
        /// 执行返回单行单列的操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static object ExcuteScaler(string sql, CommandType type, SqlParameter[] paras)
        {
            object sReturn = null;
            try
            {
                SqlCommand cmd = new SqlCommand(sql, Conn);
                cmd.CommandType = type;
                if (paras != null && paras.Length > 0)
                    cmd.Parameters.AddRange(paras);
                sReturn = cmd.ExecuteScalar();
            }
            catch
            {
                throw;
            }
            finally
            {
                Conn.Close();
            }
            return sReturn;
        }

        public static object ExcuteScaler(string sql)
        {
            return ExcuteScaler(sql, CommandType.Text, null);
        }

        public static object ExcuteScaler(string sql, SqlParameter[] paras)
        {
            return ExcuteScaler(sql, CommandType.Text, paras);
        }

        /// <summary>
        /// 执行返回sqldatareader的查询操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static SqlDataReader ExcuteReader(string sql, CommandType type, SqlParameter[] paras)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, Conn);
                cmd.CommandType = type;
                if (paras != null && paras.Length > 0)
                    cmd.Parameters.AddRange(paras);
                //执行完毕，当sqldatareader关闭时自动关闭数据库连接
                SqlDataReader read = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return read;
            }
            catch
            {
                throw;
            }
        }

        public static SqlDataReader ExcuteReader(string sql)
        {
            return ExcuteReader(sql, CommandType.Text, null);
        }

        public static SqlDataReader ExcuteReader(string sql, SqlParameter[] paras)
        {
            return ExcuteReader(sql, CommandType.Text, paras);
        }

        /// <summary>
        /// 执行返回datatable的查询操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static DataTable ExcuteDataTable(string sql, CommandType type, SqlParameter[] paras)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, Conn);
                cmd.CommandType = type;
                if (paras != null && paras.Length > 0)
                    cmd.Parameters.AddRange(paras);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0)
                    return ds.Tables[0];
            }
            catch
            {
                throw;
            }
            return null;
        }

        public static DataTable ExcuteDataTable(string sql)
        {
            return ExcuteDataTable(sql, CommandType.Text, null);
        }

        public static DataTable ExcuteDataTable(string sql, SqlParameter[] paras)
        {
            return ExcuteDataTable(sql, CommandType.Text, paras);
        }

        /// <summary>
        /// 执行返回dataset的查询操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static DataSet ExcuteDataSet(string sql, CommandType type, SqlParameter[] paras)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, Conn);
                cmd.CommandType = type;
                if (paras != null && paras.Length > 0)
                    cmd.Parameters.AddRange(paras);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch
            {
                throw;
            }
            return null;
        }

        public static DataSet ExcuteDataSet(string sql)
        {
            return ExcuteDataSet(sql, CommandType.Text, null);
        }

        public static DataSet ExcuteDataSet(string sql, SqlParameter[] paras)
        {
            return ExcuteDataSet(sql, CommandType.Text, paras);
        }



    }

}

