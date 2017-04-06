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
    class Selection : ISort_Base
    {
        public List<Test_Results> results = new List<Test_Results>();
        public long NumOfSwaps { get; set; }
        public long NumOfChecks { get; set; }
        public long MemoryUsed { get; set; }

        public List<Test_Results> InternalResults
        {
            get
            {
                return results;
            }
        }

        public int[] TimedTest(int[] arr)
        {
            int pos_min;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                pos_min = i;//set pos_min to the current index of array

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j].CompareTo(arr[pos_min]) < 0)
                    {
                        //pos_min will keep track of the index that min is in, this is needed when a swap happens
                        pos_min = j;
                    }
                }

                //if pos_min no longer equals i than a smaller value must have been found, so a swap must occur
                if (pos_min != i)
                {
                    var temp = arr[i];
                    arr[i] = arr[pos_min];
                    arr[pos_min] = temp;
                }
            }
            return arr;
        }

        public TransationMetrics TransactionTest(int[] arr)
        {        //pos_min is short for position of min
            int pos_min, temp;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                pos_min = i;//set pos_min to the current index of array

                for (int j = i + 1; j < arr.Length; j++)
                {
                    NumOfChecks++;
                    if (arr[j] < arr[pos_min])
                    {

                        //pos_min will keep track of the index that min is in, this is needed when a swap happens
                        pos_min = j;
                    }
                }

                //if pos_min no longer equals i than a smaller value must have been found, so a swap must occur
                if (pos_min != i)
                {
                    NumOfSwaps++;
                    temp = arr[i];
                    arr[i] = arr[pos_min];
                    arr[pos_min] = temp;
                }
            }
            TransationMetrics transMetrics = new TransationMetrics();
            transMetrics.NumberOfChecks = NumOfChecks;
            transMetrics.NumberOfSwaps = NumOfSwaps;
            transMetrics.BytesUsed = GC.GetTotalMemory(true);
            return transMetrics;
        }
        public override string ToString()
        {
            return "selection";
        }
    }
}
