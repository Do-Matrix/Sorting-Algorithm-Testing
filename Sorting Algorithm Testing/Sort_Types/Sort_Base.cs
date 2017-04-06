using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sorting_Algorithm_Testing.Tests;
using Sorting_Algorithm_Testing;

namespace Sorting_Algorithm_Testing.Sort_Types
{
    public interface ISort_Base
    {
        int[] TimedTest(int[] unsortedArray);
        TransationMetrics TransactionTest(int[] unsortedArray);
        List<Test_Results> InternalResults { get; }
    }
}
