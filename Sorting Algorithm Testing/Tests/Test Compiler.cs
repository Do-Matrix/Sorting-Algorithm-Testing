using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Sorting_Algorithm_Testing.Sort_Types;
using System.Diagnostics;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using Sorting_Algorithm_Testing.Search_Types;

namespace Sorting_Algorithm_Testing.Tests
{
    [Serializable]
    public class Test_Compiler
    {
        public List<Test_Results> Results = new List<Test_Results>();
        public const string FilePath = "D:\\tests.xml";
        public const string JsonFilePath = "D:\\tests.json";

        #region Test Runs
        public Test_Results Run(int[] unsortedArray, int isize, params ISort_Base[] sortTypes)
        {
            Test_Results results = new Test_Results();
            foreach (var item in sortTypes)
            {
                Test_Results _results = new Test_Results();
                Stopwatch timer = new Stopwatch();
                int[] timedCopy = (int[])unsortedArray.Clone();
                _results.Type = "Sort";
                _results.Name = item.ToString();
                Console.Write("{0}: ", _results.Name);
                timer.Start();
                item.TimedTest(timedCopy);
                timer.Stop();
                _results.Size = isize;
                _results.ElapsedTime = timer.Elapsed.ToString("mm':'ss'.'fffff");
                int[] transcopy = (int[])unsortedArray.Clone();
                TransationMetrics transMetrics = item.TransactionTest(transcopy);
                _results.Transaction_Metrics = transMetrics;
                Console.Write("Done!\n");
                item.InternalResults.Add(_results);
                Results.Add(_results);
                results = _results;
            }
            return results;
        }

        public Test_Results Run(int[] unsortedArray, int isize, int item, params ISearch_Base[] searchTypes)
        {
            Test_Results results = new Test_Results();
            Stopwatch timer = new Stopwatch();
            foreach (var Item in searchTypes)
            {
                int[] timedCopy = (int[])unsortedArray.Clone();
                results.Type = "Search";
                results.Name = Item.ToString();
                Console.Write("{0}: ", results.Name);
                timer.Start();
                Item.TimedTest(timedCopy, 0, isize, 51);
                timer.Stop();
                results.Size = isize;
                results.ElapsedTime = timer.Elapsed.ToString("hh':'mm':'ss'.'fff");
                int[] transcopy = (int[])unsortedArray.Clone();
                TransationMetrics transMetrics = Item.TransactionTest(transcopy, 0, isize, 51);
                results.Transaction_Metrics = transMetrics;
                Console.Write("Done!\n");
                Item.InternalResults.Add(results);
                Results.Add(results);
                timer.Reset();
            }

            return results;
        }
        #endregion

        #region Save/Load
        public void save(SaveType saveType)
        {
            TextWriter writer = null;
            if (saveType == SaveType.JSON)
            {
                try
                {
                    var serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;
                    serializer.NullValueHandling = NullValueHandling.Ignore;
                    writer = new StreamWriter(JsonFilePath, false);
                    serializer.Serialize(writer, this);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            else
            {
                try
                {
                    var serializer = new XmlSerializer(typeof(Test_Compiler));
                    writer = new StreamWriter(FilePath, false);
                    serializer.Serialize(writer, this);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (writer != null)
                writer.Close();
        }

        public static Test_Compiler load(SaveType saveType)
        {
            if (saveType == SaveType.JSON)
            {
                Console.WriteLine("using JSON");
                var serializer = new JsonSerializer();
                TextReader reader = null;
                try
                {
                    if (File.Exists(JsonFilePath))
                    {
                        reader = new StreamReader(JsonFilePath, false);
                        return serializer.Deserialize(reader, typeof(Test_Compiler)) as Test_Compiler;
                    }
                    return new Test_Compiler();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }
            }
            else
            {
                Console.WriteLine("using XML");
                var serializer = new XmlSerializer(typeof(Test_Compiler));
                TextReader reader = null;
                try
                {
                    if (File.Exists(FilePath))
                    {
                        reader = new StreamReader(FilePath, false);
                        return serializer.Deserialize(reader) as Test_Compiler;
                    }
                    return new Test_Compiler();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }
        }

        public enum SaveType
        {
            JSON,
            XML 
        }
        #endregion

        #region Excel Output
        public void CreateExcelFromData(params ISort_Base[] sorts)
        {
            var excel = new Excel.Application()
            {
                Visible = true
            };
            excel.Workbooks.Add();
            Excel._Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;

            worksheet.Cells[1, "A"] = "Data Size";
            for (int col = 0; col < sorts.Length + 1; col++)
            {
                if (col == 0) continue;
                worksheet.Cells[1, col + 1] = sorts[col - 1].ToString();
            }
            for (int row = 0; row < sorts[0].InternalResults.Count + 1; row++)
            {
                if (row == 0) continue;
                worksheet.Cells[row + 1, "A"] = sorts[0].InternalResults[row - 1].Size;
            }
            for (int col = 0; col < sorts.Length; col++)
            {
                for (int row = 0; row < sorts[0].InternalResults.Count; row++)
                {
                    worksheet.Cells[row + 2, col + 2] = sorts[col].InternalResults[row].ElapsedTime;
                }
            }
        }

        public void CreateExcelFromData(params ISearch_Base[] searches)
        {
            var excel = new Excel.Application()
            {
                Visible = true
            };
            excel.Workbooks.Add();
            Excel._Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;

            worksheet.Cells[1, "A"] = "Data Size";
            for (int col = 0; col < searches.Length + 1; col++)
            {
                if (col == 0) continue;
                worksheet.Cells[1, col + 1] = searches[col - 1].ToString();
            }
            for (int row = 0; row < searches[0].InternalResults.Count + 1; row++)
            {
                if (row == 0) continue;
                worksheet.Cells[row + 1, "A"] = searches[0].InternalResults[row - 1].Size;
            }
            for (int col = 0; col < searches.Length; col++)
            {
                for (int row = 0; row < searches[0].InternalResults.Count; row++)
                {
                    worksheet.Cells[row + 2, col + 2] = searches[col].InternalResults[row].ElapsedTime;
                }
            }
        }
            #endregion
    }
}
