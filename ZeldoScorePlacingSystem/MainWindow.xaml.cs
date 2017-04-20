using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Sorting_Algorithm_Testing;
using Sorting_Algorithm_Testing.Sort_Types;
using Sorting_Algorithm_Testing.Tests;
using ZeldoScorePlacingSystem;
using ZeldoScorePlacingSystem.ZeldoBot_Ref_Files;

namespace ZeldoScorePlacingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserLoadManager CompiledUsers = UserLoadManager.Load();
        public MainWindow()
        {
            List<Users> users = new List<ZeldoBot_Ref_Files.Users>();
            //CompiledUsers = UserLoadManager.Load();
            InitializeComponent();
            users.Add(new ZeldoBot_Ref_Files.Users()
            {
                UserName = "Do_Matrix",
                INV = new Inventory()
                {
                    deku = new Deku_Items()
                    {
                        Carried_Deku_Nuts = 0,
                        Carried_Deku_Seeds = 0,
                        Carried_Deku_Sticks = 0
                    }
                },
                Prog = new Progress()
                {
                    pre_deku = new Pre_Deku_Tree()
                    {
                        Obtained_Deku_Shield = true,
                        Obtained_Kokiri_Sword = true
                    },
                    deku = new Deku_Tree()
                    {
                        Entered_Deku_Tree = true,
                        Obtained_First_Deku_Nut = true,
                        Obtained_First_Deku_Seed = true,
                        Obtained_First_Deku_Stick = true
                    },
                    after_deku = new After_Deku_Tree()
                    {
                        Gorons_Bracelet = true,
                        Obtained_Fairy_Ocarina = true,
                        weirdegg = true
                    },
                    optional_after_deku = new Optional_After_Deku_Tree()
                    {
                        dekuseed_bag_upgrade1 = true,
                        dekuseed_bag_upgrade2 = true,
                        dekustick_upgrade1 = true,
                        dekustick_upgrade2 = true,
                        First_Bottle = true,
                        hylian_shield = true,
                        keaton_mask = true,
                        ruto_letter = true,
                        Second_Bottle = true,
                        silver_Scale = true
                    }
                }
            });
            CompiledUsers.Users = users;
            CompiledUsers.save();
            //List<string> usernames = CompiledUsers.Users.Select(usernam);
            //CompiledUsers.Initializer(CompiledUsers.Users);
            //CompiledUsers.save();
            //Users.DataContext = CompiledUsers.Users;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
