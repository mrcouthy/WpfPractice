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
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = "Name";
            textColumn.Binding = new Binding("Name");
            Apple.ExtGrid.Columns.Add(textColumn);

            DataGridTextColumn bdayColumn = new DataGridTextColumn();
            bdayColumn.Header = "BirthDay";
            bdayColumn.Binding = new Binding("Birthday");
            Apple.ExtGrid.Columns.Add(bdayColumn);

            var a = new UserWithSelecti() { Id = 1, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) };
            var b = new UserWithSelecti() { Id = 1, Name = "Japan Doe", Birthday = new DateTime(1971, 7, 8) };
            var c = new UserWithSelecti() { Id = 1, Name = "Amrika Doe", Birthday = new DateTime(1971, 7, 2) };
           
            users.Add(b);
            users.Add(c);
            users.Add(a);
            Apple.Datas = users;
           
        }
    }
}
