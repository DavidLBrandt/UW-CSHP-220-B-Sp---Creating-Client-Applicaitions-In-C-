using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for NavigatorWindow.xaml
    /// </summary>
    public partial class NavigatorWindow : Window
    {
        public NavigatorWindow()
        {
            InitializeComponent();
        }

        private void UxGo_Click(object sender, RoutedEventArgs e)
        {
            // Convert the Uri into a string
            var fileName = uxAddress.Text;

            // Pass the fileName to the helper class
            var processStartInfo = new ProcessStartInfo(fileName);

            // Start a new process
            Process.Start(processStartInfo);

        }
    }
}
