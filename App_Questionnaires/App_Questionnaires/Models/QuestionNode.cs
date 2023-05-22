using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_Questionnaires.Models
{
    public class QuestionNode
    {
        public int Id { get; set; }
        public QuestionNode Parent { get; set; }
        public int? ParentId { get; set; } //null if root
        public string Text { get; set; }

        public Dictionary<string, QuestionNode> Descendants = new Dictionary<string, QuestionNode>();

        public QuestionNode() { }
        public QuestionNode(string text)
        {
            this.Text = text;
        }

        public QuestionNode GetChild(string text)
        {
            return this.Descendants[text];
        }

        public void Add(QuestionNode n)
        {
            if(n.ParentId != null)
            {
                n.Parent.Descendants.Remove(n.Text);
            }

            n.Parent = this;
            n.ParentId = this.Id;
            this.Descendants.Add(n.Text, n);
        } 
    }
}
