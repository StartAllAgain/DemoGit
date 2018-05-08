using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;

namespace ExcelOrOrcale
{
    public class RandData
    {
        private static OracleConnection conn = null;
        private static string DataBase = ConfigurationManager.ConnectionStrings["Default"].ToString();

        public static DataTable getExcelData(string FileFullPath, string SheetName)
        {
            DataTable tbContainer = new DataTable();
            string strConn = string.Empty;
            if (string.IsNullOrEmpty(SheetName))
            {
                SheetName = "Sheet1";
            }
            FileInfo file = new FileInfo(FileFullPath);
            if (!file.Exists)
            {
                throw new Exception("文件不存在");
            }
            string extension = file.Extension;
            switch (extension)
            {
                case ".xls":
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileFullPath + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                    break;
                case ".xlsx":
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileFullPath + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                    break;
                default:
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileFullPath + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                    break;
            }
            //链接Excel
            OleDbConnection cnnxls = new OleDbConnection(strConn);
            //读取Excel里面有 表Sheet1
            OleDbDataAdapter oda = new OleDbDataAdapter(string.Format("select * from [{0}$]", SheetName), cnnxls);
            DataSet ds = new DataSet();
            //将Excel里面有表内容装载到内存表中！
            oda.Fill(tbContainer);
            return tbContainer;
        }

        public static bool IsOracleConn(out string Message)
        {
            conn = new OracleConnection(DataBase);
            try
            {
                conn.Open();
                Message = "成功；";
                return true;
            }
            catch (Exception ex)
            {
                Message = "失败；" + ex.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool IsGOP01Exist(string HisCode)
        {
            conn = new OracleConnection(DataBase);
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("Select Count(*) From basearea where HisCode=:HisCode", conn);
                OracleParameter[] parameter = new[] { 
                new OracleParameter(":HisCode",HisCode)
                };
                if (parameter != null)
                {
                    foreach (OracleParameter par in parameter)
                    {
                        cmd.Parameters.Add(par);
                    }
                }
                int Number = int.Parse(cmd.ExecuteScalar().ToString());
                if (Number > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        public string AddGOP01(string Name, string HisCode, string UserCode, string PassWord)
        {
            conn = new OracleConnection(DataBase);
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("Insert Into basearea(Code,Name,HisCode,UserCode,PassWord) Values(seq_basearea_code.nextVal,:Name,:HisCode,:UserCode,:PassWord)", conn);
                OracleParameter[] parameter = new[] { 
                    new OracleParameter(":Name",Name),
                    new OracleParameter(":HisCode",HisCode),
                    new OracleParameter(":UserCode",UserCode),
                    new OracleParameter(":PassWord",PassWord)
                };
                if (parameter != null)
                {
                    foreach (OracleParameter par in parameter)
                    {
                        cmd.Parameters.Add(par);
                    }
                }
                int Number = int.Parse(cmd.ExecuteNonQuery().ToString());
                return Number.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool IsGOP02Exist(string HisCode)
        {
            conn = new OracleConnection(DataBase);
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("Select Count(*) From basedepartment where HisCode=:HisCode", conn);
                OracleParameter[] parameter = new[] { 
                new OracleParameter(":HisCode",HisCode)
                };
                if (parameter != null)
                {
                    foreach (OracleParameter par in parameter)
                    {
                        cmd.Parameters.Add(par);
                    }
                }
                int Number = int.Parse(cmd.ExecuteScalar().ToString());
                if (Number > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return true;
            }
            finally
            {
                conn.Close();
            }
        }
        public string AddGOP02(string AreaCode, string Name, string HisCode, string IsUse)
        {
            conn = new OracleConnection(DataBase);
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("Insert Into basedepartment(Code,AreaCode,Name,HisCode,IsUse) Values(seq_basedepartment_code.nextVal,:AreaCode,:Name,:HisCode,:IsUse)", conn);
                OracleParameter[] parameter = new[] { 
                    new OracleParameter(":AreaCode",AreaCode),
                    new OracleParameter(":Name",Name),
                    new OracleParameter(":HisCode",HisCode),
                    new OracleParameter(":IsUse",IsUse)
                };
                if (parameter != null)
                {
                    foreach (OracleParameter par in parameter)
                    {
                        cmd.Parameters.Add(par);
                    }
                }
                int Number = int.Parse(cmd.ExecuteNonQuery().ToString());
                return Number.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool IsGOP03Exist(string HisCode)
        {
            conn = new OracleConnection(DataBase);
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("Select Count(*) From BaseDoctor where HisCode=:HisCode", conn);
                OracleParameter[] parameter = new[] { 
                new OracleParameter(":HisCode",HisCode)
                };
                if (parameter != null)
                {
                    foreach (OracleParameter par in parameter)
                    {
                        cmd.Parameters.Add(par);
                    }
                }
                int Number = int.Parse(cmd.ExecuteScalar().ToString());
                if (Number > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return true;
            }
            finally
            {
                conn.Close();
            }
        }
        public string AddGOP03(string AreaCode, string Name, string HisCode, string IsUse)
        {
            conn = new OracleConnection(DataBase);
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("Insert Into BaseDoctor(Code,AreaCode,Name,HisCode,IsUse) Values(seq_BaseDoctor_code.nextVal,:AreaCode,:Name,:HisCode,:IsUse)", conn);
                OracleParameter[] parameter = new[] { 
                    new OracleParameter(":AreaCode",AreaCode),
                    new OracleParameter(":Name",Name),
                    new OracleParameter(":HisCode",HisCode),
                    new OracleParameter(":IsUse",IsUse)
                };
                if (parameter != null)
                {
                    foreach (OracleParameter par in parameter)
                    {
                        cmd.Parameters.Add(par);
                    }
                }
                int Number = int.Parse(cmd.ExecuteNonQuery().ToString());
                return Number.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public bool IsHIS01Exist(string HisCode)
        {
            conn = new OracleConnection(DataBase);
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("Select Count(*) From FeeItem where HisCode=:HisCode", conn);
                OracleParameter[] parameter = new[] { 
                new OracleParameter(":HisCode",HisCode)
                };
                if (parameter != null)
                {
                    foreach (OracleParameter par in parameter)
                    {
                        cmd.Parameters.Add(par);
                    }
                }
                int Number = int.Parse(cmd.ExecuteScalar().ToString());
                if (Number > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return true;
            }
            finally
            {
                conn.Close();
            }
        }
        public string AddHIS01(int AreaCode, string Name, string HisCode, float Fee)
        {
            conn = new OracleConnection(DataBase);
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("Insert Into FeeItem(Code,AreaCode,Name,Fee,HisCode,HisName,UseCount,IsUse) Values(seq_FeeItem_code.nextVal,:AreaCode,:Name,:FeePrice,:HisCode,:HisName,1,1)", conn);
                OracleParameter[] parameter = new[] { 
                    new OracleParameter(":AreaCode",AreaCode),
                    new OracleParameter(":Name",Name),
                    new OracleParameter(":FeePrice",Fee),
                    new OracleParameter(":HisCode",HisCode),
                    new OracleParameter(":HisName",Name),
                };
                if (parameter != null)
                {
                    foreach (OracleParameter par in parameter)
                    {
                        cmd.Parameters.Add(par);
                    }
                }
                int Number = int.Parse(cmd.ExecuteNonQuery().ToString());
                return Number.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }


        public static string getAearCode(string posId)
        {
            OracleConnection conn = new OracleConnection(DataBase);
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("Select Code From BaseArea where HisCode=:HisCode", conn);
                OracleParameter[] parameter = new[] { 
                new OracleParameter(":HisCode",posId)
                };
                if (parameter != null)
                {
                    foreach (OracleParameter par in parameter)
                    {
                        cmd.Parameters.Add(par);
                    }
                }
                string Number = cmd.ExecuteScalar().ToString();
                return Number;
            }
            catch (Exception ex)
            {
                return "";
            }
            finally
            {
                conn.Close();
            }
        }


    }
}
