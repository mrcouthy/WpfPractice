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
    /// Interaction logic for LotDynamic.xaml
    /// </summary>
    public partial class LotDynamic : Window
    {
        public LotDynamic()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            myTab.Items.Clear();

            var args = viewModel.Arguments;
            var groups = args.GroupBy(arg => arg.Groups);

            foreach (var group in groups)
            {
                TabItemExt tab = new TabItemExt();
                tab.Header = group.Key;

                Grid grid = new Grid();

                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());

                int count = 0;
                foreach (var argument in group)
                {
                    RowDefinition newRow = new RowDefinition();
                    grid.RowDefinitions.Insert(count, newRow);

                    LabelTextBlock label = new LabelTextBlock();
                    label.Text = argument.DisplayName;

                    Grid.SetRow(label, count);
                    Grid.SetColumn(label, 0);

                    TextBox textBox = new TextBox();
                    var binding = new Binding();
                    binding.Source = viewModel.Arguments[argument.Name];
                    //binding.Source = argument
                    binding.Path = new PropertyPath("Value");

                    textBox.SetBinding(TextBlock.TextProperty, binding);

                    Grid.SetRow(textBox, count);
                    Grid.SetColumn(textBox, 1);

                    grid.Children.Add(label);
                    grid.Children.Add(textBox);
                    count += 1;
                }

                tab.Content = grid;
                myTab.Items.Add(tab);
            }
        }
    }
}
