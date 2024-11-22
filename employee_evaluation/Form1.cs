using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace employee_evaluation
{
    public partial class Form1 : Form
    {
        // allow the user to browse files
        OpenFileDialog browseFile = new OpenFileDialog();

        //string mainDefaultFilePath = @"" + Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Desktop\\Performance Output";
        Path_class folderPath = new Path_class();
        string filePath;
        string gradingH = "0", gradingL = "0";

        List<string> lines = new List<string>();
        // a list and calling the employee class
        List<Employee> people = new List<Employee>();

        // Classes
        Create_Folder folderCreation = new Create_Folder();
        General_class classesMethods = new General_class();

        public Form1()
        {
            InitializeComponent();            
            folderCreation.createDesktopFolder();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        public string Reciever(string Fvalue, string Lvalue)
        {            
            gradingH = "" + Fvalue;
            gradingL = "" + Lvalue;
            return gradingH + gradingL;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // allow text, and excel file only
            browseFile.Filter = "Document File |*.txt;*.xlsx";
            // if click ok          
            if(browseFile.ShowDialog() == DialogResult.OK)
            {
                // the path will show on the textbox
                textBox1.Text = Path.GetFullPath(browseFile.FileName);

                // set the filepath into string
                filePath = Path.GetFullPath(browseFile.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // locates the textfile and read its whole content.
            // and stores its content to a list. a list is where you can store texts in an array form.
            List<string> contents = classesMethods.makeEmployeeAsObject(File.ReadAllLines(filePath).ToList());

            // creates subfolder
            folderCreation.createSubFolder();

            // calls the functions createFile from Employee class and pass the file path, and the contents
            // this method is to create a text file
            classesMethods.createFile(folderPath.SubFolderPath(), contents);
            
        }
        private void button3_Click(object sender, EventArgs e)
        {            
            string grades = (classesMethods.skillsGrade(File.ReadAllLines(filePath).ToList()));
            string[] gradesArray = { grades };
            foreach(string grade in gradesArray)
            {                
                string[] splitterArray = grade.Split(',');
                for(int i = 0; i < splitterArray.Length; i++)
                {
                    chart1.Series["C#"].Points.AddXY(i, splitterArray[i]);
                }
            }            
        }

        private void mainDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(folderPath.MainFolderPath());            
        }

        private void highestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(gradingH);
        }

        private void lowestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(gradingL);
        }

        private void editGradingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Grading_System f2 = new Grading_System();
            f2.Show();
            this.Hide();
        }
    }
}
