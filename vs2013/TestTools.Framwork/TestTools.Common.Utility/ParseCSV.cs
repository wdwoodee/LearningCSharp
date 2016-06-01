using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Diagnostics;

namespace TestTools.Common.Utility
{
    public class ParseCSV
    {
        /// <summary>
        /// 把DataTable数据源保存到CSV文件中
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="CSVPath"></param>
        public static void SaveDataToCSV(DataTable dt, string CSVPath)
        {
            StringBuilder dataLine = new StringBuilder();
            FileInfo info = new FileInfo(CSVPath);
            if (!info.Directory.Exists)
            {
                Directory.CreateDirectory(info.Directory.ToString());
            }
            if (!File.Exists(CSVPath))
            {
                FileStream createFile = File.Create(CSVPath);
                createFile.Close();
            }

            FileStream fs = new FileStream(CSVPath, FileMode.Truncate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);

            #region Write Columns Names
            int DtColCount = dt.Columns.Count;
            for (int i = 0; i < DtColCount; i++)
            {
                dataLine.Append(dt.Columns[i].ColumnName);
                if (i < DtColCount - 1)
                {
                    dataLine.Append(",");
                }
            }
            sw.WriteLine(dataLine);
            #endregion

            #region write Data into CSV
            int DtRowCount = dt.Rows.Count;
            for (int i = 0; i < DtRowCount; i++)
            {
                dataLine.Clear();
                for (int j = 0; j < DtColCount; j++)
                {
                    string str = dt.Rows[i][j].ToString().TrimEnd();
                    str = str.Replace(",", "(-_-)");

                    dataLine.Append(str);
                    if (j < DtColCount - 1)
                    {
                        dataLine.Append(",");
                    }
                }
                sw.WriteLine(dataLine);
            }
            #endregion

            sw.Close();
            sw.Dispose();
            fs.Close();
            fs.Dispose();
        }

        /// <summary>
        /// 解析CSV文件， 把数据保存成DataTable返回。
        /// </summary>
        /// <param name="CSVPath"></param>
        /// <returns></returns>
        public static DataTable OpenCSV(string CSVPath)
        {
            string DataLine = string.Empty;
            string[] TableDataLine = null;
            string[] tableColsName = null;
            int columnCount = 0;
            bool IsFirstLine = true;
            DataTable dt = new DataTable();
            FileStream fs = new FileStream(CSVPath, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            while ((DataLine = sr.ReadLine()) != null)
            {
                if (IsFirstLine == true)
                {
                    tableColsName = DataLine.Split(',');
                    IsFirstLine = false;
                    columnCount = tableColsName.Length;
                    for (int i = 0; i < columnCount; i++)
                    {
                        DataColumn dc = new DataColumn(tableColsName[i]);
                        dt.Columns.Add(dc);
                    }
                }
                else
                {
                    TableDataLine = DataLine.Split(',');
                    if (TableDataLine.Length > 0)
                    {
                        DataRow dr = dt.NewRow();
                        for (int j = 0; j < columnCount; j++)
                        {
                            dr[j] = TableDataLine[j].Replace("(-_-)",",");
                        }
                        dt.Rows.Add(dr);
                    }
                }
            }
            if (TableDataLine != null && TableDataLine.Length > 0)
            {
                dt.DefaultView.Sort = tableColsName[0] + " " + "asc";
            }
            sr.Close();
            sr.Dispose();
            fs.Close();
            fs.Dispose();
            return dt;
        }
    }
}
