using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_Questionnaires.Models
{
    public class QuestionAnswer
    {
        public int Id { get; set; }
        public int AssociatedQuestion { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
    }
}
