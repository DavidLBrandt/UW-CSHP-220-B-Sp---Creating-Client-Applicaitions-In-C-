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
using System.Windows.Shapes;
using System.Data.Entity;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for CombowWindow.xaml
    /// </summary>
    public partial class CombowWindow : Window
    {
        public CombowWindow()
        {
            InitializeComponent();

            var sample = new SampleEntities();
            sample.Users.Load();
            uxComboBox.ItemsSource = sample.Users.Local;
        }

        private void UxListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            uxGrid.DataContext = e.AddedItems[0];
        }
    }


}
