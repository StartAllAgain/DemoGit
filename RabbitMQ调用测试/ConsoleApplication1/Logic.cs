using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Net;
using System.Drawing;

namespace ConsoleApplication1
{
    public class Logic
    {
        public static T JsonAndObject<T>(string Json)
where T : new()
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(Json)))
            {
                T jsonObject = (T)ser.ReadObject(ms);
                return jsonObject;
            }

        }
        public static string ObjectToJson(object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, obj);
            byte[] dataBytes = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(dataBytes, 0, (int)stream.Length);
            return Encoding.UTF8.GetString(dataBytes);
        }

        public static string RequestPost(string Url, string parameter)
        {

            HttpWebRequest hwrq = (HttpWebRequest)WebRequest.Create(Url);
            hwrq.Method = "Post";
            hwrq.ContentType = "application/x-www-form-urlencoded";
            if (parameter != "")
            {
                byte[] bt = Encoding.UTF8.GetBytes(parameter);
                ////byte[] bt = Encoding.GetEncoding("gbk").GetBytes(d);
                hwrq.ContentLength = bt.Length;
                Stream sw = hwrq.GetRequestStream();
                sw.Write(bt, 0, bt.Length);
                sw.Close();
            }
            HttpWebResponse res = null;
            HttpWebResponse hwrp1 = null;
            try
            {
                hwrp1 = (HttpWebResponse)hwrq.GetResponse();
                string strlcHtml = string.Empty;
                Encoding enc = Encoding.GetEncoding("UTF-8");
                Stream stream = hwrp1.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream, enc);
                strlcHtml = streamReader.ReadToEnd();
                return strlcHtml;
            }
            catch (WebException ex)
            {
                res = (HttpWebResponse)ex.Response;
                StreamReader sr = new StreamReader(res.GetResponseStream(), true);
                string strHtml = sr.ReadToEnd();
                return strHtml;
            }
        }

        public static Image GetImageByBytes(byte[] bytes)
        {
            Image photo = null;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                ms.Write(bytes, 0, bytes.Length);
                photo = Image.FromStream(ms, true);
            }
            photo.Save("E:\a.jpg");
            return photo;
        }


        public static string SaveImage(String path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read); //将图片以文件流的形式进行保存
            BinaryReader br = new BinaryReader(fs);
            byte[] imgBytesIn = br.ReadBytes((int)fs.Length);  //将流读入到字节数组中
            return Convert.ToBase64String(imgBytesIn);
        }

        public static string TimeStamp(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow).ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}