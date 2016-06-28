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
using System.ComponentModel;
using System.Diagnostics;


namespace WpfPractice.Grids
{
    /// <summary>
    /// Interaction logic for ExtendedGridControl.xaml
    /// </summary>
    public partial class ExtendedGridControl : UserControl
    {
        public ExtendedGridControl()
        {
            InitializeComponent();

        }

        List<UserWithSelecti> _Datas = new List<UserWithSelecti>();

        public List<UserWithSelecti> Datas
        {
            get { return _Datas; }
            set
            {
                _Datas = value;
                foreach (var item in _Datas)
                {
                    item.PropertyChanged += A_PropertyChanged;
                }
                ExtGrid.ItemsSource = _Datas;
            }
        }
        long i = 0;
        bool fromProgram = false;
        private void A_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Debug.Print((++i).ToString());
            fromProgram = true;
            if (Datas.Any(u => u.IsSelected))
            {
                if (Datas.Any(u => !u.IsSelected))
                {
                    HeaderCheckBox.IsChecked = null;
                }
                else
                {
                    HeaderCheckBox.IsChecked = true;
                }
            }
            else
            {
                HeaderCheckBox.IsChecked = false;
            }
            fromProgram = false;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (!fromProgram)
            {
                foreach (var item in Datas)
                {
                    item.IsSelected = true;
                }
            }
        }

        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            if (!fromProgram)
            {
                foreach (var item in Datas)
                {
                    item.IsSelected = false;
                }
            }
        }
    }

    public class Useri
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }

    public class UserWithSelecti : Useri, INotifyPropertyChanged
    {
        //caviyar
        //DataGridCheckBoxColumn IsReadOnly="False" 
        bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                this.OnPropertyChanged("IsSelected");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
