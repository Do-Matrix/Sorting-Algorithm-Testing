using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithm_Testing
{
    class RandomGeneration
    {
        public static int[] Int(int size)
        {
            Random Generation = new Random(8848);
            int[] generatedList = new int[size];
            generatedList[0] = Generation.Next(size);
            for (int i = 1; i < size; i++)
            {
                var tempint = Convert.ToInt32(generatedList[i - 1]);
                generatedList[i] = tempint + Generation.Next(1, Convert.ToInt32((Math.Sqrt(size) * 10)));
            }
            for (int j = 0; j < size; j++)
            {
                Swap(generatedList, j, Generation.Next(size));
            }
            return generatedList;
        }
        static void Swap(int[] array, int a, int b)
        {
            var temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}
