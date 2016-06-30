using System;
using System.Collections.Generic;

namespace SurveyCore.Models
{
    public class SyncableModel
    {
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

    }
    public partial class Question
    {
        public Question()
        {
           
            this.QuestionOptions = new List<QuestionOption>();
        }

        public int QuestionId { get; set; }
        public int PrecedingQuestionId { get; set; }
        public string Code { get; set; }
        public string QuestionText { get; set; }
        public bool Required { get; set; }
        public bool OnlyNumericValue { get; set; }
        public bool IncludeComment { get; set; }
        public string Comment { get; set; }
        public int QuestionOrder { get; set; }
        public int DependentQuestionId { get; set; }
        public int DependentQuestionOptionId { get; set; }
        public bool AllowMultipleChoice { get; set; }
        public int JumpQuestionId { get; set; }
        public int JumpQuestionOptionId { get; set; }
        public bool HasPredefinedDropdown { get; set; }
        public int PredefinedDropdownId { get; set; }
        public int SectionId { get; set; }
        public int QuestionTypeId { get; set; }
        public int RuleId { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        
        public virtual QuestionType QuestionType { get; set; }
        public virtual SurveySection SurveySection { get; set; }
        public virtual ICollection<QuestionOption> QuestionOptions { get; set; }
    }
}
