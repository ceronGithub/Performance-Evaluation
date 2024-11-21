using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace employee_evaluation
{
    public partial class Form1 : Form
    {
        // allow the user to browse files
        OpenFileDialog browseFile = new OpenFileDialog();

        string mainDefaultFilePath = @"" + Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Desktop\\Performance Output";
        string filePath;

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

            string test = General_class.makeEmployeeAsObject(File.ReadAllLines(filePath).ToList());
            MessageBox.Show(test);
        }

        private void mainDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(mainDefaultFilePath);            
        }

    }
}
