using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace employee_evaluation
{
    internal class Employee
    {
        List<string> headerContent = new List<string>();
        List<string> personContent = new List<string>();
        List<string> gradingContent = new List<string>();

        public Employee(List<string> headerLabel, List<string> personLabel, List<string> gradingscontent)
        {
            headerContent = headerLabel.ToList();
            personContent = personLabel.ToList();
            gradingContent = gradingscontent.ToList();            
        }


        // automatic property
        // similar to private string Firstname;
        public List<string> headerLabel { get; set; }
        public List<string> personLabel { get; set; }
        public List<string> gradingscontent { get; set; }

        public override string ToString()
        {
            string header = "", personInfo = "", gradingInfo = "";
            string output = "";
            int lengthOfItem = 0 ;            
            foreach(string HEADER in headerContent)
            {
                string[] HEADERITEM = HEADER.Split(',');
                lengthOfItem = HEADERITEM.Length;
                for (int i = 0; i < lengthOfItem; i++)
                {
                    header += HEADERITEM[i] + ",\t";
                }
            }

            foreach (string PERSONNAME in personContent)
            {
                MessageBox.Show(string.Concat(personContent));
                string[] PERSONITEM = PERSONNAME.Split(',');
                lengthOfItem = PERSONITEM.Length;
                for (int i = 0; i < lengthOfItem; i++)
                {                    
                    // every count of 3 index, personInfo string adds newLine
                    if(i % 4 == 0)
                    {
                        personInfo += "\n";
                    }
                    else
                    {
                        personInfo += PERSONITEM[i] + ",\t";
                    }
                }
            }
            foreach (string GRADING in gradingContent)
            {
                string[] GRADINGITEM = GRADING.Split(',');

            }            
            output = header + personInfo + gradingInfo;
            return output;
        }        
    }
}
