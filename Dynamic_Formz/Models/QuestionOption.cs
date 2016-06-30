using System;
using System.Collections.Generic;

namespace SurveyCore.Models
{
    public partial class QuestionOption
    {
        public int QuestionOptionId { get; set; }
        public string OptionChoiceLabel { get; set; }
        public bool IsDropdown { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
