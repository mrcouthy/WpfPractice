using SurveyCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Dynamic_Formz.OtherModels
{
    public partial class AnswerOption
    {
        public int? QuestionOptionId { get; set; }
        public int QuestionId { get; set; }
        public Control AnswerControl { get; set; }
    }

    public class AnswerControls
    {
        public AnswerControls()
        {
            AnswerOptions = new List<AnswerOption>();
        }
        public int QuestionId { get; set; }
        public ICollection<AnswerOption> AnswerOptions { get; set; }

        public virtual Question Question { get; set; }
    }

}
