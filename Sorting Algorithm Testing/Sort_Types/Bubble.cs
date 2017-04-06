using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using Sorting_Algorithm_Testing;
using Sorting_Algorithm_Testing.Tests;

namespace Sorting_Algorithm_Testing.Sort_Types
{
    class Bubble : ISort_Base
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

        public int[] TimedTest(int[] unsortedArray)
        {
            bool hasBeenSwitched = true;
            int leftToSort = unsortedArray.Length - 1;
            while (leftToSort > 0 && hasBeenSwitched)
            {
                hasBeenSwitched = false;
                for (int i = 0; i < leftToSort; i++)
                {
                    NumOfChecks++;
                    if (unsortedArray[i].CompareTo(unsortedArray[i + 1]) < 0)
                    {
                        hasBeenSwitched = true;
                        var temp = unsortedArray[i];
                        unsortedArray[i] = unsortedArray[i + 1];
                        unsortedArray[i + 1] = temp;
                        NumOfSwaps++;
                    }
                }
                leftToSort--;
            }
            return unsortedArray;
        }

        public TransationMetrics TransactionTest(int[] unsortedArray)
        {
            bool hasBeenSwitched = true;
            int leftToSort = unsortedArray.Length - 1;
            while (leftToSort > 0 && hasBeenSwitched)
            {
                hasBeenSwitched = false;
                for (int i = 0; i < leftToSort; i++)
                {
                    NumOfChecks++;
                    if (unsortedArray[i].CompareTo(unsortedArray[i + 1]) < 0)
                    {
                        hasBeenSwitched = true;
                        var temp = unsortedArray[i];
                        unsortedArray[i] = unsortedArray[i + 1];
                        unsortedArray[i + 1] = temp;
                        NumOfSwaps++;
                    }
                }
                leftToSort--;
            }
            TransationMetrics metrics = new TransationMetrics();
            metrics.NumberOfChecks = NumOfChecks;
            metrics.NumberOfSwaps = NumOfSwaps;
            metrics.BytesUsed = GC.GetTotalMemory(true);
            return metrics;
        }
        public override string ToString()
        {
            return "bubble";
        }
    }
}
