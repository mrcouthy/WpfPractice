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

namespace WpfPractice.Navigate
{
    /// <summary>
    /// Interaction logic for NavigateWindow.xaml
    /// </summary>
    public partial class NavigateWindow : Window
    {
        public NavigateWindow()
        {
            InitializeComponent();
        }
        
        NavigationList<Page> uc;
        private void grid_Loaded(object sender, RoutedEventArgs e)
        {
            uc = new NavigationList<Page>();
            uc.Add(new Page1());
            uc.Add(new Page2());
        }

        private void a_Click(object sender, RoutedEventArgs e)
        {
            grid.Content = uc.MoveNext;
        }

        private void b_Click(object sender, RoutedEventArgs e)
        {
            grid.Content = uc.MovePrevious;
        }
    }
}
