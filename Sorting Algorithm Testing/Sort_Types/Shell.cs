using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sorting_Algorithm_Testing.Tests;

namespace Sorting_Algorithm_Testing.Sort_Types
{
    class Shell : ISort_Base
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

        public int[] TimedTest(int[] array)
        {
            int gap = array.Length / 2;
            while (gap > 0)
            {
                for (int i = 0; i < array.Length - gap; i++) //modified insertion sort
                {
                    int j = i + gap;
                    int tmp = array[j];
                    while (j >= gap && tmp > array[j - gap])
                    {
                        array[j] = array[j - gap];
                        j -= gap;
                    }
                    array[j] = tmp;
                }
                if (gap == 2) //change the gap size
                {
                    gap = 1;
                }
                else
                {
                    gap = (int)(gap / 2.2);
                }
            }
            return array;
        }

        public TransationMetrics TransactionTest(int[] array)
        {
            TransationMetrics TM = new TransationMetrics();
            int gap = array.Length / 2;
            while (gap > 0)
            {
                for (int i = 0; i < array.Length - gap; i++) //modified insertion sort
                {
                    NumOfChecks++;
                    int j = i + gap;
                    int tmp = array[j];
                    while (j >= gap && tmp > array[j - gap])
                    {
                        NumOfSwaps++;
                        array[j] = array[j - gap];
                        j -= gap;
                    }
                    array[j] = tmp;
                }
                if (gap == 2) //change the gap size
                {
                    gap = 1;
                }
                else
                {
                    gap = (int)(gap / 2.2);
                }
            }
            TM.BytesUsed = GC.GetTotalMemory(true);
            TM.NumberOfChecks = NumOfChecks;
            TM.NumberOfSwaps = NumOfSwaps;
            return TM;
        }

        public override string ToString()
        {
            return "Shell";
        }
    }
}
