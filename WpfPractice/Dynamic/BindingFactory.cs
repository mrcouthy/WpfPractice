using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfPractice.Dynamic
{
   public static class BindingFactory
    {
        public static void CreateDropDownBinding(string property, string selectedProperty, ComboBox ctrl, object source)
        {
            Binding myBinding = new Binding();
            myBinding.Source = source;
            myBinding.Path = new PropertyPath(property);
            myBinding.Mode = BindingMode.TwoWay;


            Binding selectedBinding = new Binding();
            selectedBinding.Source = source;
            selectedBinding.Path = new PropertyPath(selectedProperty);
            selectedBinding.Mode = BindingMode.TwoWay;


            BindingOperations.SetBinding(ctrl, ComboBox.ItemsSourceProperty, myBinding);
            BindingOperations.SetBinding(ctrl, ComboBox.SelectedValueProperty, selectedBinding);

        }


        public static void TextBoxBinding(string property, Control ctrl, object source)
        {
            Binding myBinding = new Binding();
            myBinding.Source = source;
            myBinding.Path = new PropertyPath(property);
            myBinding.Mode = BindingMode.TwoWay;
            BindingOperations.SetBinding(ctrl, TextBox.TextProperty, myBinding);
        }

        public static void CheckBoxBinding(string property, Control ctrl, object source)
        {
            Binding myBinding = new Binding();
            myBinding.Source = source;
            myBinding.Path = new PropertyPath(property);
            myBinding.Mode = BindingMode.TwoWay;
            BindingOperations.SetBinding(ctrl, CheckBox.IsCheckedProperty, myBinding);
        }

        public static void RadioButtonBinding(string property, Control ctrl, object source)
        {
            Binding myBinding = new Binding();
            myBinding.Source = source;
            myBinding.Path = new PropertyPath(property);
            myBinding.Mode = BindingMode.TwoWay;
            BindingOperations.SetBinding(ctrl, RadioButton.IsCheckedProperty, myBinding);
        }
    }
}
