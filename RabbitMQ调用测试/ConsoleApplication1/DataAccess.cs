using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class DataAccess
    {
        OracleConnection conn = null;
        public List<LisFeeItemSub> getLisFeeItemSub()
        {
            try
            {//
                List<LisFeeItemSub> lisFeeItemSub = new List<LisFeeItemSub>();
                conn = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=10.0.2.69)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=lis)));Persist Security Info=True;User ID=lis;Password=123456;");
                conn.Open();
                OracleCommand cmd = new OracleCommand(@"Select b.HisCode groupcode,b.HisName groupname,b.Areacode areacode,c.Code ticode,c.Name name From feeitemsub a Left Join FeeItem b On a.FeeITemCode=b.Code Left Join TestItem c On a.TiCode=c.Code where b.HisCode like 'TJ%'  Order By b.HisCode", conn);
                OracleDataReader dataR = cmd.ExecuteReader();
                while (dataR.Read())
                {
                    LisFeeItemSub FeeItemSub = new LisFeeItemSub()
                    {
                        groupcodeStr = dataR["groupcode"].ToString(),
                        groupname = dataR["groupname"].ToString(),
                        ticodeStr = dataR["ticode"].ToString(),
                        name = dataR["name"].ToString(),
                        areacode = dataR["areacode"].ToString()
                    };
                    lisFeeItemSub.Add(FeeItemSub);
                }
                return lisFeeItemSub;
            }
            catch (Exception ex)
            {
                return new List<LisFeeItemSub>();
            }
            finally
            {
                conn.Close();
            }



        }
    }
}
