using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZeldoScorePlacingSystem.ZeldoBot_Ref_Files
{
    [JsonObject]
    public class Inventory
    {
        public Deku_Items deku;

    }

    [JsonObject]
    public class Deku_Items
    {
        public short Carried_Deku_Sticks = 0;
        public short Carried_Deku_Nuts = 0;
        public short Carried_Deku_Seeds = 0;
    }
}
