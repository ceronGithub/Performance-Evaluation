using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace employee_evaluation
{
    internal class General_class
    {
        Path_class pathFolder = new Path_class();
        Create_Folder subFolderCreation = new Create_Folder();

        public static string textReadLines(List<string> values)
        {
            List<string> output = new List<string>();
            foreach (string readLine in values)
            {
                output.Add(String.Join("\n", values));
            }
            return String.Join("", output);
        }
        
        public List<string> makeEmployeeAsObject(List<string> value)
        {
            // this calls the Employee class
            List<Employee> listOfEmployee = new List<Employee>();

            // create a new list
            List<string> contents = new List<string>();

            // read each value that has been passed
            foreach(string person in value)
            {
                // this removes the comma to the text file
                string[] items = person.Split(',');

                // employee is a constructor
                Employee personInfo = new Employee(items[0], items[1], items[2]);

                // addes the persons into a new list
                contents.Add(personInfo.ToString());
            }            
            // return the list content array
            return contents;
        }
       
        public void createFile(string Path, List<string> contents)
        {           
           File.WriteAllLines(Path+"\\Evaluation.txt", contents);            
           MessageBox.Show("File has been created. File can be viewed @ \n" + Path);
        }
    }
}
