using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sorting_Algorithm_Testing;
using Sorting_Algorithm_Testing.Tests;

namespace Sorting_Algorithm_Testing.Sort_Types
{
    class Insertion : ISort_Base
    {

        public List<Test_Results> results = new List<Test_Results>();
        public static long NumOfSwaps { get; set; }
        public static long NumOfChecks { get; set; }
        public static long MemoryUsed { get; set; }

        public List<Test_Results> InternalResults
        {
            get
            {
                return results;
            }
        }

        public int[] TimedTest(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;

                while ((j > 0) && (array[j].CompareTo(array[j - 1]) < 0))
                {
                    int k = j - 1;
                    var temp = array[k];
                    array[k] = array[j];
                    array[j] = temp;

                    j--;
                }
            }
            return array;
        }

        public TransationMetrics TransactionTest(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                NumOfChecks++;
                while ((j > 0) && (array[j].CompareTo(array[j - 1]) < 0))
                {
                    NumOfSwaps++;
                    int k = j - 1;
                    var temp = array[k];
                    array[k] = array[j];
                    array[j] = temp;

                    j--;
                }
            }
            TransationMetrics TMetrics = new TransationMetrics();
            TMetrics.NumberOfChecks = NumOfChecks;
            TMetrics.NumberOfSwaps = NumOfSwaps;
            TMetrics.BytesUsed = GC.GetTotalMemory(true);
            return TMetrics;
        }
        public override string ToString()
        {
            return "insertion";
        }
    }
}
