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
using Sorting_Algorithm_Testing.Search_Types;
using Sorting_Algorithm_Testing.Tests;
using Sorting_Algorithm_Testing.Sort_Types;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        SearchSortViewModel SSVM = new SearchSortViewModel();

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SSVM.Type = (sender as ComboBox).SelectedItem.ToString();
        }
    }
}
