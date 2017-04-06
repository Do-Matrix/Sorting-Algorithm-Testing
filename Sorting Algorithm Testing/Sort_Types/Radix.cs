using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sorting_Algorithm_Testing.Tests;

namespace Sorting_Algorithm_Testing.Sort_Types
{
    class Radix : ISort_Base
    {
        public List<Test_Results> results = new List<Test_Results>();
        public long numOfChecks = 0;
        public long numOfSwaps = 0;
        public long bytesUsed = 0;

        public List<Test_Results> InternalResults
        {
            get
            {
                return results;
            }
        }

        public int[] TimedTest(int[] arr)
        {
            int i, j;
            int[] tmp = new int[arr.Length];
            for (int shift = 31; shift > -1; --shift)
            {
                j = 0;
                for (i = 0; i < arr.Length; ++i)
                {
                    bool move = (arr[i] << shift) >= 0;
                    if (shift == 0 ? !move : move)
                        arr[i - j] = arr[i];
                    else
                        tmp[j++] = arr[i];
                }
                Array.Copy(tmp, 0, arr, arr.Length - j, j);
            }
            return arr;
        }

        public TransationMetrics TransactionTest(int[] arr)
        {
            int i, j;
            int[] tmp = new int[arr.Length];
            for (int shift = 31; shift > -1; --shift)
            {
                j = 0;
                numOfChecks++;
                for (i = 0; i < arr.Length; ++i)
                {
                    numOfSwaps++;
                    bool move = (arr[i] << shift) >= 0;
                    if (shift == 0 ? !move : move)
                    {
                        arr[i - j] = arr[i];
                    }
                    else
                    {
                        tmp[j++] = arr[i];
                    }
                }
                Array.Copy(tmp, 0, arr, arr.Length - j, j);
            }
            Tests.TransationMetrics TMetrics = new TransationMetrics();
            bytesUsed = GC.GetTotalMemory(true);
            TMetrics.NumberOfChecks = numOfChecks;
            TMetrics.NumberOfChecks = numOfSwaps;
            TMetrics.BytesUsed = bytesUsed;
            return TMetrics;
        }
        public override string ToString()
        {
            return "radix";
        }
    }
}
