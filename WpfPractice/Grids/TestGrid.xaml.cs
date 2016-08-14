using System;
using System.Collections.Generic;

using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace WpfPractice.Grids
{
    /// <summary>
    /// Interaction logic for TestGrid.xaml
    /// </summary>
    public partial class TestGrid : Window
    {
        List<UserWithSelect> users = new List<UserWithSelect>();
        public TestGrid()
        {
            InitializeComponent();
            var a = new UserWithSelect() { Id = 1, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) };
            a.PropertyChanged += A_PropertyChanged;
            var b = new UserWithSelect() { Id = 1, Name = "Japan Doe", Birthday = new DateTime(1971, 7, 8) };
            b.PropertyChanged += A_PropertyChanged;
            var c = new UserWithSelect() { Id = 1, Name = "Amrika Doe", Birthday = new DateTime(1971, 7, 2) };
            c.PropertyChanged += A_PropertyChanged;
            users.Add(b);
            users.Add(c);
            users.Add(a);
            ucCon.dgMain.ItemsSource = users;
            dgTest.ItemsSource = users;

            dataGrid.ItemsSource = users;
        }
        long i = 0;
        bool fromProgram = false;
        private void A_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Debug.Print((++i).ToString());
            fromProgram = true;
            if (users.Any(u => u.IsSelected))
            {
                if (users.Any(u=>!u.IsSelected))
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
                foreach (var item in users)
                {
                    item.IsSelected = true;
                }
            }
        }
        
        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            if (!fromProgram)
            {
                foreach (var item in users)
                {
                    item.IsSelected = false;
                }
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            var button = (FrameworkElement)sender;
            User obj = ((FrameworkElement)sender).DataContext as User;
            MessageBox.Show("You have clicked " + obj.Name);
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public static List<User> GetTestData(int noOfAdditionalRows=0)
        {
            List<User> users = new List<User>();
            var a = new User() { Id = 1, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) };
            var b = new User() { Id = 1, Name = "Japan Doe", Birthday = new DateTime(1971, 7, 8) };
            var c = new User() { Id = 1, Name = "Amrika Doe", Birthday = new DateTime(1971, 7, 2) };
            users.Add(b);
            users.Add(c);
            users.Add(a);
            for (int i = 0; i < noOfAdditionalRows; i++)
            {
                users.Add(c);
            }
            return users;
        }
    }

    public class UserWithSelect : User, INotifyPropertyChanged
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
