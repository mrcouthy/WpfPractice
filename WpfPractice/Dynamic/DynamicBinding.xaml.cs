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

namespace WpfPractice.Dynamic
{
    /// <summary>
    /// Interaction logic for DynamicBinding.xaml
    /// </summary>
    public partial class DynamicBinding : Window
    {
        public DynamicBinding()
        {
            InitializeComponent();

            rootGrid.ColumnDefinitions.Add(
               new ColumnDefinition() { Width = new GridLength(100.0) });
            rootGrid.ColumnDefinitions.Add(
                 new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
        }




        #region Private

        private CheckBox CreateCheckBox(int row, int column)
        {
            CheckBox tb = new CheckBox();
            tb.Margin = new Thickness(5);
            tb.Height = 22;
            tb.Width = 150;
            Grid.SetColumn(tb, column);
            Grid.SetRow(tb, row);
            return tb;
        }
        private RadioButton CreateRadioBox(int row, int column)
        {
            RadioButton tb = new RadioButton();
            tb.Margin = new Thickness(5);
            tb.Height = 22;
            tb.Width = 150;
            Grid.SetColumn(tb, column);
            Grid.SetRow(tb, row);
            return tb;
        }
        private TextBox CreateTextBox(int row, int column)
        {
            TextBox tb = new TextBox();
            tb.Margin = new Thickness(5);
            tb.Height = 22;
            tb.Width = 150;
            Grid.SetColumn(tb, column);
            Grid.SetRow(tb, row);
            return tb;
        }

        private RowDefinition CreateRowDefinition()
        {
            var rowDefinition = new RowDefinition();
            rowDefinition.Height = GridLength.Auto;
            // grid.RowDefinitions.Add(rowDefinition);
            return rowDefinition;
        }
        int j = 0;
        TextBox tb;
        CheckBox cb;
        RadioButton rb;
        RadioButton rb2;
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

            rootGrid.RowDefinitions.Add(CreateRowDefinition());
            tb = CreateTextBox(j, 0);
            rootGrid.Children.Add(tb);
            j++;

            rootGrid.RowDefinitions.Add(CreateRowDefinition());
            cb = CreateCheckBox(j, 1);
            rootGrid.Children.Add(cb);
            j++;

            rootGrid.RowDefinitions.Add(CreateRowDefinition());
            rb = CreateRadioBox(j, 1);
            rootGrid.Children.Add(rb);
            j++;

            rootGrid.RowDefinitions.Add(CreateRowDefinition());
            rb2 = CreateRadioBox(j, 1);
            rootGrid.Children.Add(rb2);
            j++;


        }





        #endregion

        private void rootGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //binding


        }
        Person2 p = new Person2 { Name = "Dhiraj",IsSelected=true,IsGood =true ,IsBad=true};
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBoxBinding("Name", tb, p);
            CheckBoxBinding("IsSelected", cb, p);
            RadioButtonBinding("IsGood", rb, p);
            RadioButtonBinding("IsBad", rb2, p);
        }

        private void TextBoxBinding(string property, Control ctrl, object source)
        {
            Binding myBinding = new Binding();
            myBinding.Source = source;
            myBinding.Path = new PropertyPath(property);
            myBinding.Mode = BindingMode.TwoWay;
            BindingOperations.SetBinding(ctrl, TextBox.TextProperty, myBinding);
        }

        private void CheckBoxBinding(string property, Control ctrl, object source)
        {
            Binding myBinding = new Binding();
            myBinding.Source = source;
            myBinding.Path = new PropertyPath(property);
            myBinding.Mode = BindingMode.TwoWay;
            BindingOperations.SetBinding(ctrl, CheckBox.IsCheckedProperty, myBinding);
        }

        private void RadioButtonBinding(string property, Control ctrl, object source)
        {
            Binding myBinding = new Binding();
            myBinding.Source = source;
            myBinding.Path = new PropertyPath(property);
            myBinding.Mode = BindingMode.TwoWay;
            BindingOperations.SetBinding(ctrl, RadioButton.IsCheckedProperty, myBinding);
        }


        private void Button_ChangeClick(object sender, RoutedEventArgs e)
        {
            p.Name = "Abc";
        }

        private void Button_GetChangeClick(object sender, RoutedEventArgs e)
        {
            string name = p.Name;
        }
    }

    public class Person2
    {
        public bool IsGood { get; set; }
        public bool IsBad { get; set; }
        public bool IsSelected { get; set; }
        public string Name { get; set; }
    }

}
