using Survey.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Utilities;

namespace Dynamic_Formz.Answers
{
    public class LoadAnswers
    {
        internal IList<string> ReadAnswers(NavigationList<SingleQuestion> questionPages)
        {
            foreach (var item in questionPages)
            {
                //item.
            }
            return new List<string>();
        }
    }
}
