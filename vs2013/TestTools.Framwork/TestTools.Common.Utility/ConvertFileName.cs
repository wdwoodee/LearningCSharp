using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTools.Common.Utility
{
    public class ConvertFileName
    {
        public static string RevertFilenamingrules(string filename)
        {
            filename = filename.ToUpper();
            filename = filename.Replace("X", "XX").Replace(@"/", "XA").Replace(@"\", "XB").Replace(@":", "XC").Replace(@"*", "XD").Replace(@"?", "XE").Replace("\"", "XF").Replace(@"<", "XG").Replace(@">", "XH").Replace(@"|", "XI").Replace(@"$", "XJ");
            filename = filename.Replace("CON", "CON!!!").Replace("PRN", "PRN!!!").Replace("AUX", "AUX!!!").Replace(@"PRN", "PRN!!!").Replace(@"CLOCK$", @"CLOCK$!!!").Replace(@"NUL", "NUL!!!");
            filename = filename.Replace("COM1", "COM1!!!").Replace("COM2", "COM2!!!").Replace("COM3", "COM3!!!").Replace(@"COM4", "COM4!!!").Replace(@"COM5", @"COM5!!!").Replace(@"COM6", "COM6!!!").Replace(@"COM7", "COM7!!!").Replace(@"COM8", "COM8!!!").Replace(@"COM9", "COM9!!!");
            filename = filename.Replace("LPT1", "LPT1!!!").Replace("LPT2", "LPT2!!!").Replace("LPT3", "LPT3!!!").Replace(@"LPT4", "LPT4!!!").Replace(@"LPT5", @"LPT5!!!").Replace(@"LPT6", "LPT6!!!").Replace(@"LPT7", "LPT7!!!").Replace(@"LPT8", "LPT8!!!").Replace(@"LPT9", "LPT9!!!");
            return filename;
        }

        public static string TrimMultBlankToOneBlank(string str)
        {
            string[] strlist = str.Split();

            string Result = "";

            for (int i = 0; i < strlist.Length - 1; i++)
            {
                if (strlist[i] != "")
                {
                    Result += strlist[i].Trim() + " ";
                }
            }
            return Result;
        }
    }
}
