
using Dynamic_Formz.Answers;
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
        public NavigationList<SingleQuestion> QuestionPages { get; set; }
        
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

            QuestionPages  = GetQuestionsPages(surveySections);

            questionArea.Content = QuestionPages.Current;
        }

        public NavigationList<SingleQuestion> GetQuestionsPages(ICollection<SurveySection> SurveySections)
        {
            NavigationList<SingleQuestion> singleQuestions = new NavigationList<SingleQuestion>();
            foreach (var section in SurveySections)
            {
                foreach (var question in section.Questions)
                {
                    var page = GetAQuestionPage(question);
                    singleQuestions.Add(page);
                }
            }
            return singleQuestions;
        }

        public SingleQuestion GetAQuestionPage(Question question)
        {
            var singleQuestionPage = new SingleQuestion();
            singleQuestionPage.SectionTitle.Header = question.SurveySection.Title;
            singleQuestionPage.Code.Text = question.Code;
            singleQuestionPage.Question.Text = question.QuestionText;
            singleQuestionPage.CommentLabel.Visibility = singleQuestionPage.Comment.Visibility = question.IncludeComment ? Visibility.Visible : Visibility.Hidden;
            var dq = new DynamicQuestions();
            dq.Load(question);
            singleQuestionPage.DynamicQuestions = dq;
            return singleQuestionPage;
        }

        private void Button_Click_Previous(object sender, RoutedEventArgs e)
        {
            if (QuestionPages.Count > 0)
                questionArea.Content = QuestionPages.MovePrevious;
        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            if (QuestionPages.Count > 0)
                questionArea.Content = QuestionPages.MoveNext;
        }



        private void Button_Click_Home(object sender, RoutedEventArgs e)
        {
            var ans = new LoadAnswers();
            IList<string> a = ans.ReadAnswers(QuestionPages);
            var v = QuestionPages;
        }
    }

  
}
