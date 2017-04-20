using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldoScorePlacingSystem.ZeldoBot_Ref_Files
{
    [JsonObject]
    public class Progress
    {
        public Pre_Deku_Tree pre_deku;
        public Deku_Tree deku;
        public After_Deku_Tree after_deku;
        public Optional_After_Deku_Tree optional_after_deku;
    }

    [JsonObject]
    public class Pre_Deku_Tree
    {
        public bool Obtained_Kokiri_Sword = false;
        public bool Obtained_Deku_Shield = false;
        public bool Completed_Pre_Deku()
        {
            switch (new[] { Obtained_Deku_Shield, Obtained_Kokiri_Sword }.All(x => x == true))
            {
                case true:
                    return true;
                default:
                    return false;
            }
        }
    }

    [JsonObject]
    public class Deku_Tree
    {
        public bool Entered_Deku_Tree = false;
        public bool Obtained_First_Deku_Stick = false;
        public bool Obtained_First_Deku_Nut = false;
        public bool Obtained_First_Deku_Seed = false;
        public bool Completed_Deku_Tree()
        {
            switch (new[] { Entered_Deku_Tree, Obtained_First_Deku_Seed, Obtained_First_Deku_Nut, Obtained_First_Deku_Stick }.All(x => x == true))
            {
                case true:
                    return true;
                default:
                    return false;
            }
        }
    }

    [JsonObject]
    public class After_Deku_Tree
    {
        public bool Obtained_Fairy_Ocarina = false;
        public bool Gorons_Bracelet = false;
        public bool weirdegg = false;
        public bool After_Deku_Done()
        {
            switch (new[] { Obtained_Fairy_Ocarina, Gorons_Bracelet, weirdegg }.All(x => x == true))
            {
                case true:
                    return true;
                default:
                    return false;
            }
        }
    }

    [JsonObject]
    public class Optional_After_Deku_Tree
    {
        public bool silver_Scale = false;
        public bool First_Bottle = false;
        public bool ruto_letter = false;
        public bool dekuseed_bag_upgrade1 = false;
        public bool dekuseed_bag_upgrade2 = false;
        public bool dekustick_upgrade1 = false;
        public bool dekustick_upgrade2 = false;
        public bool keaton_mask = false;
        public bool hylian_shield = false;
        public bool Second_Bottle = false;
        public bool Optional_After_Deku_Done()
        {
            switch(new[] { silver_Scale, First_Bottle, ruto_letter, dekuseed_bag_upgrade1, dekuseed_bag_upgrade2, dekustick_upgrade1, dekustick_upgrade2, keaton_mask, hylian_shield, Second_Bottle}.All(x => x == true))
            {
                case true:
                    return true;
                default:
                    return false;
            }
        }
    }
}
