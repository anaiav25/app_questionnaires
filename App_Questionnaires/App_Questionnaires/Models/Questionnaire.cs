using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_Questionnaires.Models
{
    public class Questionnaire
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public QuestionNode AssociatedQuestions { get; set; }
    }
}
