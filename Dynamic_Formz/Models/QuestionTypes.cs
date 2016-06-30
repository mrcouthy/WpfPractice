using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyCore
{
    public enum QuestionTypes
    {
        SingleTextbox,
        MultipleTextbox,
        Text,
        MultipleChoice,
        Dropdown,
        MatrixofInput,
        MatrixofOption
    }

    public static class QuestionTypeHelper
    {
        public static QuestionTypes GetQuestionType(string Type)
        {
            switch (Type)
            {
                case "Single Textbox":
                    return QuestionTypes.SingleTextbox;
                case "Multiple Textbox":
                    return QuestionTypes.MultipleTextbox;
                case "Text":
                    return QuestionTypes.Text;
                case "Multiple Choice":
                    return QuestionTypes.MultipleChoice;
                case "Dropdown":
                    return QuestionTypes.Dropdown;
                case "Matrix of Input":
                    return QuestionTypes.MatrixofInput;
                case "Matrix of Option":
                    return QuestionTypes.MatrixofOption;
                default:
                    return QuestionTypes.Text;
            }
        }

        public static QuestionTypes GetQuestionType(int Type)
        {
            switch (Type)
            {
                case 1:
                    return QuestionTypes.SingleTextbox;
                case 2:
                    return QuestionTypes.MultipleTextbox;
                case 3:
                    return QuestionTypes.Text;
                case 4:
                    return QuestionTypes.MultipleChoice;
                case 5:
                    return QuestionTypes.Dropdown;
                case 6:
                    return QuestionTypes.MatrixofInput;
                case 7:
                    return QuestionTypes.MatrixofOption;
                default:
                    return QuestionTypes.Text;
            }
        }

    }

}
