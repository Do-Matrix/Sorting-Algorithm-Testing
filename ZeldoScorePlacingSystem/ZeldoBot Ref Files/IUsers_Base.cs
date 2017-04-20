using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldoScorePlacingSystem.ZeldoBot_Ref_Files
{
    [JsonObject]
    public class Users
    {
        public string UserName = "";
        //public Expansions EX;
        public Inventory INV;
        public Progress Prog;

        
        //public Users() { UserName = "Dummy"; INV = new Inventory(); Prog = new Progress(); }
    }
}
