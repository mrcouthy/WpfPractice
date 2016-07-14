using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfPractice.Dynamic
{
    public static class ControlsFactory
    {

        #region Private

        public static CheckBox CreateCheckBox(int row, int column)
        {
            CheckBox tb = new CheckBox();
            tb.Margin = new Thickness(5);
            tb.Height = 22;
            tb.Width = 150;
            Grid.SetColumn(tb, column);
            Grid.SetRow(tb, row);
            return tb;
        }
        public static RadioButton CreateRadioBox(int row, int column)
        {
            RadioButton tb = new RadioButton();
            tb.Margin = new Thickness(5);
            tb.Height = 22;
            tb.Width = 150;
            Grid.SetColumn(tb, column);
            Grid.SetRow(tb, row);
            return tb;
        }
        public static TextBox CreateTextBox(int row, int column)
        {
            TextBox tb = new TextBox();
            tb.Margin = new Thickness(5);
            tb.Height = 22;
            tb.Width = 150;
            Grid.SetColumn(tb, column);
            Grid.SetRow(tb, row);
            return tb;
        }
        public static Label CreateLabel(int row, int column, string label)
        {
            Label tb = new Label();
            tb.Margin = new Thickness(5);
            tb.Height = 22;
            tb.Width = 150;
            Grid.SetColumn(tb, column);
            Grid.SetRow(tb, row);
            tb.Content = label;
            return tb;
        }

        public static RowDefinition CreateRowDefinition()
        {
            var rowDefinition = new RowDefinition();
            rowDefinition.Height = GridLength.Auto;
            // grid.RowDefinitions.Add(rowDefinition);
            return rowDefinition;
        }


        public static ComboBox CreateComboBox(int row, int column)
        {
            ComboBox tb = new ComboBox();
            tb.Margin = new Thickness(5);
            tb.Height = 22;
            tb.Width = 150;
            Grid.SetColumn(tb, column);
            Grid.SetRow(tb, row);
            return tb;
        }

        public static List<TextBox> CreateTextBoxMatrix(Grid rootGrid, List<string> rowLables, List<string> colLables)
        {
            int row = rowLables.Count;
            int column = colLables.Count;
            List<TextBox> tbs = new List<TextBox>();

            for (int i = 0; i <= row; i++)
            {
                rootGrid.ColumnDefinitions.Add(ControlsFactory.CreateColumnDefinition());
            }
            for (int j = 0; j <= column; j++)
            {
                rootGrid.RowDefinitions.Add(ControlsFactory.CreateRowDefinition());
            }
            int temp = 0;
           
            for (int i = 1; i <= row; i++)
            {
                for (int j = 1; j <= column; j++)
                {
                    TextBox tb = CreateTextBox(i, j);
                    tbs.Add(tb);
                    rootGrid.Children.Add(tb);
                }
            }
            foreach (var item in rowLables)
            {
                temp++;
                var l = CreateLabel(temp, 0, item);
                rootGrid.Children.Add(l);
            }
            temp = 0;
            foreach (var item in colLables)
            {
                temp++;
                var l = CreateLabel(0, temp, item);
                rootGrid.Children.Add(l);
            }
            return tbs;
        }

        public static ColumnDefinition CreateColumnDefinition()
        {
            var colDefinition = new ColumnDefinition();
            colDefinition.Width = GridLength.Auto;
            return colDefinition;
        }



        #endregion
    }
}
