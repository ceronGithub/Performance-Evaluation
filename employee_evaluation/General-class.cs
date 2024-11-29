using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;
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
        
        public List<string> exportToTextFile(List<string> value)
        {
            // this calls the Employee class
            List<Employee> listOfEmployee = new List<Employee>();

            // create a new list
            List<string> headerContent = new List<string>();
            List<string> personContent = new List<string>();
            List<string> gradingContent = new List<string>();
            List<string> contents = new List<string>();
            
            // header value
            foreach(string Info in value.Take(1))
            {
                // this removes the comma to the value
                string[] items = Info.Split(',');

                // adds a comma in between header
                string addSeperator = string.Join(",", items);
                
                // convert string into a list
                headerContent.Add(addSeperator);
            }
            // person Name value
            foreach(string Info in value.Skip(1))
            {
                // this removes the comma to the value
                string[] items = Info.Split(',');

                // adds a comma in between header
                string addSeperator = string.Join(",", items);                

                // convert string into a list
                personContent.Add(addSeperator);                
            }
            // grade value
            foreach (string Info in value.Skip(1))
            {
                // this removes the comma to the value
                string[] items = Info.Split(',');

                // adds a comma in between header
                string addSeperator = string.Join(",", items.Skip(3));

                // convert string into a list
                gradingContent.Add(addSeperator);
            }            

            // employee is a constructor
            Employee personInfo = new Employee(headerContent, personContent);
            
            // addes the persons into a new list
            contents.Add(personInfo.ToString());
            // return the list content array

            return contents;
        }
        /*
        public List<string> makeEmployeeAsObjectMoreThan5Skills(List<string> value)
        {           
            // create a new list
            List<string> skillGrades = new List<string>();
            List<string> skillLabels = new List<string>();
            List<string> contents = new List<string>();
            //take header skills only
            foreach (string header in value.Take(1))
            {
                // splits all taken value except the personInfo and grades
                string[] splitLabels = header.Split(',');
                // adds a comma
                string addSeperator = string.Join(",", splitLabels.Skip(3));
                // add the string to list<string>
                skillLabels.Add(addSeperator);
                //MessageBox.Show(string.Concat(1));
            }

            // skip header label
            foreach (string grades in value.Skip(1))
            {
                // splits all taken value except header
                string[] splitGrades = grades.Split(',').Skip(3).ToArray();
                // adds a comma
                string addSeperator = string.Join(",", splitGrades);
                // add the string to list<string>
                skillGrades.Add(addSeperator);
                //MessageBox.Show(string.Concat(2));
            }

            foreach (string personInfo in value.Take(1))
            {
                string[] splitPersonHeader = personInfo.Split(',');
                ExportEmployeeMoreThan5Skills output = new ExportEmployeeMoreThan5Skills(splitPersonHeader[0], splitPersonHeader[1], splitPersonHeader[2], skillLabels, skillGrades);
                contents.Add(output.ToString());
                //MessageBox.Show(string.Concat(3));
            }
            //MessageBox.Show(string.Concat(personName));
            // return the list content array
            return value;
        }
        */
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
            //MessageBox.Show(string.Concat(headerContent.Take(1)));
            return headerContent.Take(1).ToList();
        }
        public List<string> autoHeaderSkillLabel(List<string> headerContent)
        {
            List<string> getHeaderSkillLabel = new List<string>();
            foreach (string item in headerContent.Take(1).ToList())
            {
                string[] splitHeaders = item.Split(',').Skip(3).ToArray();
                string putComma = string.Join(",", splitHeaders);
                getHeaderSkillLabel.Add(putComma);                
            }            
            return getHeaderSkillLabel;
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
                // skips the 1-3 index of array
                string[] seperateSkillContent = skillsContent.Split(',').Skip(3).ToArray();                
                string[] getSkillsGrades = { seperateSkillContent[itemIndex] };
                skillsGrades += string.Join(",",getSkillsGrades) + ",";
            }            
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
            create5SkillText.Write("First Name, Middle Name, Last Name, SkillOne, SkillTwo, SkillThree, SkillFour, SkillFive, Over-all");
            create5SkillText.Write("\n" + "sample,sample,sample,5,5,5,5,5,0");
            create5SkillText.Write("\n" + "follow,this,exact sample,1,1,1,1,1,0");
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

        public static void staticMethod()
        {
            MessageBox.Show("static");
        }
        public void nonStaticMethod()
        {
            MessageBox.Show("non-static");
        }
    }
}
