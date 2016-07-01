
using SurveyCore.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Utilities;

namespace Survey.Questions
{
    /// <summary>
    /// Interaction logic for QuestionsContainer.xaml
    /// </summary>
    public partial class QuestionsContainer : Page
    {
        NavigationList<Page> questionPages = new NavigationList<Page>();
        public QuestionsContainer()
        {
            InitializeComponent();
        }

        private void grid_Loaded(object sender, RoutedEventArgs e)
        {
            LoadQuestions();
        }

        public void LoadQuestions()
        {
            var q = new List<Question>();

            var ssections = new SurveySection()
            {
                Code = "a",
                Title = "Section one",
                Questions = q
            };

            q.Add(
                new Question()
                {
                    QuestionId = 1,
                    Code = "Q01",
                    QuestionTypeId = 1,
                    QuestionText = "What is your name",
                    SurveySection = ssections,
                    IncludeComment = true
                }
                );
            q.Add(
                new Question()
                {
                    QuestionId = 1,
                    Code = "Q02",
                    QuestionTypeId = 1,
                    QuestionText = "What is your age",
                    SurveySection = ssections
                }
                );
            List<SurveySection> surveySections = new List<SurveySection>();
            surveySections.Add(ssections);

            questionPages = new LoadQuestions().GetQuestionsPages(surveySections);

            questionArea.Content = questionPages.Current;
        }

        private void Button_Click_Previous(object sender, RoutedEventArgs e)
        {
            if (questionPages.Count > 0)
                questionArea.Content = questionPages.MovePrevious;
        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            if (questionPages.Count > 0)
                questionArea.Content = questionPages.MoveNext;
        }



        private void Button_Click_Home(object sender, RoutedEventArgs e)
        {
            var v = questionPages;
        }
    }
}
