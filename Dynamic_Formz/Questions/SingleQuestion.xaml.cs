using System.Windows.Controls;

namespace Survey.Questions
{
    /// <summary>
    /// Interaction logic for SingleTextBoxQuestionType.xaml
    /// </summary>
    public partial class SingleQuestion : Page
    {
        public SingleQuestion()
        {
            InitializeComponent();
        }
        private DynamicQuestions _dq;
        public DynamicQuestions DynamicQuestions
        {
            get
            { return _dq; }
            set
            {
                _dq = value;
                QuestionOptions.Content = _dq;
            }
        }
    }
}
