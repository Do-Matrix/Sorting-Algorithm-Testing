using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sorting_Algorithm_Testing.Tests;

namespace Sorting_Algorithm_Testing.Sort_Types
{
    class Quicksort : ISort_Base
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
            return QuickSort(unsortedArray);
        }

        public TransationMetrics TransactionTest(int[] unsortedArray)
        {
            TransationMetrics TM = new TransationMetrics();
            return QuickSortTM(unsortedArray, TM);
        }

        static int[] QuickSort(int[] elements)
        {
            Random rand = new Random();
            if (elements.Count() < 2) return elements;
            var pivot = rand.Next(elements.Count());
            var val = elements[pivot];
            var lesser = new List<int>();
            var greater = new List<int>();
            for (int i = 0; i < elements.Count(); i++)
            {
                if (i != pivot)
                {
                    if (elements[i].CompareTo(val) < 0)
                    {
                        lesser.Add(elements[i]);
                    }
                    else
                    {
                        greater.Add(elements[i]);
                    }
                }
            }

            var merged = QuickSort(lesser.ToArray());
            var lmerged = merged.ToList();
            lmerged.Add(val);
            lmerged.AddRange(QuickSort(greater.ToArray()));
            return lmerged.ToArray();
        }

        static TransationMetrics QuickSortTM(int[] elements, TransationMetrics TM)
        {
            Random rand = new Random();
            if (elements.Count() < 2)
            {
                TM.BytesUsed = GC.GetTotalMemory(true);
                return TM;
            }
            var pivot = rand.Next(elements.Count());
            var val = elements[pivot];
            var lesser = new List<int>();
            var greater = new List<int>();
            for (int i = 0; i < elements.Count(); i++)
            {
                TM.NumberOfChecks++;
                if (i != pivot)
                {
                    if (elements[i].CompareTo(val) < 0)
                    {
                        TM.NumberOfSwaps++;
                        lesser.Add(elements[i]);
                    }
                    else
                    {
                        TM.NumberOfSwaps++;
                        greater.Add(elements[i]);
                    }
                }
            }

            var merged = QuickSort(lesser.ToArray());
            var lmerged = merged.ToList();
            lmerged.Add(val);
            lmerged.AddRange(QuickSort(greater.ToArray()));
            TM.BytesUsed = GC.GetTotalMemory(true);
            return TM;
        }

        public override string ToString()
        {
            return "Quicksort";
        }
    }
}
