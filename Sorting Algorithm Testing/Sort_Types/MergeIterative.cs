using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sorting_Algorithm_Testing.Tests;

namespace Sorting_Algorithm_Testing.Sort_Types
{
    class MergeIterative : ISort_Base
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

        public override string ToString()
        {
            return "Iterative Merge";
        }

        public int[] TimedTest(int[] unsortedArray)
        {
            return BottomUpMergeSort(unsortedArray, unsortedArray.Length);
        }

        public TransationMetrics TransactionTest(int[] unsortedArray)
        {
            TransationMetrics TM = BottomUpMergeSortTM(unsortedArray, (unsortedArray.Length));
            return TM;
        }

        #region external functions
        private static int getMin(int left, int right)
        {
            if (left <= right)
            {
                return left;
            }
            else
            {
                return right;
            }
        }

        void CopyArray(int[] B, int[] A, int n)
        {
            for (int i = 0; i < n; i++)
                A[i] = B[i];
        }
        #endregion

        #region Merge Sort Iterative Normal

        int[] BottomUpMergeSort(int[] A, int n)
        {
            int[] B = new int[A.Length];
            // Each 1-element run in A is already "sorted".
            // Make successively longer sorted runs of length 2, 4, 8, 16... until whole array is sorted.
            for (int width = 1; width < n; width = 2 * width)
            {
                // Array A is full of runs of length width.
                for (int i = 0; i < n; i = i + 2 * width)
                {
                    // Merge two runs: A[i:i+width-1] and A[i+width:i+2*width-1] to B[]
                    // or copy A[i:n-1] to B[] ( if(i+width >= n) )
                    BottomUpMerge(A, i, getMin(i + width, n), getMin(i + 2 * width, n), B);
                }
                // Now work array B is full of runs of length 2width.
                // Copy array B to array A for next iteration.
                // A more efficient implementation would swap the roles of A and B.
                CopyArray(B, A, n);
                // Now array A is full of runs of length 2width.
            }
            return B;
        }

        //  Left run is A[iLeft :iRight-1].
        // Right run is A[iRight:iEnd-1  ].
        void BottomUpMerge(int[] A, int iLeft, int iRight, int iEnd, int[] B)
        {
            int i = iLeft;
            int j = iRight;
            // While there are elements in the left or right runs...
            for (int k = iLeft; k < iEnd; k++)
            {
                // If left run head exists and is <= existing right run head.
                if (i < iRight && (j >= iEnd || A[i] <= A[j]))
                {
                    B[k] = A[i];
                    i = i + 1;
                }
                else
                {
                    B[k] = A[j];
                    j = j + 1;
                }
            }
        }

        #endregion

        #region Merge Sort Iterative Transaction Test

        TransationMetrics BottomUpMergeSortTM(int[] A, int n)
        {
            TransationMetrics TM = new TransationMetrics();
            int[] B = new int[A.Length];
            // Each 1-element run in A is already "sorted".
            // Make successively longer sorted runs of length 2, 4, 8, 16... until whole array is sorted.
            for (int width = 1; width < n; width = 2 * width)
            {
                NumOfChecks++;
                // Array A is full of runs of length width.
                for (int i = 0; i < n; i = i + 2 * width)
                {
                    // Merge two runs: A[i:i+width-1] and A[i+width:i+2*width-1] to B[]
                    // or copy A[i:n-1] to B[] ( if(i+width >= n) )
                    BottomUpMerge(A, i, getMin(i + width, n), getMin(i + 2 * width, n), B);
                }
                // Now work array B is full of runs of length 2width.
                // Copy array B to array A for next iteration.
                // A more efficient implementation would swap the roles of A and B.
                CopyArray(B, A, n);
                // Now array A is full of runs of length 2width.
            }
            TM.BytesUsed = GC.GetTotalMemory(true);
            TM.NumberOfChecks = NumOfChecks;
            TM.NumberOfSwaps = NumOfSwaps;
            return TM;
        }

        //  Left run is A[iLeft :iRight-1].
        // Right run is A[iRight:iEnd-1  ].
        void BottomUpMergeTM(int[] A, int iLeft, int iRight, int iEnd, int[] B)
        {
            int i = iLeft;
            int j = iRight;
            // While there are elements in the left or right runs...
            for (int k = iLeft; k < iEnd; k++)
            {
                NumOfSwaps++;
                // If left run head exists and is <= existing right run head.
                if (i < iRight && (j >= iEnd || A[i] <= A[j]))
                {
                    B[k] = A[i];
                    i = i + 1;
                }
                else
                {
                    B[k] = A[j];
                    j = j + 1;
                }
            }
        }
        #endregion

    }
}
