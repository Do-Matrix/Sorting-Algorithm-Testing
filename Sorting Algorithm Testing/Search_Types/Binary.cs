using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sorting_Algorithm_Testing.Tests;

namespace Sorting_Algorithm_Testing.Search_Types
{
    class Binary : ISearch_Base
    {
        public override string ToString()
        {
            return "Binary Iterative";
        }

        public List<Test_Results> results = new List<Test_Results>();
        public List<Test_Results> InternalResults
        {
            get
            {
                return results;
            }
        }
        public long NumOfChecks = 0;

        public int TimedTest(int[] inputArray, int min, int max, int key)
        {
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    return ++mid;
                }
                else if (key < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }

        public TransationMetrics TransactionTest(int[] inputArray, int min, int max, int key)
        {
            TransationMetrics TM = new TransationMetrics();
            while (min <= max)
            {
                NumOfChecks++;
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    TM.ItemFound = false;
                    TM.NumberOfChecks = NumOfChecks;
                    TM.BytesUsed = GC.GetTotalMemory(true);
                    return TM;
                }
                else if (key < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            TM.ItemFound = true;
            TM.NumberOfChecks = NumOfChecks;
            TM.BytesUsed = GC.GetTotalMemory(true);
            return TM;
        }
    }
}
