using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace WpfPractice.Grids
{
    /// <summary>
    /// Interaction logic for TestGrid.xaml
    /// </summary>
    public partial class TestGrid : Window
    {
        ObservableCollection<UserWithSelect> users = new ObservableCollection<UserWithSelect>();
        public TestGrid()
        {
            InitializeComponent();
            users.Add(new UserWithSelect() { Id = 1, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) });
            users.Add(new UserWithSelect() { Id = 2, Name = "Jane Doe", Birthday = new DateTime(1974, 1, 17) });
            users.Add(new UserWithSelect() { Id = 3, Name = "Sammy Doe", Birthday = new DateTime(1991, 9, 2), IsSelected = true });
            ucCon.dgMain.ItemsSource = users;
            dgTest.ItemsSource = users;
        }

        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime Birthday { get; set; }
        }
        public class UserWithSelect: User,INotifyPropertyChanged
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

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var item in users)
            {
                item.IsSelected = true;
            }
        }
        
        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            foreach (var item in users)
            {
                item.IsSelected = false;
            }
        }
    }
}
