using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sorting_Algorithm_Testing.Tests;

namespace Sorting_Algorithm_Testing.Search_Types
{
    class Linear : ISearch_Base
    {
        public List<Test_Results> results = new List<Test_Results>();
        public List<Test_Results> InternalResults
        {
            get
            {
                return results;
            }
        }

        public int TimedTest(int[] unsortedArray, int start, int isize, int item)
        {
            int N = unsortedArray.Length;
            if (start < 0)
            {
                return -1;
            }

            for (int i = start; i < N; i++)
            {
                if (unsortedArray[i] == item)
                {
                    return i;
                }
            }

            return -1;
        }

        public TransationMetrics TransactionTest(int[] unsortedArray, int start, int isize, int item)
        {
            TransationMetrics STM = new TransationMetrics();
            
            int N = unsortedArray.Length;
            if (start < 0)
            {
                STM.BytesUsed = GC.GetTotalMemory(true);
                STM.ItemFound = false;
                STM.NumberOfChecks = 0;
                return STM;
            }

            for (int i = start; i < N; i++)
            {
                if (unsortedArray[i] == item)
                {
                    STM.BytesUsed = GC.GetTotalMemory(true);
                    STM.ItemFound = true;
                    STM.NumberOfChecks = i;
                    return STM;
                }
            }

            STM.BytesUsed = GC.GetTotalMemory(true);
            STM.ItemFound = false;
            STM.NumberOfChecks = N;
            return STM;
        }
    }
}
