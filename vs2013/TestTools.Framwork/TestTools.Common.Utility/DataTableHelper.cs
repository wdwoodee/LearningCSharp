using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace TestTools.Common.Utility
{
    public class DataTableHelper
    {
        public static DataTable ExecuteExceptDataTable(DataTable sourDt, DataTable desDt)
        {
            //获取两个数据源的差集
            DataTable dt = sourDt.AsEnumerable().Except(desDt.AsEnumerable(), DataRowComparer.Default).CopyToDataTable();
            return dt;
        }

        public static DataTable ExecuteUnionDataTable(DataTable sourDt, DataTable desDt)
        {
            //获取两个数据源的并集
            DataTable dt = sourDt.AsEnumerable().Union(desDt.AsEnumerable(), DataRowComparer.Default).CopyToDataTable();
            return dt;
        }

        public static DataTable ExecuteIntersectDataTable(DataTable sourDt, DataTable desDt)
        {
            //比较两个数据源的交集
            DataTable dt = sourDt.AsEnumerable().Intersect(desDt.AsEnumerable(), DataRowComparer.Default).CopyToDataTable();
            return dt;
        }

        /// <summary>
        ///  Convert  comma to "#" in datatable.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataTable ModifyCommaInDataTable(DataTable dt)
        {
            foreach (DataRow r in dt.Rows)
            {
                DataRow dr = dt.NewRow();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (r[i].ToString().Contains(","))
                    {
                        r[i] = r[i].ToString().Replace(",", "(-_-)");
                    }
                }
            }
            return dt;
        }


        #region old two table commpare method
        /// <summary>
        /// 比较两个datatable的不同，把各自的的不同项写入到CSV中。
        /// </summary>
        /// <param name="dtBase">Base DataTable</param>
        /// <param name="dtFromDB">Other DataTable</param>
        /// <param name="strOnlyInBasePath">Data only in base datatable</param>
        /// <param name="strOnlyInDBPath">Data only in other datatable</param>
        /// <returns></returns>
        //public static bool CompareTwoDataTable(DataTable dtBase, DataTable dtFromDB, string strOnlyInBasePath, string strOnlyInDBPath)
        //{
        //    bool isFail = false;

        //    //两个表相同
        //    if (dtBase.Rows.Count == dtFromDB.Rows.Count)
        //    {
        //        try
        //        {
        //            DataTable deviceOnlyInBase = DataTableHelper.ExecuteExceptDataTable(dtBase, dtFromDB);
        //            try
        //            {
        //                //未发生异常，deviceOnlyInBase不为空
        //                isFail = true;

        //                //save deviceOnlyInBase
        //                CSVParse.SaveCSV(deviceOnlyInBase, strOnlyInBasePath);

        //                DataTable deviceOnlyInDB = DataTableHelper.ExecuteExceptDataTable(dtFromDB, dtBase);

        //                //deviceOnlyInDB未发生异常，save deviceOnlyInBase
        //                CSVParse.SaveCSV(deviceOnlyInDB, strOnlyInDBPath);
        //                Console.WriteLine("Fail!");
        //            }
        //            catch
        //            {
        //                //deviceOnlyInDB发生异常
        //                Console.WriteLine("Fail");
        //            }
        //        }
        //        catch
        //        {
        //            try
        //            {
        //                DataTable deviceOnlyInDB = DataTableHelper.ExecuteExceptDataTable(dtFromDB, dtBase);
        //                //deviceOnlyInDB未发生异常
        //                isFail = true;
        //                CSVParse.SaveCSV(deviceOnlyInDB, strOnlyInDBPath);
        //            }
        //            catch
        //            {
        //                //都发生异常，完全相同，pass
        //                isFail = false;
        //                //Debug.WriteLine("Pass!");
        //                Console.WriteLine("pass!");
        //            }
        //        }
        //    }
        //    //DB数据多
        //    else if (dtBase.Rows.Count < dtFromDB.Rows.Count)
        //    {
        //        try
        //        {
        //            DataTable deviceOnlyInBase = DataTableHelper.ExecuteExceptDataTable(dtBase, dtFromDB);
        //            try
        //            {
        //                //未发生异常，deviceOnlyInBase不为空
        //                isFail = true;

        //                //save deviceOnlyInBase
        //                CSVParse.SaveCSV(deviceOnlyInBase, strOnlyInBasePath);

        //                DataTable deviceOnlyInDB = DataTableHelper.ExecuteExceptDataTable(dtFromDB, dtBase);

        //                //deviceOnlyInDB未发生异常，save deviceOnlyInBase
        //                CSVParse.SaveCSV(deviceOnlyInDB, strOnlyInDBPath);
        //                Console.WriteLine("Fail!");
        //            }
        //            catch
        //            {
        //                //deviceOnlyInDB发生异常
        //                Console.WriteLine("Fail!");
        //            }
        //        }
        //        catch
        //        {
        //            try
        //            {
        //                DataTable deviceOnlyInDB = DataTableHelper.ExecuteExceptDataTable(dtFromDB, dtBase);
        //                //deviceOnlyInDB发生异常
        //                CSVParse.SaveCSV(deviceOnlyInDB, strOnlyInDBPath);
        //                isFail = true;
        //            }
        //            catch
        //            {
        //                //Will go here
        //            }
        //        }
        //        Console.WriteLine("Fail!");
        //    }
        //    //base数据多
        //    else
        //    {
        //        try
        //        {
        //            DataTable deviceOnlyInBase = DataTableHelper.ExecuteExceptDataTable(dtBase, dtFromDB);
        //            try
        //            {
        //                //未发生异常，deviceOnlyInBase不为空
        //                isFail = true;

        //                //save deviceOnlyInBase
        //                CSVParse.SaveCSV(deviceOnlyInBase, strOnlyInBasePath);

        //                DataTable deviceOnlyInDB = DataTableHelper.ExecuteExceptDataTable(dtFromDB, dtBase);

        //                //deviceOnlyInDB未发生异常，save deviceOnlyInBase
        //                CSVParse.SaveCSV(deviceOnlyInDB, strOnlyInDBPath);
        //                Console.WriteLine("Fail!");
        //            }
        //            catch
        //            {
        //                //deviceOnlyInDB发生异常
        //                Console.WriteLine("Fail!");
        //            }
        //        }
        //        catch
        //        {
        //            try
        //            {
        //                DataTable deviceOnlyInDB = DataTableHelper.ExecuteExceptDataTable(dtFromDB, dtBase);
        //                //deviceOnlyInDB未发生异常
        //                CSVParse.SaveCSV(deviceOnlyInDB, strOnlyInDBPath);
        //                isFail = true;
        //            }
        //            catch
        //            {
        //                //Will go here
        //            }
        //        }
        //        Console.WriteLine("Fail!");
        //    }
        //    return isFail;
        //}
        #endregion
        public static bool CompareTwoDataTable(DataTable dtBase, DataTable dtFromDB, string strOnlyInBasePath, string strOnlyInDBPath)
        {
            DataTable onlyInBase = dtBase.Copy();
            DataTable onlyInDB = dtFromDB.Copy();
            //CSVParse.SaveCSV(dtFromDB, @"C:\Automation\l2topo\DBall.csv");
            bool result = true;
            if (dtBase == null)
            {
                result = false;
                Console.WriteLine("Error: CompareTwoDataTable dbFromDB is null!!!");
                return result;
            }
            if(dtFromDB == null)
            {
                result = false;
                Console.WriteLine("Error: CompareTwoDataTable dbFromDB is null!!!");
                return result;
            }
            try
            {
                DataTable InBaseAndDB = ExecuteIntersectDataTable(dtBase, dtFromDB);
                foreach(DataRow row in InBaseAndDB.Rows)
                {
                    for (int i = 0; i < onlyInBase.Rows.Count;i++ )
                    {
                        if (CompareTwoDataRow(row, onlyInBase.Rows[i]))
                        {
                            //删除相等row后挑出循环
                            onlyInBase.Rows.RemoveAt(i);
                            break;
                        }
                    }
                    for (int i = 0; i < onlyInDB.Rows.Count; i++)
                    {
                        if (CompareTwoDataRow(row, onlyInDB.Rows[i]))
                        {
                            //删除相等row后挑出循环
                            onlyInDB.Rows.RemoveAt(i);
                            break;
                        }
                    }
                }
                if(onlyInBase.Rows.Count>0)
                {
                    result = false;
                    ParseCSV.SaveDataToCSV(onlyInBase, strOnlyInBasePath);
                }
                if(onlyInDB.Rows.Count>0)
                {
                    result = false;
                    ParseCSV.SaveDataToCSV(onlyInDB, strOnlyInDBPath);
                }

            }
            catch(Exception e)
            {
                Console.Write("Table Compare Exception " + e.Message);
            }
            return result;
        }

        public static bool CompareTwoDataRow(DataRow firstRow,DataRow secondRow)
        {
            bool result = true;
            for(int i = 0;i<firstRow.ItemArray.Length;i++)
            {
                if(firstRow[i].ToString()!=secondRow[i].ToString())
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public static DataTable TableSort(DataTable table,string sortBy)
        {
            DataView dv = table.DefaultView;
            dv.Sort = sortBy;
            table = dv.ToTable();
            return table;
        }
    }
}
