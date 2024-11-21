using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace employee_evaluation
{
    internal class General_class
    {
        public static string textReadLines(List<string> values)
        {
            List<string> output = new List<string>();
            foreach (string readLine in values)
            {
                output.Add(String.Join("\n", values));
            }
            return String.Join("", output);
        }
        
        public static string makeEmployeeAsObject(List<string> people)
        {
            List<Employee> listOfEmployee = new List<Employee>();
            foreach(string person in people)
            {
                string[] items = person.Split(',');
                // employee is a constructor
                Employee personInfo = new Employee(items[0], items[1], items[2]);
                listOfEmployee.Add(personInfo);
            }
            return string.Join("", listOfEmployee);
        }
    }
}
