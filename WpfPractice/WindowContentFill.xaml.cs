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
using WpfPractice.Grids;

namespace WpfPractice
{
    /// <summary>
    /// Interaction logic for WindowContentFill.xaml
    /// </summary>
    public partial class WindowContentFill : Window
    {
        public WindowContentFill()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgrid.ItemsSource=User.GetTestData(90);
        }
    }
}
