using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CSHP22B_HW4_ZipCodeTextBox
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

        private static bool IsTextAllowed(string text)
        {
            Regex _usZipRegEx = new Regex( @"^\d{5}(?:[-\s]\d{4})?$" );
            Regex _caZipRegEx = new Regex( @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$" );

            return _usZipRegEx.IsMatch(text) || _caZipRegEx.IsMatch(text);
        }

        private void UiSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submitted!");
        }

        private void UiZipCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsTextAllowed(uiZipCode.Text))
            {
                uiSubmit.IsEnabled = true;
            }
            else
            {
                uiSubmit.IsEnabled = false;
            }
        }
    }
}
