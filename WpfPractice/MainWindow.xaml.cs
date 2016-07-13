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
            NumberTextBox.PreviewTextInput += NumberTextBox_PreviewTextInput;
        }

        private void NumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            Regex regex = new Regex(@"^[\p{N}\.]+$");
            var validnumber = regex.IsMatch(e.Text);
            
            if (text.Contains(".") && e.Text ==".")
            {
                validnumber = false;
            }
            
            e.Handled = !validnumber;
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
            new DynamicBinding().Show();
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

        private void DynamicBinding(object sender, RoutedEventArgs e)
        {
            new DynamicBinding().Show();
        }


    }
}
