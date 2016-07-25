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
using MahApps.Metro.Controls.Dialogs;
namespace trymahap
{
    using System.Collections;
    using System.ComponentModel;
    using System.Threading;
    using MahApps.Metro.Controls;
    using MahApps.Metro.Controls.Dialogs;
    using System.Globalization;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            isLoading = false;
        }

     
        public string HomePhone { get; set; }

        private async void ButtonMahDialogOnClick(object sender, RoutedEventArgs e)
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
            return 1;
        }

        private async void ButtonLongProcess_OnClick(object sender, RoutedEventArgs e)
        {
            var mySettings = new MetroDialogSettings()
            {
                NegativeButtonText = "Close now",
                AnimateShow = false,
                AnimateHide = false
            };

            var controller = await this.ShowProgressAsync("Please wait...", "We are baking some cupcakes!", settings: mySettings);
            controller.SetIndeterminate();

            await TaskEx.Delay(5000);

            controller.SetCancelable(true);

            double i = 0.0;
            while (i < 6.0)
            {
                double val = (i / 100.0) * 20.0;
                controller.SetProgress(val);
                controller.SetMessage("Baking cupcake: " + i + "...");

                if (controller.IsCanceled)
                    break; //canceled progressdialog auto closes.

                i += 1.0;

                await TaskEx.Delay(2000);
            }

            await controller.CloseAsync();

            if (controller.IsCanceled)
            {
                await this.ShowMessageAsync("No cupcakes!", "You stopped baking!");
            }
            else
            {
                await this.ShowMessageAsync("Cupcakes!", "Your cupcakes are finished! Enjoy!");
            }
        }

       

        private async void ButtonCustomDialog_OntestClick(object sender, RoutedEventArgs e)
        {
            var dialog = new Window1();
            await this.ShowMetroDialogAsync(dialog);
        }

        private async void ButtonBackgorungWorker_OntestClick(object sender, RoutedEventArgs e)
        {
            var dialog = new BackGroundWorkingDialog { };
            dialog.Processor = new AboveIt()
            {
                Processor = new SlowProcessor(50),
                TotalIterations = 50
            };
            dialog.Show();
        }
    }

    public class AboveIt:IAboveIt

    {
        public IEnumerable<int> Processor { get; set; }
        public int TotalIterations { get; set; }
    }

   
    public class SlowProcessor : IEnumerable<int>
    {
        private int currentPosition;
        private int totalIterations;

        public SlowProcessor(int iterations)
        {
            totalIterations = iterations;
        }

        public IEnumerator<int> GetEnumerator()
        {
            currentPosition = 0;
            while (currentPosition < totalIterations)
            {
                Thread.Sleep(100);
                currentPosition++;
                yield return currentPosition;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }


    public class RegexValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Expression == null)
                return ValidationResult.ValidResult;

            Regex m_RegEx = new Regex(Expression);
            Match match = m_RegEx.Match(value.ToString());
            if (match == null || match == Match.Empty)
                return new ValidationResult(false, "Invalid input format");
            else
                return ValidationResult.ValidResult;
        }

        public string Expression { get; set; }

    }
   
}
