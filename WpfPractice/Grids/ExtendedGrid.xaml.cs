using System;
using System.Collections.Generic;

using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfPractice.Grids
{
    /// <summary>
    /// Interaction logic for ExtendedGrid.xaml
    /// </summary>
    public partial class ExtendedGrid : Window
    {
        List<UserWithSelecti> users = new List<UserWithSelecti>();
        public ExtendedGrid()
        {
            InitializeComponent();
            var textColumn = ColumnsFactory.GetTextColumn("Name", "Name");
            Apple.ExtGrid.Columns.Add(textColumn);
            Apple.ExtGrid.Columns.Add(ColumnsFactory.GetTextColumn("Birthday", "Birthday"));

            var a = new Useri() { Id = 1, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) };
            var b = new Useri() { Id = 1, Name = "Japan Doe", Birthday = new DateTime(1971, 7, 8) };
            var c = new Useri() { Id = 1, Name = "Amrika Doe", Birthday = new DateTime(1971, 7, 2) };
           
            users.Add(b);
            users.Add(c);
            users.Add(a);
            Apple.Datas = users;
           
        }

        private void Getit_Click(object sender, RoutedEventArgs e)
        {
         var z=   Apple.GetSelected();
        }
    }


    

    public class Useri: UserWithSelecti
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
