using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_Questionnaires.Models
{
    public class QuestionnaireViewModel
    {
        public Questionnaire Questionnaire { get; set; }
        public List<string> DrawQuestionnaire { get; set; }

        public QuestionnaireViewModel() { }

        public QuestionnaireViewModel(Questionnaire q, List<String> d)
        {
            this.Questionnaire = q;
            this.DrawQuestionnaire = d;
        }
    }
}
