using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using App_Questionnaires.Models;

namespace App_Questionnaires.Data
{
    public class App_QuestionnairesContext : DbContext
    {
        public App_QuestionnairesContext (DbContextOptions<App_QuestionnairesContext> options)
            : base(options)
        {
        }

        public DbSet<App_Questionnaires.Models.QuestionNode> Question { get; set; }

        public DbSet<App_Questionnaires.Models.Questionnaire> Questionnaire { get; set; }
    }
}
