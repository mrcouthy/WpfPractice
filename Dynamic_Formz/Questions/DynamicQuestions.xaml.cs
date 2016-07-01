
using Dynamic_Formz.OtherModels;
using SurveyCore;
using SurveyCore.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Survey.Questions
{
    /// <summary>
    /// Interaction logic for DynamicQuestions.xaml
    /// </summary>
    public partial class DynamicQuestions : Page
    {
        public DynamicQuestions()
        {
            InitializeComponent();
        }


        public ICollection<AnswerOption> AnswerOptions { get; set; } = new List<AnswerOption>();

        private int rowCount = 0;

        public void Load(Question question)
        {

            var questionType = QuestionTypeHelper.GetQuestionType(question.QuestionTypeId);
            var grid = GetGrid();

            switch (questionType)
            {
                case QuestionTypes.SingleTextbox:

                    AddSingleTextbox(grid, question);
                    break;
                case QuestionTypes.MultipleTextbox:
                    AddMultipleTextbox(grid, question);
                    break;
                case QuestionTypes.Text:
                    AddText(grid, question);
                    break;
                case QuestionTypes.MultipleChoice:
                    AddMultipleChoice(grid, question);
                    break;
                case QuestionTypes.Dropdown:
                    AddDropdown(grid, question);
                    break;
                case QuestionTypes.MatrixofInput:
                    AddMatrixofInput(grid, question);
                    break;
                case QuestionTypes.MatrixofOption:
                    AddMatrixofOption(grid, question);
                    break;
                default:
                    break;
            }
            LayoutIt.Children.Add(grid);
        }

        #region Privates
        private Grid GetGrid()
        {
            Grid rootGrid = new Grid();
            rootGrid.Margin = new Thickness(10.0);
            rootGrid.ColumnDefinitions.Add(
               new ColumnDefinition() { Width = new GridLength(100.0) });
            rootGrid.ColumnDefinitions.Add(
                 new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            rootGrid.RowDefinitions.Add(CreateRowDefinition());

            return rootGrid;

        }

        private RowDefinition CreateRowDefinition()
        {
            var rowDefinition = new RowDefinition();
            rowDefinition.Height = GridLength.Auto;
            // grid.RowDefinitions.Add(rowDefinition);
            return rowDefinition;
        }

        private TextBlock CreateTextBlock(string text, int row, int column)
        {
            TextBlock tb = new TextBlock() { Text = text, Margin = new Thickness(5, 8, 0, 5) };
            tb.MinWidth = 90;
            tb.FontWeight = FontWeights.Bold;
            tb.Margin = new Thickness(5);
            var bc = new BrushConverter();
            tb.Foreground = (Brush)bc.ConvertFrom("#FF2D72BC");
            Grid.SetColumn(tb, column);
            Grid.SetRow(tb, row);
            return tb;
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

        private RadioButton CreateRadioBox(int row, int column)
        {
            var tb = new RadioButton();
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
            tb.Height = 30;
            tb.Width = 150;

            tb.BorderBrush = Brushes.Green;
            tb.BorderThickness = new Thickness(1, 1, 1, 3);

            Grid.SetColumn(tb, column);
            Grid.SetRow(tb, row);

            return tb;
        }

        private ComboBox CreateComboBox(List<string> texts, int row, int column)
        {
            var tb = new ComboBox();
            foreach (var item in texts)
            {
                tb.Items.Add(item);
            }

            tb.Margin = new Thickness(5);
            tb.Height = 22;
            tb.Width = 150;
            Grid.SetColumn(tb, column);
            Grid.SetRow(tb, row);
            return tb;
        }
        #endregion


        public void AddSingleTextbox(Grid Grid, Question question)
        {
            Grid.RowDefinitions.Add(CreateRowDefinition());
            var textbox = CreateTextBox(rowCount, 0);

            Grid.SetColumnSpan(textbox, 2);
            Grid.Children.Add(textbox);
            rowCount++;

            AnswerOption ao = new AnswerOption();
            ao.AnswerControl = textbox;
            ao.QuestionOption = null;
            ao.Question = question;

            AnswerOptions.Add(ao);
        }

        public void AddMultipleTextbox(Grid Grid, Question question)
        {
            foreach (var item in question.QuestionOptions)
            {
                Grid.RowDefinitions.Add(CreateRowDefinition());
                var Label = CreateTextBlock(item.OptionChoiceLabel, rowCount, 0);
                Grid.Children.Add(Label);
                var textbox = CreateTextBox(rowCount, 1);
                Grid.Children.Add(textbox);
                rowCount++;

                AnswerOption ao = new AnswerOption();
                ao.AnswerControl = textbox;
                ao.QuestionOption  = item;
                ao.Question = question;

                AnswerOptions.Add(ao);
            }
        }

        public void AddText(Grid Grid, Question question)
        {
            //No need to do any thing as its already taken care
            //Grid.RowDefinitions.Add(CreateRowDefinition());
            //var Textbox = CreateTextBlock(question. ,rowCount, 1);
            //Grid.Children.Add(Textbox);
            //rowCount++;
        }
        public void AddMultipleChoice(Grid Grid, Question question)
        {

            foreach (var item in question.QuestionOptions)
            {
                Grid.RowDefinitions.Add(CreateRowDefinition());
                var Label = CreateTextBlock(item.OptionChoiceLabel, rowCount, 0);
                Grid.Children.Add(Label);
                Control ctrl;
                if (question.AllowMultipleChoice)
                {
                    ctrl = CreateCheckBox(rowCount, 1);
                    Grid.Children.Add(ctrl);
                }
                else
                {
                    ctrl = CreateRadioBox(rowCount, 1);
                    Grid.Children.Add(ctrl);
                }
                rowCount++;

                AnswerOption ao = new AnswerOption();
                ao.AnswerControl = ctrl;
                ao.QuestionOption = item;
                ao.Question = question;

                AnswerOptions.Add(ao);
            }
        }

        //todo
        public void AddDropdown(Grid Grid, Question question)
        {
            Grid.RowDefinitions.Add(CreateRowDefinition());

            var texts = (from QuestionOption s in question.QuestionOptions
                         select s.OptionChoiceLabel).ToList();

            var cmb = CreateComboBox(texts, rowCount, 1);
            Grid.Children.Add(cmb);
            rowCount++;

            AnswerOption ao = new AnswerOption();
            ao.AnswerControl = cmb;
            ao.QuestionOption = null;
            ao.Question = question;
            AnswerOptions.Add(ao);
        }

        //todo
        public void AddMatrixofInput(Grid Grid, Question question)
        {
            Grid.RowDefinitions.Add(CreateRowDefinition());
            var Label = CreateTextBlock("mat", rowCount, 0);
            Grid.Children.Add(Label);
            var Textbox = CreateTextBox(rowCount, 1);
            Grid.Children.Add(Textbox);
            rowCount++;

        }
        //todo
        public void AddMatrixofOption(Grid Grid, Question question)
        {
            Grid.RowDefinitions.Add(CreateRowDefinition());
            var Label = CreateTextBlock("mat o", rowCount, 0);
            Grid.Children.Add(Label);
            var Textbox = CreateTextBox(rowCount, 1);
            Grid.Children.Add(Textbox);
            rowCount++;
        }
    }
}
