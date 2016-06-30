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
using WpfPractice.Dynamic;
using WpfPractice.Grids;

namespace WpfPractice
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

        private void Button_Click_UserControls(object sender, RoutedEventArgs e)
        {
            var uc = new UserControls();
            uc.Show();
        }


        private void Button_Click_GridwithCheckBox(object sender, RoutedEventArgs e)
        {
            new TestGrid().Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            new LotDynamic().Show();
        }

        private void StyleExample(object sender, RoutedEventArgs e)
        {
            new StyleExample().Show();
        }

        private void ThreadUIEXample(object sender, RoutedEventArgs e)
        {
           
            new ThreadUIExample().Show();
        }

        private void DynamicControls(object sender, RoutedEventArgs e)
        {
            new Dynamic.DynamicControls().Show();
        }

        private void NavigationWindow(object sender, RoutedEventArgs e)
        {
            new Navigate.NavigateWindow().Show();
        }

        private void Templates(object sender, RoutedEventArgs e)
        {
            new Window1().Show();
        }

        private void ExtendedGrid(object sender, RoutedEventArgs e)
        {
            new ExtendedGrid().Show();
        }
    }
}
