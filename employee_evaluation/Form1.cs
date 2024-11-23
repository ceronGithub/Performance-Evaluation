using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace employee_evaluation
{
    public partial class Form1 : Form
    {
        // allow the user to browse files
        OpenFileDialog browseFile = new OpenFileDialog();
       
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

            // creates folder to desktop
            folderCreation.createDesktopFolder();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // button 2 & 3, is not clickable
            button3.Enabled = false;
            button2.Enabled = false;
        }
        
        // this function enables the form1 to recieve data from other form/s
        public string Reciever(string Fvalue, string Lvalue)
        {            
            gradingH = "" + Fvalue;
            gradingL = "" + Lvalue;
            return gradingH + gradingL;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                // allow text, and excel file only
                browseFile.Filter = "Document File |*.txt;*.xlsx";
                // if click ok          
                if (browseFile.ShowDialog() == DialogResult.OK)
                {
                    // the path will show on the textbox
                    textBox1.Text = Path.GetFullPath(browseFile.FileName);

                    // set the filepath into string
                    filePath = Path.GetFullPath(browseFile.FileName);


                    // change the button1 text to reset if textbox1 is not null
                    button1.Text = "reset";
                    button3.Enabled = true; button2.Enabled = true;
                }
            }
            else
            {                
                // reset the form, to its original form
                this.Controls.Clear();
                this.InitializeComponent();
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

        //this functions gets data from textfile
        //gathered data from textfile will be plot into the charts
        //it has a auto generated charts
        private void button3_Click(object sender, EventArgs e)
        {            

            // store strings from other class
            string skillGradeOne = (classesMethods.getSkillOne(File.ReadAllLines(filePath).ToList()));
            string skillGradeTwo = (classesMethods.getSkillTwo(File.ReadAllLines(filePath).ToList()));
            string skillGradeThree = (classesMethods.getSkillThree(File.ReadAllLines(filePath).ToList()));
            string skillGradeFour = (classesMethods.getSkillFour(File.ReadAllLines(filePath).ToList()));
            string skillGradeFive = (classesMethods.getSkillFive(File.ReadAllLines(filePath).ToList()));

            string personName = (classesMethods.personInfo(File.ReadAllLines(filePath).ToList()));
            
            // convert string variable into an array string variable
            string[] skillOneArray = { skillGradeOne };
            string[] skillTwoArray = { skillGradeTwo };
            string[] skillThreeArray = { skillGradeThree };
            string[] skillFourArray = { skillGradeFour };
            string[] skillFiveArray = { skillGradeFive };

            string[] personNames = { personName };

            // auto generates charts
            int locCord0 = flatPointsCharts(personNames, skillOneArray, "C#", 0);
            int locCord1 = flatPointsCharts(personNames, skillTwoArray, "Js", locCord0);
            int locCord2 = flatPointsCharts(personNames, skillThreeArray, "CSS", locCord1);
            int locCord3 = flatPointsCharts(personNames, skillFourArray, "HTML", locCord2);
            int locCord4 = flatPointsCharts(personNames, skillFiveArray, "Laravel", locCord3);

            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            classesMethods.getSkillOne(File.ReadAllLines(filePath).ToList());
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

        public int flatPointsCharts(string[] personContent, string[] gradeContent, string seriesName, int locationCord)
        {
            // if-else statements
            int locationCoordinates = locationCord == 0 ? locationCord = 12 : locationCord = locationCord + 586;
                           
            // run thru the persoContentArray collection
            foreach(string nameLabel in personContent)
            {
                //split each array into an objects
                string[] splitNameLabel = nameLabel.Split(',');

                // run thru the gradeContentArray collection
                foreach (string gradeValue in gradeContent)
                {
                    //split each array into an objects
                    string[] splitSkill = gradeValue.Split(',');

                    // chart creation
                    Random randomClr = new Random();
                    Chart newChart = new Chart();
                    newChart.Height = 300;
                    newChart.Width = 580;
                    newChart.Series.Clear();
                    var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        Name = seriesName,
                        Color = Color.FromArgb(randomClr.Next(0, 255), randomClr.Next(0, 255), randomClr.Next(0,255)),//System.Drawing.Color.Green,
                        IsVisibleInLegend = true,
                        IsXValueIndexed = true,
                        ChartType = SeriesChartType.Column
                    };
                    newChart.Series.Add(series1);
                    
                    for (int i = 0; i < splitSkill.Length; i++)
                    {
                        series1.Points.AddXY(splitNameLabel[i], splitSkill[i]);
                    }
                    newChart.Invalidate();
                    ChartArea chartArea = new ChartArea();
                    chartArea.CursorX.IsUserEnabled = true;
                    chartArea.CursorY.IsUserEnabled = true;
                    chartArea.AxisX.ScaleView.Zoomable = true;
                    chartArea.AxisY.ScaleView.Zoomable = true;
                    chartArea.CursorX.AutoScroll = true;
                    chartArea.CursorY.AutoScroll = true;
                    chartArea.Name = "ChartArea1";
                    newChart.ChartAreas.Add(chartArea);

                    Legend legend1 = new Legend();
                    legend1.Name = "Legend";
                    newChart.Legends.Add(legend1);
                    newChart.Location = new System.Drawing.Point(locationCoordinates, 82);
                    //newChart.Dock = System.Windows.Forms.DockStyle.Fill;                    
                    newChart.Visible = true;
                    Controls.Add(newChart);
                }
            }
            return locationCoordinates;
        }
    }
}
