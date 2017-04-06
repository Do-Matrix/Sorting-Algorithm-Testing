using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sorting_Algorithm_Testing.Tests;
using Sorting_Algorithm_Testing;

namespace Sorting_Algorithm_Testing.Search_Types
{
    public interface ISearch_Base
    {
        int TimedTest(int[] unsortedArray, int start, int isize, int item);
        TransationMetrics TransactionTest(int[] unsortedArray, int start, int isize, int item);
        List<Test_Results> InternalResults { get; }
    }
}
