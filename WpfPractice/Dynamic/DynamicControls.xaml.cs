using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for DynamicControls.xaml
    /// </summary>
    public partial class DynamicControls : Window
    {
        public DynamicControls()
        {
            InitializeComponent();
        }

       private TextBlock CreateTextBlock(string text, int row, int column)
        {
            string[] aa = BreakUpperCB(text);
            string prop = "";
            for (int i = 0; i < aa.Length; i++)
            {
                prop = prop + " " + aa[i];
            }
            TextBlock tb = new TextBlock() { Text = prop, Margin = new Thickness(5, 8, 0, 5) };
            tb.MinWidth = 90;
            tb.FontWeight = FontWeights.Bold;
            tb.Margin = new Thickness(5);
            var bc = new BrushConverter();
            tb.Foreground = (Brush)bc.ConvertFrom("#FF2D72BC");
            Grid.SetColumn(tb, column);
            Grid.SetRow(tb, row);
            return tb;
        }

        void button_Click(object sender, RoutedEventArgs e)
        {//Check values
            foreach (var item in LayoutIt.Children)
            {
                var x = item;
            }
            MessageBox.Show("Saved Successfully");
        }
        private Button CreateButton(string text, int row, int column)
        {
            Button tb = new Button()
            {
                Content = text,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(5, 8, 0, 5)
            };
            tb.Width = 90;
            tb.Height = 25;
            tb.Margin = new Thickness(5);
            Grid.SetColumn(tb, column);
            Grid.SetRow(tb, row);
            return tb;
        }
        private CheckBox CreateCheckBox(int row, int column)
        {
            CheckBox tb = new CheckBox();
            tb.Margin = new Thickness(5);
            tb.Height = 22;
            tb.Width = 150;
            Grid.SetColumn(tb, column);
            Grid.SetRow(tb, row);
            return tb;
        }
        private TextBox CreateTextBox(int row, int column)
        {
            TextBox tb = new TextBox();
            tb.Margin = new Thickness(5);
            tb.Height = 22;
            tb.Width = 150;
            Grid.SetColumn(tb, column);
            Grid.SetRow(tb, row);
            return tb;
        }



        // this will break the property text by upper
        public string[] BreakUpperCB(string sInput)
        {
            StringBuilder[] sReturn = new StringBuilder[1];
            sReturn[0] = new StringBuilder(sInput.Length);
            const string CUPPER = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int iArrayCount = 0;
            for (int iIndex = 0; iIndex < sInput.Length; iIndex++)
            {
                string sChar = sInput.Substring(iIndex, 1); // get a char
                if ((CUPPER.Contains(sChar)) && (iIndex > 0))
                {
                    iArrayCount++;
                    System.Text.StringBuilder[] sTemp = new System.Text.StringBuilder[iArrayCount + 1];
                    Array.Copy(sReturn, 0, sTemp, 0, iArrayCount);
                    sTemp[iArrayCount] = new StringBuilder(sInput.Length);
                    sReturn = sTemp;
                }
                sReturn[iArrayCount].Append(sChar);
            }
            string[] sReturnString = new string[iArrayCount + 1];
            for (int iIndex = 0; iIndex < sReturn.Length; iIndex++)
            {
                sReturnString[iIndex] = sReturn[iIndex].ToString();
            }
            return sReturnString;
        }



        private void CreateControls(Person obj)
        {
            List<Person> objList = new List<Person>();
            objList.Add(obj);
            Grid rootGrid = new Grid();
            rootGrid.Margin = new Thickness(10.0);
            rootGrid.ColumnDefinitions.Add(
               new ColumnDefinition() { Width = new GridLength(100.0) });
            rootGrid.ColumnDefinitions.Add(
                 new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
           
            PropertyInfo[] propertyInfos;
            propertyInfos = typeof(Person).GetProperties();
            rootGrid.RowDefinitions.Add(CreateRowDefinition());
            int j = 1;
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (propertyInfo.PropertyType.Name == "String")
                {
                    rootGrid.RowDefinitions.Add(CreateRowDefinition());
                    var Label = CreateTextBlock(propertyInfo.Name, j, 0);
                    rootGrid.Children.Add(Label);
                    var Textbox = CreateTextBox(j, 1);


                    rootGrid.Children.Add(Textbox);
                    j++;
                }
                if (propertyInfo.PropertyType.Name == "Boolean")
                {
                    rootGrid.RowDefinitions.Add(CreateRowDefinition());
                    var Label = CreateTextBlock(propertyInfo.Name, j, 0);
                    rootGrid.Children.Add(Label);
                    var Textbox = CreateCheckBox(j, 1);
                    rootGrid.Children.Add(Textbox);
                    
                    j++;
                }
            }
            rootGrid.RowDefinitions.Add(CreateRowDefinition());
            var Button = CreateButton("Save", j + 1, 1);
            Button.Click += new RoutedEventHandler(button_Click);
            rootGrid.Children.Add(Button);
            LayoutIt.Children.Add(rootGrid);

        }

        private RowDefinition CreateRowDefinition()
        {
           var rowDefinition = new RowDefinition();
            rowDefinition.Height = GridLength.Auto;
           // grid.RowDefinitions.Add(rowDefinition);
            return rowDefinition;
        }

        private void LayoutIt_Loaded(object sender, RoutedEventArgs e)
        {
            Person obj = new Person();
            obj.FirstName = "sujeet";
            CreateControls(obj);
        }
    }
}
