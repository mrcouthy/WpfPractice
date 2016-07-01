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
        public QuestionOption QuestionOption { get; set; }
        public Question Question { get; set; }
        public Control AnswerControl { get; set; }
    }


}
