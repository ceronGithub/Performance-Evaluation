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
            string skillGradeOne = (classesMethods.getSkillOne(File.ReadAllLines(filePath).ToList()));
            string skillGradeTwo = (classesMethods.getSkillTwo(File.ReadAllLines(filePath).ToList()));
            string personName = (classesMethods.personInfo(File.ReadAllLines(filePath).ToList()));
            
            string[] skillOneArray = { skillGradeOne };
            string[] skillTwoArray = { skillGradeTwo };
            string[] skillThreeArray = { skillGradeOne };
            string[] skillFourArray = { skillGradeOne };
            string[] skillFiveArray = { skillGradeOne };

            string[] personNames = { personName };

            foreach(string nameLabel in personNames)
            {
                string[] splitNameLabel = nameLabel.Split(',');
                foreach (string skillOne in skillOneArray)
                {
                    string[] splitSkillOne = skillOne.Split(',');
                    for (int i = 0; i < splitSkillOne.Length; i++)
                    {
                        chart1.Series["C#"].Points.AddXY(splitNameLabel[i], splitSkillOne[i]);                                       
                    }
                }                            
            }

            flatPointsCharts(personNames, skillTwoArray, "CSS");
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

        public void flatPointsCharts(string[] personContent, string[] gradeContent, string seriesName)
        {
            foreach(string nameLabel in personContent)
            {
                string[] splitNameLabel = nameLabel.Split(',');
                foreach (string gradeValue in gradeContent)
                {
                    string[] splitSkill = gradeValue.Split(',');

                    Chart newChart = new Chart();
                    newChart.Height = 300;
                    newChart.Width = 580;
                    newChart.Series.Clear();
                    var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        Name = seriesName,
                        Color = System.Drawing.Color.Green,
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
                    newChart.Location = new System.Drawing.Point(380 + 586, 69);
                    //newChart.Dock = System.Windows.Forms.DockStyle.Fill;                    
                    newChart.Visible = true;
                    Controls.Add(newChart);
                }
            }
        }
    }
}
