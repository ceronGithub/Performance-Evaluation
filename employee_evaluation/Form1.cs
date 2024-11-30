using System;
using System.Collections.Generic;
using System.Drawing;
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

        Path_class folderPath = new Path_class();
        string filePath;
        string gradingH = "0", gradingL = "0";

        List<Chart> chartContent = new List<Chart>();                     

        // Classes
        Create_Folder folderCreation = new Create_Folder();
        General_class classesMethods = new General_class();

        public Form1()
        {
            InitializeComponent();

            // creates folder to desktop
            folderCreation.createDesktopFolder();
            // creates a subFolder named:readme
            folderCreation.ReadMe();
            //creates a file in the subfolder readme
            classesMethods.readMe5Instucrtion(folderPath.ReadMeFolderPath());
            classesMethods.readMeMosreThan5Instucrtion(folderPath.ReadMeFolderPath());
            classesMethods.readMeMoreInformation(folderPath.ReadMeFolderPath());

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(Int32.Parse(gradingH) == 0 && Int32.Parse(gradingL) == 0)
            {
                MessageBox.Show("Please set grading for high, and low. to be able to evaluate all employee/s", "NOTE!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("A grading system has been set. \nfor Highest grade :" + gradingH + "\nfor Lowest grade :" + gradingL, "NOTE!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // this function enables the form1 to recieve data from other form/s
        public string Reciever(string Fvalue, string Lvalue)
        {
            gradingH = Fvalue;
            gradingL = Lvalue;
            return gradingH + gradingL;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
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
                    button1.Text = "Reset";
                    button2.Enabled = false; button3.Enabled = true; button4.Enabled = true;
                }
            }
            else
            {
                // reset the form, to its original form
                this.WindowState = FormWindowState.Normal;
                this.Controls.Clear();
                this.InitializeComponent();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int countSkillLabel = classesMethods.countSkillLabel(File.ReadAllLines(filePath).ToList());

            // creates subfolder
            folderCreation.createSubFolder();
            folderCreation.createSubChartPictureFolder();

            // MessageBox.Show(""+countSkillLabel);

            // locates the textfile and read its whole content.
            // and stores its content to a list. a list is where you can store texts in an array form.
            List<string> personContent = classesMethods.exportToTextFile(File.ReadAllLines(filePath).ToList());

            if (countSkillLabel <= 5)
            {
                // creates 5 skill folder                
                folderCreation.createSub5SkillsFolder();

                // calls the functions createFile from Employee class and pass the file path, and the contents
                // this method is to create a text file
                classesMethods.createFile(folderPath.SubFolderBelow5SkillLabelsPath(), personContent);
            }
            else
            {
                // creates 5 skill folder
                folderCreation.createSubMoreThan5SkillsFolder();
                classesMethods.createFile(folderPath.SubFolderMoreThan5SkillLabelsPath(), personContent);
            }
        }

        //this functions gets data from textfile
        //gathered data from textfile will be plot into the charts
        //it has a auto generated charts
        private void button3_Click(object sender, EventArgs e)  
        {            
            // checks if gradings has value
            if (gradingH != "0" && gradingL != "0")
            {
                string checker = classesMethods.textFileChecker(File.ReadAllLines(filePath).ToList());
                if (checker == "Pass")
                {
                    // this counts how many skillLabel are registered
                    int countSkillLabel = classesMethods.countSkillLabel(File.ReadAllLines(filePath).ToList());
                    if (countSkillLabel <= 5)
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

                        List<string> headerSkillLabel = classesMethods.headerSkillLabel(File.ReadAllLines(filePath).ToList());

                        foreach (string Labels in headerSkillLabel)
                        {
                            string[] splitHeaderIntoLabel = Labels.Split(',');
                            // auto generates charts
                            int locCord0 = flatPointsCharts(personNames, skillOneArray, "-" + splitHeaderIntoLabel[3], 0, countSkillLabel);
                            int locCord1 = flatPointsCharts(personNames, skillTwoArray, "-" + splitHeaderIntoLabel[4], locCord0, countSkillLabel);
                            int locCord2 = flatPointsCharts(personNames, skillThreeArray, "-" + splitHeaderIntoLabel[5], locCord1, countSkillLabel);
                            int locCord3 = flatPointsCharts(personNames, skillFourArray, "-" + splitHeaderIntoLabel[6], locCord2, countSkillLabel);
                            int locCord4 = flatPointsCharts(personNames, skillFiveArray, "-" + splitHeaderIntoLabel[7], locCord3, countSkillLabel);
                        }
                        button2.Enabled = true;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        this.WindowState = FormWindowState.Maximized;
                        this.MaximizeBox = false;
                    }
                    foreach (Chart chartElement in chartContent)
                    {
                        chartElement.SaveImage(folderPath.chartPicturePath() + "\\" + chartElement.Width + ".png", ChartImageFormat.Png);
                    }
                }
                else
                {
                    // text, title, button, icon
                    MessageBox.Show("Please double check the the textfile, check if there's any missing value and a row without value.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please set a grading standard", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // checks if gradings has value
            if (gradingH != "0" && gradingL != "0")
            {
                string checker = classesMethods.textFileChecker(File.ReadAllLines(filePath).ToList());
                if (checker == "Pass")
                {
                    int countSkillLabel = classesMethods.countSkillLabel(File.ReadAllLines(filePath).ToList());
                    string[] skillArray = new string[countSkillLabel];                    
                    int LocCord = 0;
                    string[] headerLabels = new string[countSkillLabel];
                    string personName = (classesMethods.personInfo(File.ReadAllLines(filePath).ToList()));
                    string[] personNames = { personName };

                    List<string> headerSkillLabel = classesMethods.autoHeaderSkillLabel(File.ReadAllLines(filePath).ToList());
                    if (countSkillLabel > 7)
                    {
                        for (int i = 0; i < countSkillLabel; i++)
                        {
                            // every loop the skillGrade from text is stored into the skillArray variable as an array
                            skillArray[i] = (classesMethods.autoGetSkillGrade(File.ReadAllLines(filePath).ToList(), i));

                            foreach (string Labels in headerSkillLabel)
                            {
                                string[] splitHeaderIntoLabel = Labels.Split(',');
                                // auto generates charts
                                if (LocCord == 0)
                                {
                                    // locCord = 0;
                                    LocCord = flatPointsCharts(personNames, new string[] { skillArray[i] }, "-" + splitHeaderIntoLabel[i], 0, countSkillLabel);
                                }
                                else if (LocCord == 76)
                                {
                                    // locCord = 76
                                    LocCord = flatPointsCharts(personNames, new string[] { skillArray[i] }, "-" + splitHeaderIntoLabel[i], 76, countSkillLabel);
                                }
                                else if (LocCord != 76)
                                {
                                    //locCord = 306;                            
                                    LocCord = flatPointsCharts(personNames, new string[] { skillArray[i] }, "-" + splitHeaderIntoLabel[i], LocCord, countSkillLabel);
                                }
                            }
                        }
                        button2.Enabled = true;
                    }
                    // unclickable button 3,4
                    button3.Enabled = false;
                    button4.Enabled = false;
                    this.WindowState = FormWindowState.Maximized;
                    this.MaximizeBox = false;
                }
                else
                {
                    // text, title, button, icon
                    MessageBox.Show("Please double check the the textfile, check if there's any missing value and a row without value.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please set a grading standard", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // exit the application completely
            Application.Exit();
        }

        public int flatPointsCharts(string[] personContent, string[] gradeContent, string seriesName, int locationCord, int chartNumber)
        {
            // if-else statements
            int locationCoordinates = locationCord == 0 ? locationCord = 76
                : locationCord == 76 ? locationCord += 306
                : locationCord = locationCord + 306;
            
            // run thru the persoContentArray collection
            foreach (string nameLabel in personContent)
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
                    //Chart[] chartArray = new Chart[chartNumber];
                    //List<Chart> newChart = new List<Chart>();
                    //Chart[] newChart = new Chart[u];
                    Chart newChart = new Chart();
                    newChart.Height = 300;
                    newChart.Width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
                    newChart.Series.Clear();
                    var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        Name = seriesName,
                        Color = Color.FromArgb(randomClr.Next(0, 255), randomClr.Next(0, 255), randomClr.Next(0, 255)),
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
                    //chartArea.CursorX.IsUserEnabled = true;
                    //chartArea.CursorY.IsUserEnabled = true;
                    //chartArea.AxisX.ScaleView.Zoomable = true;
                    //chartArea.AxisY.ScaleView.Zoomable = true;
                    //chartArea.CursorX.AutoScroll = true;
                    //chartArea.CursorY.AutoScroll = true;
                    chartArea.AxisX.ScaleView.Zoom(0, 8);
                    chartArea.AxisX.ScaleView.MinSize = 0;
                    chartArea.AxisX.ScrollBar.Enabled = true;
                    chartArea.AxisX.ScrollBar.IsPositionedInside = true;
                    chartArea.AxisX.ScrollBar.Size = 20;
                    chartArea.AxisX.ScrollBar.ButtonColor = Color.Silver;
                    chartArea.AxisX.ScrollBar.LineColor = Color.Black;
                    //chartArea.AxisY.ScrollBar.Enabled = true;
                    //chartArea.AxisX.IsLabelAutoFit = true;
                    // add label on Y and X axis
                    chartArea.AxisX.Title = "Employee/s";
                    chartArea.AxisX.TitleAlignment = StringAlignment.Far;
                    chartArea.AxisY.Title = "Grading";
                    chartArea.AxisY.TitleAlignment = StringAlignment.Far;

                    chartArea.Name = "ChartArea";
                    newChart.ChartAreas.Add(chartArea);

                    Legend legend1 = new Legend();
                    legend1.Name = "Legend";
                    newChart.Legends.Add(legend1);
                    newChart.Location = new System.Drawing.Point(0, locationCoordinates);
                    newChart.Name = "chart";                              
                    //newChart.Dock = System.Windows.Forms.DockStyle.Fill;                    
                    newChart.Visible = true;
                    Controls.Add(newChart);
                    chartContent.Add(newChart);                    
                }   
            }            
            return locationCoordinates;
        }

        public void arrayChart(string[] personContent, string[] gradeContent, string seriesName, int locationCord, int chartNumber)
        {
            foreach (string nameLabel in personContent)
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
                    //Chart[] chartArray = new Chart[chartNumber];
                    //List<Chart> newChart = new List<Chart>();
                    Chart newChart = new Chart();

                    newChart.Height = 300;
                    newChart.Width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
                    newChart.Series.Clear();
                    var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        Name = seriesName,
                        Color = Color.FromArgb(randomClr.Next(0, 255), randomClr.Next(0, 255), randomClr.Next(0, 255)),
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
                    //chartArea.CursorX.IsUserEnabled = true;
                    //chartArea.CursorY.IsUserEnabled = true;
                    //chartArea.AxisX.ScaleView.Zoomable = true;
                    //chartArea.AxisY.ScaleView.Zoomable = true;
                    //chartArea.CursorX.AutoScroll = true;
                    //chartArea.CursorY.AutoScroll = true;
                    chartArea.AxisX.ScaleView.Zoom(0, 8);
                    chartArea.AxisX.ScaleView.MinSize = 0;
                    chartArea.AxisX.ScrollBar.Enabled = true;
                    chartArea.AxisX.ScrollBar.IsPositionedInside = true;
                    chartArea.AxisX.ScrollBar.Size = 20;
                    chartArea.AxisX.ScrollBar.ButtonColor = Color.Silver;
                    chartArea.AxisX.ScrollBar.LineColor = Color.Black;
                    //chartArea.AxisY.ScrollBar.Enabled = true;
                    //chartArea.AxisX.IsLabelAutoFit = true;
                    // add label on Y and X axis
                    chartArea.AxisX.Title = "Employee/s";
                    chartArea.AxisX.TitleAlignment = StringAlignment.Far;
                    chartArea.AxisY.Title = "Grading";
                    chartArea.AxisY.TitleAlignment = StringAlignment.Far;

                    chartArea.Name = "ChartArea";
                    newChart.ChartAreas.Add(chartArea);

                    Legend legend1 = new Legend();
                    legend1.Name = "Legend";
                    newChart.Legends.Add(legend1);
                    newChart.Location = new System.Drawing.Point(0, 76);

                    //newChart.Dock = System.Windows.Forms.DockStyle.Fill;                    
                    newChart.Visible = true;
                    Controls.Add(newChart);
                }
            }
        }
    }
}
