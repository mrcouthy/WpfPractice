using SurveyCore;
using SurveyCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Utilities;

namespace Survey.Questions
{
    public class LoadQuestions
    {
        public NavigationList<Page> GetQuestionsPages(ICollection<SurveySection> SurveySections)
        {
            NavigationList<Page> pages = new NavigationList<Page>();
            foreach (var section in SurveySections)
            {
                foreach (var question in section.Questions)
                {
                    var page = GetAQuestionPage(question);
                    pages.Add(page);
                }
            }
            return pages;
        }

        public Page GetAQuestionPage(Question question)
        {
            var page = new SingleTextBoxQuestionType();
            page.SectionTitle.Header = question.SurveySection.Title;
            page.Code.Text = question.Code;
            page.Question.Text = question.QuestionText;
            page.CommentLabel.Visibility = page.Comment.Visibility = question.IncludeComment ? Visibility.Visible : Visibility.Hidden;
            var questionOptions = GetAdditionalOptions(question);
            page.QuestionOptions.Content = questionOptions;


            return page;
        }

        public Page GetAdditionalOptions(Question question)
        {

            var dq = new DynamicQuestions();
            dq.Load(question);
            return dq;
        }
    }
}
