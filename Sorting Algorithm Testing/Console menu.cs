using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Sorting_Algorithm_Testing.Tests;
using Sorting_Algorithm_Testing.Sort_Types;
using Sorting_Algorithm_Testing.Search_Types;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Collections;

namespace Sorting_Algorithm_Testing
{
    class Console_menu
    {
        #region object delcaration
        Bubble bubble = new Bubble();
        Insertion insertion = new Insertion();
        MergeIterative mergeIterative = new MergeIterative();
        MergeRecursive mergeRecursive = new MergeRecursive();
        Radix radix = new Radix();
        Selection selection = new Selection();
        Shell shell = new Shell();
        Binary binary = new Binary();
        BinaryRecursive binaryRecursive = new BinaryRecursive();
        Linear linear = new Linear();
        Test_Compiler compiler = Test_Compiler.load(Test_Compiler.SaveType.JSON);
        const string menuMasterOptions = "Q: Quit\nR: restart";
        #endregion

        #region Prefilled Output basis
        protected string OutputQuestion(string text)
        {
            Console.WriteLine(menuMasterOptions);
            Console.WriteLine(text);
            return Console.ReadLine().ToLower();
        }

        protected string OutputInt(string text)
        {
            Console.WriteLine(text);
            return Console.ReadLine().ToLower();
        }
        #endregion

        #region Menu Master points
        protected void MenuMasterSelections(string selection)
        {
            switch(selection)
            {
                case "q":
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                case "r":
                    Console.Clear();
                    MenuSelectorBase();
                    break;
                default:
                    return;
            }
        }

        public void MenuSelectorBase()
        {
            string selection = OutputQuestion("Select Sorts or Searches: \n1: Sorts\n2: Searches").ToLower();
            switch (selection)
            {
                case "1":
                    Console.Clear();
                    MenuSelectorSorts();
                    break;
                case "2":
                    Console.Clear();
                    MenuSelectorSearches();
                    break;
                default:
                    MenuMasterSelections(selection);
                    Console.WriteLine("Incorrect key pressed, please try again");
                    MenuSelectorBase();
                    break;
            }
        }

        private void MenuSelectorSearches()
        {
            string tstring = OutputQuestion("Select how many sorts you want to compare, or press 'A' to search all sorts:").ToLower();
            MenuMasterSelections(tstring);
            if (tstring != "a")
            {
                try
                {
                    uint numOfSearches = Convert.ToUInt32(tstring);
                    ISearch_Base[] searches = new ISearch_Base[numOfSearches];
                    for (int i = 0; i < (numOfSearches); i++)
                    {
                        Console.Clear();
                        Console.WriteLine(menuMasterOptions);
                        searches[i] = SearchSelector();
                    }
                    Console.Clear();
                    SizeSelector(searches);
                }
                catch (Exception)
                {

                    Console.WriteLine("Invalid entry, please try again.");
                    MenuSelectorSearches();
                }
            }
            else
            {
                ISearch_Base[] searches = { linear, binary, binaryRecursive};
                Console.Clear();
                SizeSelector(searches);
            }
        }

        public void MenuSelectorSorts()
        {
            string tstring = OutputQuestion("Select how many sorts you want to compare, or press 'A' to search all sorts:").ToLower();
            MenuMasterSelections(tstring);
            if (tstring != "a")
            {
                try
                {
                    uint numOfSorts = Convert.ToUInt32(tstring);
                    ISort_Base[] sorts = new ISort_Base[numOfSorts];
                    for (int i = 0; i < (numOfSorts); i++)
                    {
                        Console.Clear();
                        Console.WriteLine(menuMasterOptions);
                        sorts[i] = SortSelector();
                    }
                    Console.Clear();
                    SizeSelector(sorts);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid entry, please try again.");
                    MenuSelectorSorts();
                }
            }
            else
            {
                ISort_Base[] sorts = { bubble, insertion, mergeIterative, mergeRecursive, radix, selection, shell };
                Console.Clear();
                SizeSelector(sorts);
            }
            
        }
        #endregion

        #region Size Selectors
        public void SizeSelector(params ISort_Base[] sorts)
        {
            Console.Clear();
            string tstring = OutputInt("What is the Max size of your sorts?");
            MenuMasterSelections(tstring);
            uint isize = 0;
            if (uint.TryParse(tstring, out isize))
            {
                Console.Clear();
                Iterator(isize, sorts);
            }
            else
            {
                Console.WriteLine("Please input a valid entry.");
                SizeSelector(sorts);
            }
        }

        public void SizeSelector(params ISearch_Base[] searches)
        {
            Console.Clear();
            string tstring = OutputInt("What is the Max size of your searches?");
            MenuMasterSelections(tstring);
            uint isize = 0;
            if (uint.TryParse(tstring, out isize))
            {
                Console.Clear();
                Iterator(isize, searches);
            } else
            {
                Console.WriteLine("Please input a valid entry.");
                SizeSelector(searches);
            }

        }
        #endregion

        #region Iterators
        public void Iterator(uint isize, params ISort_Base[] sorts)
        {
            string tstring = OutputInt("How many tests do you want between size 100 and size " + isize + "?").ToLower();
            int _isize = Convert.ToInt32(isize);
            try
            {
                int iterator = Convert.ToInt32(tstring);
                Console.Clear();
                Action(_isize, iterator, sorts);
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a proper value");
                Iterator(isize, sorts);
            }
        }

        public void Iterator(uint isize, params ISearch_Base[] searches)
        {
            string tstring = OutputInt("How many tests do you want between size 100 and size " + isize + "?").ToLower();
            int _isize = Convert.ToInt32(isize);
            try
            {
                int iterator = Convert.ToInt32(tstring);
                Console.Clear();
                KeySelector(_isize, iterator, searches);
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a proper value");
                Iterator(isize, searches);
            }
        }

        private void KeySelector(int isize, int iterator, ISearch_Base[] searches)
        {
            string tstring = OutputInt("What is the Item you are looking for?").ToLower();
            MenuMasterSelections(tstring);
            try
            {
                uint key = Convert.ToUInt32(tstring);
                int _key = Convert.ToInt32(key);
                Action(isize, iterator, _key, searches);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid value, please enter a positive integer");
                KeySelector(isize, iterator, searches);
            }
        }
        #endregion

        #region Search/Item Selector
        public ISort_Base SortSelector()
        {
            ISort_Base sort = null;
            Console.WriteLine("Select a sort: \n1: Bubble\n2: Insertion\n3: Merge(iterative)\n4: Merge(Recursive)\n5: Radix\n6: Selection\n7: Shell");
            string selectedOption = Console.ReadLine();
            switch (selectedOption)
            {
                case "1":
                    sort = bubble;
                    break;
                case "2":
                    sort = insertion;
                    break;
                case "3":
                    sort = mergeIterative;
                    break;
                case "4":
                    sort = mergeRecursive;
                    break;
                case "5":
                    sort = radix;
                    break;
                case "6":
                    sort = selection;
                    break;
                case "7":
                    sort = shell;
                    break;
                default:
                    MenuMasterSelections(selectedOption);
                    Console.WriteLine("Invalid Character. Please Try again.");
                    SortSelector();
                    break;
            }
            Console.Clear();
            return sort;
        }

        private ISearch_Base SearchSelector()
        {
            ISearch_Base search = null;
            Console.WriteLine("Select a sort: \n1: Linear\n2: Binary(linear)\n3: Binary(recursive)");
            string selectedOption = Console.ReadLine();
            switch (selectedOption)
            {
                case "1":
                    search = linear;
                    break;
                case "2":
                    search = binary;
                    break;
                case "3":
                    search = binaryRecursive;
                    break;
                default:
                    MenuMasterSelections(selectedOption);
                    Console.WriteLine("Invalid Character. Please Try again.");
                    SortSelector();
                    break;
            }
            Console.Clear();
            return search;
        }
        #endregion

        #region Actions
        public bool Action(int isize, int iterations, params ISort_Base[] sorts)
        {
            int maxSize = isize;
            isize = 100;
            int iterator = (maxSize - 100) / iterations;
            try
            {
                for (int i = 0; i < iterations + 1; i++)
                {
                    Console.WriteLine(isize);
                    compiler.Run(RandomGeneration.Int(isize), isize, sorts);
                    isize += iterator;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;
                return false;
            }
            compiler.save(Test_Compiler.SaveType.JSON);
            compiler.CreateExcelFromData(sorts);
            return true;
        }

        public bool Action(int isize, int iterations, int searchItem, params ISearch_Base[] searches)
        {
            int maxSize = isize;
            isize = 100;
            int iterator = (maxSize - 100) / iterations;
            try
            {
                for (int i = 0; i < iterations + 1; i++)
                {
                    Console.WriteLine(isize);
                    compiler.Run(RandomGeneration.Int(isize), isize, searchItem, searches);
                    isize += iterator;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;
                return false;
            }
            compiler.save(Test_Compiler.SaveType.JSON);
            compiler.CreateExcelFromData(searches);
            return true;
        }

        #endregion

    }
}
