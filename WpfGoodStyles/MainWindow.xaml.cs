using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfGoodStyles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<User> users = new List<User>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           

            var a = new User() { Id = 1, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) };
            var b = new User() { Id = 1, Name = "Japan Doe", Birthday = new DateTime(1971, 7, 8) };
            var c = new User() { Id = 1, Name = "Amrika Doe", Birthday = new DateTime(1971, 7, 2) };
            users.Add(b);
            users.Add(c);
            users.Add(a);
            dataGrid.ItemsSource = users;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (dataGrid!=null)
            {
                TextBox textBoxName = (TextBox)sender;
                string filterText = textBoxName.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);

                if (string.IsNullOrEmpty(filterText))
                {
                    cv.Filter = null;
                }
                else
                {
                    cv.Filter = o =>
                    {
                        /* change to get data row value */
                        User p = o as User;
                        return (p.Name.ToUpper().StartsWith(filterText.ToUpper()));
                        /* end change to get data row value */
                    };
                }
            }
           
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
