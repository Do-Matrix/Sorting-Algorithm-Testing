using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sorting_Algorithm_Testing.Tests;

namespace Sorting_Algorithm_Testing.Search_Types
{
    class BinaryRecursive : ISearch_Base
    {
        public List<Test_Results> results = new List<Test_Results>();
        public List<Test_Results> InternalResults
        {
            get
            {
                return results;
            }
        }
        public long NumOfChecks = 0;

        public int TimedTest(int[] source, int left, int right, int value)
        {
            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (source[middle] == value)
                    return middle;
                else if (source[middle] > value)
                    right = middle - 1;
                else if (source[middle] < value)
                    left = middle + 1;
            }
            return -1;
        }

        public TransationMetrics TransactionTest(int[] source, int left, int right, int value)
        {
            TransationMetrics TM = new TransationMetrics();
            while (left <= right)
            {
                int middle = (left + right) / 2;

                NumOfChecks++;
                if (source[middle] == value)
                {
                    TM.BytesUsed = GC.GetTotalMemory(true);
                    TM.ItemFound = true;
                    TM.NumberOfChecks = NumOfChecks;
                    return TM;
                }
                else if (source[middle] > value)
                    right = middle - 1;
                else if (source[middle] < value)
                    left = middle + 1;
            }
            TM.BytesUsed = GC.GetTotalMemory(true);
            TM.ItemFound = true;
            TM.NumberOfChecks = NumOfChecks;
            return TM;
        }
    }
}
