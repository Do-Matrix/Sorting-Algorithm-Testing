using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sorting_Algorithm_Testing.Tests;

namespace Sorting_Algorithm_Testing.Sort_Types
{
    class MSsort : ISort_Base
    {
        public List<Test_Results> results = new List<Test_Results>();
        public long NumOfChecks = 0;
        public long NumOfSwaps = 0;

        public List<Test_Results> InternalResults
        {
            get
            {
                return results;
            }
        }

        public int[] TimedTest(int[] unsortedArray)
        {
            var nameList = new List<int>();
            nameList.AddRange(unsortedArray);
            nameList.Sort();
            return nameList.ToArray();
        }

        public TransationMetrics TransactionTest(int[] unsortedArray)
        {
            TransationMetrics TM = new TransationMetrics();

            var nameList = new List<int>();
            nameList.AddRange(unsortedArray);
            TM.NumberOfChecks--;
            nameList.Sort();
            TM.NumberOfSwaps--;
            TM.BytesUsed = GC.GetTotalMemory(true);
            return TM;
        }

        public override string ToString()
        {
            return "Microsoft Sort";
        }
    }
}
