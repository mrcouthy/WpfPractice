using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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

        public List<Person2> personsList { get; set; }
        public Person2 selectedPerson { get; set; }
        Person2 p = new Person2 { Name = "Dhiraj", IsSelected = true, IsGood = true, IsBad = true };

        int j = 0;

        TextBox tb;
        CheckBox cb;
        RadioButton rb;
        RadioButton rb2;
        ComboBox drp;

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

            personsList = new List<Person2> {
            new Person2 { Name = "Dhiraj", IsSelected = true, IsGood = true, IsBad = false  } ,
                new Person2 { Name = "Pankaj", IsSelected = false , IsGood = true, IsBad = true } ,
                new Person2 { Name = "Stark", IsSelected = true, IsGood = false , IsBad = true }
        };

            selectedPerson = personsList[2];
            rootGrid.RowDefinitions.Add(ControlsFactory.CreateRowDefinition());
            tb = ControlsFactory.CreateTextBox(j, 0);
            rootGrid.Children.Add(tb);
            j++;

            rootGrid.RowDefinitions.Add(ControlsFactory.CreateRowDefinition());
            cb = ControlsFactory.CreateCheckBox(j, 1);
            rootGrid.Children.Add(cb);
            j++;

            rootGrid.RowDefinitions.Add(ControlsFactory.CreateRowDefinition());
            rb = ControlsFactory.CreateRadioBox(j, 1);
            rootGrid.Children.Add(rb);
            j++;

            rootGrid.RowDefinitions.Add(ControlsFactory.CreateRowDefinition());
            rb2 = ControlsFactory.CreateRadioBox(j, 1);
            rootGrid.Children.Add(rb2);
            j++;

            rootGrid.RowDefinitions.Add(ControlsFactory.CreateRowDefinition());
            drp = ControlsFactory.CreateComboBox(j, 1);
            drp.DisplayMemberPath = "Name";

            rootGrid.Children.Add(drp);
            j++;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BindingFactory.TextBoxBinding("Name", tb, p);
            BindingFactory.CheckBoxBinding("IsSelected", cb, p);
            BindingFactory.RadioButtonBinding("IsGood", rb, p);
            BindingFactory.RadioButtonBinding("IsBad", rb2, p);

            BindingFactory.CreateDropDownBinding("personsList", "selectedPerson", drp, this);
        }

        private void Button_ChangeClick(object sender, RoutedEventArgs e)
        {
            p.Name = "Abc";
        }

        private void Button_GetChangeClick(object sender, RoutedEventArgs e)
        {
            string selectedperson = selectedPerson.Name;
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
