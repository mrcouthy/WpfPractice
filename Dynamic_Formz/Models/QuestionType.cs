using System;
using System.Collections.Generic;

namespace SurveyCore.Models
{
    public partial class QuestionType
    {
        public QuestionType()
        {
            this.Questions = new List<Question>();
        }

        public int QuestionTypeId { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
