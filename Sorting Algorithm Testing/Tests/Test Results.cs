using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Sorting_Algorithm_Testing.Search_Types;
using Sorting_Algorithm_Testing.Sort_Types;

namespace Sorting_Algorithm_Testing.Tests
{

    [Serializable]
    public class Test_Results
    {
        public string Type = "";
        public string Name = "";
        public int Size = 0;
        public string ElapsedTime = "";
        public TransationMetrics Transaction_Metrics;
    }


}
