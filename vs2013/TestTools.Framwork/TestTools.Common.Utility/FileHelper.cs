using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestTools.Common.Utility
{
    public class FileHelper
    {
        public static void WriteFile(string fileFullPath, string content)
        {
            FileInfo info = new FileInfo(fileFullPath);
            if (!info.Directory.Exists)
            {
                Directory.CreateDirectory(info.Directory.ToString());
            }
            if (!File.Exists(fileFullPath))
            {
                FileStream createFile = File.Create(fileFullPath);
                createFile.Close();
            }
            FileStream fs = new FileStream(fileFullPath, FileMode.Truncate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(content);
            sw.Close();
            sw.Dispose();
            fs.Close();
            fs.Dispose();
        }
    }
}
