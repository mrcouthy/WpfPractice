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

        List<ObjectWithSelect> _Datas = new List<ObjectWithSelect>();

        public List<ObjectWithSelect> Datas
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

        internal List<ObjectWithSelect> GetSelected()
        {
            var x = (from ObjectWithSelect us in Datas
                     where us.IsSelected
                     select us).ToList();
            return x;
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
        public delegate void SendTheClickedObject(object status);
        public event SendTheClickedObject Row_Clicked;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var button = (FrameworkElement)sender;
            //User obj = ((FrameworkElement)sender).DataContext as User;
            Row_Clicked(((FrameworkElement)sender).DataContext);
        }
    }

    public class ObjectWithSelect :  INotifyPropertyChanged
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


    public static class ColumnsFactory
    {

        public static DataGridTextColumn AddTextColumn(this ExtendedGridControl extGrid, string HeaderText, string Binding)
        {
            var column = extGrid.GetTextColumn(HeaderText, Binding);
            extGrid.ExtGrid.Columns.Add(column);
            return column;
        }

        public static DataGridComboBoxColumn AddComboBoxColumn(this ExtendedGridControl extGrid, string HeaderText, string Binding)
        {
            var column = extGrid.GetComboBoxColumn(HeaderText, Binding);
            extGrid.ExtGrid.Columns.Add(column);
            return column;
        }

        public static DataGridCheckBoxColumn AddDataGridCheckBoxColumn(this ExtendedGridControl extGrid, string HeaderText, string Binding)
        {
            var column = extGrid.GetDataGridCheckBoxColumn(HeaderText, Binding);
            extGrid.ExtGrid.Columns.Add(column);
            return column;
        }

        public static DataGridTemplateColumn AddDataImageColumn(this ExtendedGridControl extGrid, string HeaderText, string Binding)
        {
            var column = extGrid.GetDataImageColumn(HeaderText, Binding);
            extGrid.ExtGrid.Columns.Add(column);
            return column;
        }


        public static DataGridTextColumn GetTextColumn(this ExtendedGridControl extGrid ,string HeaderText, string Binding)
        {
            DataGridTextColumn column = new DataGridTextColumn();
            column.Header = HeaderText;
            column.Binding = new Binding(Binding);
            column.IsReadOnly = true;
            return column;
        }

        public static DataGridComboBoxColumn GetComboBoxColumn(this ExtendedGridControl extGrid, string HeaderText, string Binding)
        {
            DataGridComboBoxColumn column = new DataGridComboBoxColumn();
            column.Header = HeaderText;

            column.IsReadOnly = true;
            return column;
        }

        public static DataGridCheckBoxColumn GetDataGridCheckBoxColumn(this ExtendedGridControl extGrid, string HeaderText, string Binding)
        {
            DataGridCheckBoxColumn column = new DataGridCheckBoxColumn();
            column.Header = HeaderText;
            column.Binding = new Binding(Binding);
            column.IsReadOnly = true;
            return column;
        }

        public static DataGridTemplateColumn GetDataImageColumn(this ExtendedGridControl extGrid, string HeaderText, string Binding)
        {
            DataGridTemplateColumn column = (DataGridTemplateColumn)extGrid.FindResource("dgt");
            column.Header = HeaderText;
            column.IsReadOnly = true;
            return column;
        }
    }
}
