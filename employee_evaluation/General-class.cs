using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
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
            foreach(string employeeName in employeeContent.Skip(1))
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
            
            // skip = skip some sequence from List<T> collection
            foreach (string skillsContent in employeeContent.Skip(1))
            {
                // split the List<T> collection into many sequence
                // sample : List<T> arrayCollection = firstname, middlename,...
                // take the firstname and equals it into, seperateSkill[0] = firstname
                // seperateSkill = nameoftheArrayVariable, [0] = index
                string[] seperateSkill = skillsContent.Split(',');
                // get the inde
                string[] getSkill = { seperateSkill[3] };                               
                skillOne += string.Concat(getSkill) + ",";
            }
            //MessageBox.Show(string.Concat(employeeContent.Skip(1)));
            return skillOne;
        }

        public string getSkillTwo(List<string> employeeContent)
        {
            string skills = "";            
            foreach (string skillsContent in employeeContent.Skip(1))
            {
                string[] seperateSkillOne = skillsContent.Split(',');
                string[] getSkill = { seperateSkillOne[4] };              
                skills += string.Concat(getSkill) + ",";
            }
            //MessageBox.Show(skills);
            return skills;
        }

        public string getSkillThree(List<string> employeeContent)
        {
            string skills = "";            
            foreach (string skillsContent in employeeContent.Skip(1))
            {
                string[] seperateSkillOne = skillsContent.Split(',');
                string[] getSkill = { seperateSkillOne[5] };                
                skills += string.Concat(getSkill) + ",";
            }
            //MessageBox.Show(skills);
            return skills;
        }

        public string getSkillFour(List<string> employeeContent)
        {
            string skills = "";            
            foreach (string skillsContent in employeeContent.Skip(1))
            {
                string[] seperateSkillOne = skillsContent.Split(',');
                string[] getSkill = { seperateSkillOne[6] };                
                skills += string.Concat(getSkill) + ",";
            }
            //MessageBox.Show(skills);
            return skills;
        }

        public string getSkillFive(List<string> employeeContent)
        {
            string skills = "";            
            foreach (string skillsContent in employeeContent.Skip(1))
            {
                string[] seperateSkill = skillsContent.Split(',');
                string[] getSkill = { seperateSkill[7] };               
                skills += string.Concat(getSkill) + ",";
            }
            //MessageBox.Show(skills);
            return skills;
        }

        public List<string> headerSkillLabel(List<string> headerContent)
        {
            MessageBox.Show(string.Concat(headerContent.Take(1)));
            return headerContent.Take(1).ToList();
        }
        public List<string> autoHeaderSkillLabel(List<string> headerContent)
        {
            List<string> getHeaderLabel = new List<string>();
            foreach (string item in headerContent.Take(1).ToList())
            {
                string[] splitHeaders = item.Split(',').Skip(2).ToArray();
                string putComma = string.Join(",", splitHeaders);
                getHeaderLabel.Add(putComma);                
            }            
            return getHeaderLabel;
        }

        public int countSkillLabel(List<string> headerContent)
        {
            int lengthItem = 0;
            foreach(string item in headerContent.Take(1))
            {
                string[] splitHeaders = item.Split(',');
                List<string> skipLabel = splitHeaders.Skip(3).ToList();
                lengthItem = skipLabel.Count;
                //MessageBox.Show(string.Concat(skipLabel.Count));
            }            
            return lengthItem;
        }

        public string autoGetSkillGrade(List<string> employeeContent, int itemIndex)
        {
            string skillsGrades = "";
            foreach (string skillsContent in employeeContent.Skip(1))
            {
                // skips the 0-2 index of array
                string[] seperateSkillContent = skillsContent.Split(',').Skip(2).ToArray();
                string[] getSkillsGrades = { seperateSkillContent[itemIndex] };
                skillsGrades += string.Join(",",getSkillsGrades) + ",";
            }
            //MessageBox.Show(skillsGrades);
            return skillsGrades;
        }

        public void createFile(string Path, List<string> contents)
        {           
           File.WriteAllLines(Path+"\\Evaluation.txt", contents);            
           MessageBox.Show("File has been created. File can be viewed @ \n" + Path);
        }

        public void readMe5Instucrtion(string Path)
        {
            StreamWriter create5SkillText = new StreamWriter(Path+"\\5Skills.txt");
            create5SkillText.Write("First Name, Middle Name, Last Name, SkillOne, SkillTwo, SkillThree, SkillFour, SkillFive");
            create5SkillText.Write("\n" + "sample,sample,sample,5,5,5,5,5");
            create5SkillText.Write("\n" + "follow,this,exact sample,1,1,1,1,1");
            create5SkillText.Close();
        }

        public void readMeMoreThan5Instucrtion(string Path)
        {
            StreamWriter create5SkillText = new StreamWriter(Path + "\\MoreThan5Skills.txt");
            create5SkillText.Write("First Name, Middle Name, Last Name, SkillOne, SkillTwo, SkillThree, SkillFour, SkillFive, SkillSix, SkillSeven, SkillEight, SkillNine, SkillTen");
            create5SkillText.Write("\n" + "sample,sample,sample,5,5,5,5,5,5,5,5,5,5");
            create5SkillText.Write("\n" + "follow,this,exact sample,1,1,1,1,1,1,1,1,1,1");
            create5SkillText.Close();
        }

        public void readMeMoreInformation(string Path)
        {
            StreamWriter create5SkillText = new StreamWriter(Path + "\\Contact.txt");
            create5SkillText.Write("This is just for demo. \n and i will stop the develop from here ;p. \n if you are interested you may contact me on the following...\n" +
                "Viber / Telegram : +639668829302" +
                "\n Skype : calsena.skype@gmail.com");
            create5SkillText.Close();
        }
    }
}
