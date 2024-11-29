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

        public Employee(List<string> headerLabel, List<string> personLabel)
        {
            headerContent = headerLabel.ToList();
            personContent = personLabel.ToList();                       
        }


        // automatic property
        // similar to private string Firstname;
        public List<string> headerLabel { get; set; }
        public List<string> personLabel { get; set; }        

        public override string ToString()
        {
            string header = "", personInfo = "", gradingInfo = "";
            string output = "";
            int lengthOfItem = 0;            
            int lengthOfSkillsHeader = 0;
            
            foreach (string HEADER in headerContent)
            {
                string[] HEADERITEM = HEADER.Split(',');                                               
                lengthOfItem = HEADERITEM.Length;
                lengthOfSkillsHeader = HEADERITEM.Length;                
                for (int i = 0; i < lengthOfItem; i++)
                {
                    // adds \t tabspace to names label
                    if(i <= 2)
                    {
                        header += HEADERITEM[i] + ",\t";
                    }
                    else
                    {
                        header += HEADERITEM[i] + ",\t";
                    }                        
                }
                lengthOfItem = 0;
            }

            foreach (string PERSONNAME in personContent)
            {                
                string[] PERSONITEM = PERSONNAME.Split(',');               
                lengthOfItem = PERSONITEM.Length;             
                for (int i = 0; i < lengthOfItem; i++)
                {
                    //personInfo += "\n" + PERSONITEM[i] + ",\t\t\t\t";                                       
                    if(i % lengthOfSkillsHeader == 0)
                    {
                        personInfo += "\n" + PERSONITEM[i] + ",\t";
                    }
                    else
                    {
                        personInfo += "\t" + PERSONITEM[i] + ",\t";
                    }
                }
                lengthOfItem = 0;
            }            
            output = header + personInfo;
            return output;
        }        
    }
}
