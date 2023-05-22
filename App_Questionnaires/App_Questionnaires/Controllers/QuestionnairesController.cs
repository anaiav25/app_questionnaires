using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App_Questionnaires.Data;
using App_Questionnaires.Models;

namespace App_Questionnaires.Controllers
{
    public class QuestionnairesController : Controller
    {
        private readonly App_QuestionnairesContext _context;

        public QuestionnairesController(App_QuestionnairesContext context)
        {
            _context = context;
        }

        // GET: Questionnaires
        public async Task<IActionResult> Index()
        {
            QuestionNode n = new QuestionNode("What is the best club?");

            QuestionNode n1 = new QuestionNode("Europe");
            QuestionNode n2 = new QuestionNode("South America");
            QuestionNode n3 = new QuestionNode("Rest");

            QuestionNode n11 = new QuestionNode("Which league?");
            QuestionNode n12 = new QuestionNode("Which league?");
            QuestionNode n13 = new QuestionNode("Which league?");

            n1.Add(n11);
            n2.Add(n12);
            n3.Add(n13);

            n.Add(n1);
            n.Add(n2);
            n.Add(n3);

            QuestionNode n111 = new QuestionNode("Premier league");
            QuestionNode n112 = new QuestionNode("La liga");
            QuestionNode n113 = new QuestionNode("Primeira liga");

            n11.Add(n111);
            n11.Add(n112);
            n11.Add(n113);

            QuestionNode n1111 = new QuestionNode("Which club?");
            QuestionNode n1112 = new QuestionNode("Which club?");
            QuestionNode n1113 = new QuestionNode("Which club?");

            n111.Add(n1111);
            n112.Add(n1112);
            n113.Add(n1113);

            QuestionNode n11111 = new QuestionNode("Liverpool");
            QuestionNode n11112 = new QuestionNode("Manchester City");

            QuestionNode n11121 = new QuestionNode("Real Madrid");
            QuestionNode n11122 = new QuestionNode("Barcelona");

            QuestionNode n11131 = new QuestionNode("Porto");
            QuestionNode n11132 = new QuestionNode("Benfica");

            n1111.Add(n11111);
            n1111.Add(n11112);

            n1112.Add(n11122);
            n1112.Add(n11121);

            n1113.Add(n11131);
            n1113.Add(n11132);

            QuestionNode n121 = new QuestionNode("Brasileirão");
            QuestionNode n122 = new QuestionNode("Argentina");
            QuestionNode n123 = new QuestionNode("Uruguay");

            n12.Add(n121);
            n12.Add(n122);
            n12.Add(n123);

            QuestionNode n1211 = new QuestionNode("Which club?");
            QuestionNode n1212 = new QuestionNode("Which club?");
            QuestionNode n1213 = new QuestionNode("Which club?");

            n121.Add(n1211);
            n122.Add(n1212);
            n123.Add(n1213);

            QuestionNode n12111 = new QuestionNode("Flamengo");
            QuestionNode n12112 = new QuestionNode("Santos");

            QuestionNode n12121 = new QuestionNode("X");
            QuestionNode n12122 = new QuestionNode("Y");

            QuestionNode n12131 = new QuestionNode("Z");
            QuestionNode n12132 = new QuestionNode("W");

            n1211.Add(n12111);
            n1211.Add(n12112);

            n1212.Add(n12122);
            n1212.Add(n12121);

            n1213.Add(n12131);
            n1213.Add(n12132);

            List<string> str = new List<string>();
            DrawTree(n, 1, str);

            QuestionnaireViewModel vM = new QuestionnaireViewModel(new Questionnaire(), str);

            return View(vM);
        }

        // GET: Questionnaires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionnaire = await _context.Questionnaire
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionnaire == null)
            {
                return NotFound();
            }

            return View(questionnaire);
        }

        // GET: Questionnaires/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Questionnaires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Questionnaire questionnaire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questionnaire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(questionnaire);
        }

        // GET: Questionnaires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionnaire = await _context.Questionnaire.FindAsync(id);
            if (questionnaire == null)
            {
                return NotFound();
            }
            return View(questionnaire);
        }

        // POST: Questionnaires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Questionnaire questionnaire)
        {
            if (id != questionnaire.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            /*{
                try
                {
                    _context.Update(questionnaire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionnaireExists(questionnaire.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }*/
            return View(questionnaire);
        }

        // GET: Questionnaires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionnaire = await _context.Questionnaire
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionnaire == null)
            {
                return NotFound();
            }

            return View(questionnaire);
        }

        // POST: Questionnaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questionnaire = await _context.Questionnaire.FindAsync(id);
            _context.Questionnaire.Remove(questionnaire);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private List<string> DrawTree(QuestionNode root, int levl, List<string> str)
        {
            if(root.Descendants.Count == 0)
            {
                return str;
            }

            
            foreach(QuestionNode n in root.Descendants.Values)
            {
                string x = "";

                for (int i = 0; i < levl; i++)
                {
                    x += "_";
                }
                
                str.Add(x + " " + n.Text);

                levl++;

                DrawTree(n, levl, str);

                levl--;
            }

            return str;
        }

    }
}
