using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace FileTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Automation\BAT\Configforthinclient";
            DirectoryInfo dir = new DirectoryInfo(path);
            long a = GetFilesCount(dir, "*.config");
            List<string> filenames = GetFiles(dir, "*.config");

            XMLHelper xmlTest = new XMLHelper();
            //xmlTest.InsertNode();
            //xmlTest.UpdateNode();
            //xmlTest.DeleteNode();
            //xmlTest.ShowXml();

            string file = @"D:\Github\CSharpTest\FileTest\FileTest\bookshop.xml";
            string xpath = @"/bookshop/book/title";
            XmlNode xn = XMLHelper.GetXmlNodeByXpath(file, xpath);
            XmlNodeList xnl = XMLHelper.GetXmlNodeListByXpath(file, xpath);
            foreach (XmlNode x in xnl)
            {
                XmlElement xe = (XmlElement)x;
                Console.WriteLine(xe.InnerText);
            }

            /*初始化str1的时候，就在堆上分配了一个
string对象，当初始化str2的时候，也指向了这个对象。当str1改变的时候，并不是修改了
原有的对  象，而是新创建了一个对象，但str2还是指向原来的对象，所以，str2的值并未
改变。*/
            string str1 = "abced dwang";
            string str2 = str1;
            Console.WriteLine(str2);
            str1 = "dwang";
            Console.WriteLine(str2);

            string[] arr1 = new string[] { "123", "456" };
            string[] arr2 = arr1;
            arr1[1] = "789";

            foreach (string s in arr1)
            {
                Console.WriteLine(s);
            }
            foreach (string s in arr2)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }
        public static long GetFilesCount(DirectoryInfo directory, string pattern)
        {
            if (!directory.Exists)
                return 0;
            long iCount = 0;
            if (pattern.Trim() != string.Empty)
            {
                try
                {
                    iCount = directory.GetFiles(pattern).Length;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                foreach (DirectoryInfo info in directory.GetDirectories())
                {
                    iCount += GetFilesCount(info, pattern);
                }
            }
            return iCount;
        }

        public static List<string> GetFiles(DirectoryInfo directory, string pattern)
        {
            List<string> result = new List<string>();
            if (directory.Exists || pattern.Trim() != string.Empty)
            {
                try
                {
                    foreach (FileInfo info in directory.GetFiles(pattern))
                    {
                        result.Add(info.FullName.ToString());
                        //num++;
                    }
                }
                catch { }
                foreach (DirectoryInfo info in directory.GetDirectories())
                {
                    GetFiles(info, pattern);
                }
            }
            return result;
        }
    }
}
