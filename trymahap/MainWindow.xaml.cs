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

namespace trymahap
{
    using System.Threading;
    using MahApps.Metro.Controls.Dialogs;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            isLoading = false;
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            isLoading = true;
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Hi",
                NegativeButtonText = "Go away!",
                FirstAuxiliaryButtonText = "Cancel",
                MaximumBodyHeight = 100,
                ColorScheme = MetroDialogOptions.ColorScheme
            };

            MessageDialogResult result = await this.ShowMessageAsync("Hello!", "Welcome to the world of metro!" + string.Join(Environment.NewLine, "abc", "def", "ghi", "jkl", "mno", "pqr", "stu", "vwx", "yz"),
                MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary, mySettings);

            if (result != MessageDialogResult.FirstAuxiliary)
                await this.ShowMessageAsync("Result", "You said: " + (result == MessageDialogResult.Affirmative ? mySettings.AffirmativeButtonText : mySettings.NegativeButtonText +
                    Environment.NewLine + Environment.NewLine + "This dialog will follow the Use Accent setting."));
        }

        public bool isLoading
        {
            get { return LoadingSymbol.IsVisible; }
            set
            {
                LoadingSymbol.Visibility = value ? Visibility.Visible : Visibility.Hidden;
            }
        }



        private async Task<int> ALongProccess()
        {
            isLoading = true;
            Thread.Sleep(9000);
            MessageBox.Show("ola");
            return 1 ;
        }

        private async void ButtonBase1_OnClick(object sender, RoutedEventArgs e)
        {
            
         int a=   await ALongProccess();
            isLoading = false;
        }
    }
}
