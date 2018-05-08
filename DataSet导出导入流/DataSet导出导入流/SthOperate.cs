using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace DataSet导出导入流
{
    public class SthOperate
    {
        public static string 导出流(DataSet ds)
        {
            string fileName = "F:\\a.txt";
            try
            {

                ds.WriteXml("d:\\1.txt");
                IFormatter formatter = new BinaryFormatter();//定义BinaryFormatter以序列化DataSet对象  

                MemoryStream ms = new MemoryStream();//创建内存流对象  
                formatter.Serialize(ms, ds);//把DataSet对象序列化到内存流  

                //   byte[] buffer = ms.ToArray();//把内存流对象写入字节数组  

                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                FileStream fs = File.Create(fileName);//创建文件  

                GZipStream gzipStream = new GZipStream(fs, CompressionMode.Compress, true);//创建压缩对象  
                ms.Position = 0;
                ms.CopyTo(gzipStream);
                //  gzipStream.Write(buffer, 0, buffer.Length);//把压缩后的数据写入文件  


                gzipStream.Close();//关闭压缩流,这里要注意：一定要关闭，要不然解压缩的时候会出现小于4K的文件读取不到数据，大于4K的文件读取不完整              

                gzipStream.Dispose();//释放对象  


                ms.Close();//关闭内存流对象  

                ms.Dispose();//释放资源  

                fs.Close();//关闭流  

                fs.Dispose();//释放对象  

            }
            catch (Exception ex)
            {
                fileName = string.Empty;
                //写日志  
                throw ex;
            }
            return fileName;
        }

        public static DataSet 解析流(string xml)
        {
            //FileInfo fi = new FileInfo("F:\\b.txt");

            //using (FileStream inFile = fi.OpenRead())
            //{
            //    // Get original file extension, for example
            //    // "doc" from report.doc.gz.
            //    string curFile = fi.FullName;
            //    string origName = curFile.Remove(curFile.Length -
            //            fi.Extension.Length);

            //    //Create the decompressed file.
            //    using (FileStream outFile = File.Create(origName))
            //    {
            //        using (GZipStream Decompress = new GZipStream(inFile,
            //                CompressionMode.Decompress))
            //        {
            //            // Copy the decompression stream 
            //            // into the output file.
            //            Decompress.CopyTo(outFile);

            //            Console.WriteLine("Decompressed: {0}", fi.Name);

            //        }
            //    }
            //}


            // FileStream fs = File.OpenRead("F:\\b.txt");//打开文件  
            DataSet ds = new DataSet();
            //FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

            using (FileStream fileStream = new FileStream("F:\\b.txt", FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter sfFormatter = new BinaryFormatter();
                DataSet all = (DataSet)sfFormatter.Deserialize(fileStream);
            }

            return ds;
        }

        public static void SerializeObject(DataSet ds)
        {
            string fileName = "F:\\b.txt";

            if (ds == null)
            {
                return;
            }
            // MemoryStream ms = new MemoryStream();

            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                // SoapFormatter formatter = new SoapFormatter();
                ds.RemotingFormat = SerializationFormat.Binary;
                formatter.Serialize(fileStream, ds);
                fileStream.Flush();

            }

            Compress(new FileInfo("F:\\b.txt"));
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                ds.RemotingFormat = SerializationFormat.Binary;
                formatter.Serialize(memoryStream, ds);
                memoryStream.Position = 0;
                memoryStream.Flush();

                using (FileStream fileStream = File.Create(fileName))
                {
                    GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Compress);
                    gzipStream.CopyTo(fileStream);
                    gzipStream.Flush();
                }
            }

            //fileStream.Close();
            ////if (File.Exists(fileName))
            ////{
            ////    File.Delete(fileName);
            ////}
            ////GZipStream gzipStream = new GZipStream(fs, CompressionMode.Compress, true);//创建压缩对象
            ////gzipStream.Write(bytes, 0, bytes.Length);
            ////gzipStream.Close();
            ////gzipStream.Dispose();
            //fileStream.Close();
            //fileStream.Dispose();

            return;
        }



        public static void Compress(FileInfo fi)
        {
            // Get the stream of the source file.
            using (FileStream inFile = fi.OpenRead())
            {
                // Prevent compressing hidden and 
                // already compressed files.
                if ((File.GetAttributes(fi.FullName)
                    & FileAttributes.Hidden)
                    != FileAttributes.Hidden & fi.Extension != ".gz")
                {
                    // Create the compressed file.
                    using (FileStream outFile =
                                File.Create(fi.FullName + ".gz"))
                    {
                        using (GZipStream Compress =
                            new GZipStream(outFile,
                            CompressionMode.Compress))
                        {
                            // Copy the source file into 
                            // the compression stream.
                            inFile.CopyTo(Compress);

                            Console.WriteLine("Compressed {0} from {1} to {2} bytes.",
                                fi.Name, fi.Length.ToString(), outFile.Length.ToString());
                        }
                    }
                }
            }
        }

        public static void Decompress(FileInfo fi)
        {
            // Get the stream of the source file.
            using (FileStream inFile = fi.OpenRead())
            {
                // Get original file extension, for example
                // "doc" from report.doc.gz.
                string curFile = fi.FullName;
                string origName = curFile.Remove(curFile.Length -
                        fi.Extension.Length);

                //Create the decompressed file.
                using (FileStream outFile = File.Create(origName))
                {
                    using (GZipStream Decompress = new GZipStream(inFile,
                            CompressionMode.Decompress))
                    {
                        // Copy the decompression stream 
                        // into the output file.
                        Decompress.CopyTo(outFile);

                        Console.WriteLine("Decompressed: {0}", fi.Name);

                    }
                }
            }
        }
    }
}
