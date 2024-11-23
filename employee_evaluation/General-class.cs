using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
                Employee personInfo = new Employee(items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7], items[8]);

                // addes the persons into a new list
                contents.Add(personInfo.ToString());
            }            
            // return the list content array
            return contents;
        }

        public string skillsGrade(List<string> employeeContent)
        {
            string gradeContents = "";

            foreach (string employeeSkill in employeeContent)
            {
                string[] seperateGrades = employeeSkill.Split(',');
                //string[] getGradeSkills = { seperateGrades[2], seperateGrades[3] };
                
                string[,] getGradeSkills = new string[,]{ {seperateGrades[3] }, {seperateGrades[4] }, {seperateGrades[5] }, {seperateGrades[6] }, {seperateGrades[7] }, { seperateGrades[8] } };                              
                //GET COL ARRAY VALUE 
                int colLength = getGradeSkills.GetLength(0);                
                int[] colArray = new int[colLength];
                
                for(int loopThruArray = 0; loopThruArray < colLength; loopThruArray++)
                {
                    colArray[loopThruArray] = Convert.ToInt32(getGradeSkills[loopThruArray,0].ToString());                    
                }

                /*
                int rowLength = getGradeSkills.GetLength(1);
                int[] rowArray = new int[rowLength];
                for (int loopThruArray = 0; loopThruArray < rowLength; loopThruArray++)
                {
                    rowArray[loopThruArray] = Convert.ToInt32(getGradeSkills[0,loopThruArray].ToString());
                }
                */
                gradeContents += string.Join(",", colArray) + ",";                
                
                //gradeContents += string.Join(",", getGradeSkills) + ",";
            }
            return gradeContents;
        }                
        
        public string personInfo(List<string> employeeContent)
        {
            string personInfo = "";         
            foreach(string employeeName in employeeContent)
            {
                string[] seperateName = employeeName.Split(',');
                string[] getName = { string.Concat(seperateName[0], seperateName[2]) + "," };
                personInfo += string.Concat(getName);
                //MessageBox.Show(string.Join(",", personInfo));
            }            
            return personInfo;
        }
        public string getSkillOne(List<string> employeeContent)
        {
            string skillOne = "";
            int length = 0;
            foreach(string skillOneContent in employeeContent)
            {
                string[] seperateSkillOne = skillOneContent.Split(',');
                string[] getSkillOne = { seperateSkillOne[3] };
                length = getSkillOne.Length;
                skillOne += string.Concat(getSkillOne) + ",";
            }
            //MessageBox.Show(skillOne);
            return skillOne;
        }

        public string getSkillTwo(List<string> employeeContent)
        {
            string skills = "";
            int length = 0;
            foreach (string skillsContent in employeeContent)
            {
                string[] seperateSkillOne = skillsContent.Split(',');
                string[] getSkillOne = { seperateSkillOne[4] };
                length = getSkillOne.Length;
                skills += string.Concat(getSkillOne) + ",";
            }
            //MessageBox.Show(skills);
            return skills;
        }

        public string getSkillThree(List<string> employeeContent)
        {
            string skills = "";
            int length = 0;
            foreach (string skillsContent in employeeContent)
            {
                string[] seperateSkillOne = skillsContent.Split(',');
                string[] getSkillOne = { seperateSkillOne[5] };
                length = getSkillOne.Length;
                skills += string.Concat(getSkillOne) + ",";
            }
            //MessageBox.Show(skills);
            return skills;
        }

        public string getSkillFour(List<string> employeeContent)
        {
            string skills = "";
            int length = 0;
            foreach (string skillsContent in employeeContent)
            {
                string[] seperateSkillOne = skillsContent.Split(',');
                string[] getSkillOne = { seperateSkillOne[6] };
                length = getSkillOne.Length;
                skills += string.Concat(getSkillOne) + ",";
            }
            //MessageBox.Show(skills);
            return skills;
        }

        public string getSkillFive(List<string> employeeContent)
        {
            string skills = "";
            int length = 0;
            foreach (string skillsContent in employeeContent)
            {
                string[] seperateSkill = skillsContent.Split(',');
                string[] getSkillGrade = { seperateSkill[7] };
                length = getSkillGrade.Length;
                skills += string.Concat(getSkillGrade) + ",";
            }
            //MessageBox.Show(skills);
            return skills;
        }

        public void createFile(string Path, List<string> contents)
        {           
           File.WriteAllLines(Path+"\\Evaluation.txt", contents);            
           MessageBox.Show("File has been created. File can be viewed @ \n" + Path);
        }
    }
}
