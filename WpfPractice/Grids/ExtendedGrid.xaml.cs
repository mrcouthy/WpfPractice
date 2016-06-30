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
        List<ObjectWithSelect> users = new List<ObjectWithSelect>();
        public ExtendedGrid()
        {
            InitializeComponent();
            var textColumn = ColumnsFactory.GetTextColumn("Name", "Name");
            Apple.ExtGrid.Columns.Add(textColumn);
            Apple.ExtGrid.Columns.Add(ColumnsFactory.GetTextColumn("Birthday", "Birthday"));
            Apple.ExtGrid.Columns.Add(ColumnsFactory.GetDataImageColumn(Apple,"AAA",""));
            var a = new Useri() { Id = 1, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) };
            var b = new Useri() { Id = 1, Name = "Japan Doe", Birthday = new DateTime(1971, 7, 8) };
            var c = new Useri() { Id = 1, Name = "Amrika Doe", Birthday = new DateTime(1971, 7, 2) };
           
            users.Add(b);
            users.Add(c);
            users.Add(a);
            Apple.Datas = users;

            Apple.Row_Clicked += Apple_BoilerEventLog;
           
        }

        private void Apple_BoilerEventLog(object firer)
        {
            Useri user =firer as Useri;
            MessageBox.Show(user.Name);
        }

        private void Getit_Click(object sender, RoutedEventArgs e)
        {
         var z=   Apple.GetSelected();
        }
    }

    public class Useri: ObjectWithSelect
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
