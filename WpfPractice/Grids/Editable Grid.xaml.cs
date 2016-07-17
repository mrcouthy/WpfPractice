using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using WpfPractice.Dynamic;

namespace WpfPractice.Grids
{
    /// <summary>
    /// Interaction logic for Editable_Grid.xaml
    /// </summary>
    public partial class Editable_Grid : Window
    {
        public Editable_Grid()
        {
            InitializeComponent();

        }
        public ViewModel ViewModel = new ViewModel();

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("a");
            dt.Columns.Add("b");
            dt.Rows.Add("1", "2");
            dt.Rows.Add("1", "2");
            adg.ItemsSource = dt.AsDataView();


            // var drp = ControlsFactory.CreateTextBoxMatrix(2,2, aGrid);

        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            List<string> rl = new List<string>();
            rl.Add("a");
            rl.Add("da");
            rl.Add("asdf");
            List<string> cl = new List<string>();
            cl.Add("Ca");
            cl.Add("Cda");
            cl.Add("Casdf");

            var drp = ControlsFactory.CreateComboBoxMatrix( rl, cl);
            matrixContainer.Content = drp;
                //  DataTable dtr = ((DataView)adg.ItemsSource).ToTable();
        }
    }


    public class ViewModel
    {
        public ObservableCollection<Example> Values
        {
            get;
            set;
        }
    }
    public class Example
    {
        public string A
        {
            get;
            set;
        }
        public string B
        {
            get;
            set;
        }
    }
}
