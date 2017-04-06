using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Sorting_Algorithm_Testing.Tests;
using Sorting_Algorithm_Testing.Sort_Types;
using Sorting_Algorithm_Testing.Search_Types;
using System.Diagnostics;
using System.Collections;

namespace Sorting_Algorithm_Testing
{
    class Program
    {
        const int maxPower = 5;
        const int MaxSize = 100000;
        const int Tests = 25;
        const int StartSize = 100;
        static void Main(string[] args)
        {
            Console_menu Menu = new Console_menu();
            Menu.MenuSelectorBase();

        }
    }
}
