using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;

namespace WpfPractice.Grids
{
    public class ColumnsFactory
    {
        public static DataGridTextColumn GetTextColumn(string HeaderText, string Binding)
        {
            DataGridTextColumn column = new DataGridTextColumn();
            column.Header = HeaderText;
            column.Binding = new Binding(Binding);
            column.IsReadOnly = true;
            return column;
        }

        public static DataGridComboBoxColumn GetComboBoxColumn(string HeaderText, string Binding)
        {
            DataGridComboBoxColumn column = new DataGridComboBoxColumn();
            column.Header = HeaderText;

            column.IsReadOnly = true;
            return column;
        }

        public static DataGridCheckBoxColumn GetDataGridCheckBoxColumn(string HeaderText, string Binding)
        {
            DataGridCheckBoxColumn column = new DataGridCheckBoxColumn();
            column.Header = HeaderText;
            column.Binding = new Binding(Binding);
            column.IsReadOnly = true;
            return column;
        }

        public static DataGridTemplateColumn GetDataImageColumn(ExtendedGridControl grid, string HeaderText, string Binding)
        {
            DataGridTemplateColumn column = (DataGridTemplateColumn)grid.FindResource("dgt");
            column.Header = HeaderText;
            column.IsReadOnly = true;
            return column;
        }
    }
}
