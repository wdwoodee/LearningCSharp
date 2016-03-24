using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileSize
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(DateTime.Now.ToString());
            Console.WriteLine(DateTime.Now.ToLongDateString());
            Console.WriteLine(DateTime.Now.ToShortDateString());

            DateTime t1 = DateTime.Now;
            
            Console.WriteLine("T1:{0}",t1);
            string path = @"G:\code\dotnet";
            string path2 = @"G:\code\dotnet\a.txt";
            
            //文件夹下的文件总大小
            GetDirectoryLength(path);

            //单个文件的大小
            FileInfo f = new FileInfo(path2);
            long len = f.Length;
            Console.WriteLine(len);


            //目录中所有文件的大小
            DirectoryInfo di = new DirectoryInfo(path);
            // Get a reference to each file in that directory.
            FileInfo[] fiArr = di.GetFiles();
            // Display the names and sizes of the files.
            Console.WriteLine("The directory {0} contains the following files:", di.Name);
            foreach (FileInfo ff in fiArr)
                Console.WriteLine("The size of {0} is {1} bytes.", f.Name, f.Length);
            DateTime t2 = DateTime.Now;
            TimeSpan ts = t2.Subtract(t1);
            Console.WriteLine("T2:{0}",t2);
            Console.WriteLine("T2:{0}", ts.Milliseconds);
            Console.ReadKey();
        }
        public static long GetDirectoryLength(string dirPath)
        {
            //判断给定的路径是否存在,如果不存在则退出
            if (!Directory.Exists(dirPath))
                return 0;
            long len = 0;

            //定义一个DirectoryInfo对象
            DirectoryInfo di = new DirectoryInfo(dirPath);

            //通过GetFiles方法,获取di目录中的所有文件的大小
            foreach (FileInfo fi in di.GetFiles())
            {
                len += fi.Length;
                Console.WriteLine(len);
            }

            //获取di中所有的文件夹,并存到一个新的对象数组中,以进行递归
            DirectoryInfo[] dis = di.GetDirectories();
            if (dis.Length > 0)
            {
                for (int i = 0; i < dis.Length; i++)
                {
                    len += GetDirectoryLength(dis[i].FullName);
                    Console.WriteLine(len);
                }
            }
            return len;
        } 


    }
}
