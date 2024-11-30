using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace employee_evaluation
{
    public partial class Grading_System : Form
    {
        Form1 f1 = new Form1();
        public Grading_System()
        {
            InitializeComponent();
        }
        
        private void Grading_System_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {            
            f1.Reciever(textBox1.Text, textBox2.Text);
            f1.Show();
            this.Close();
        }

        private void Grading_System_FormClosed(object sender, FormClosedEventArgs e)
        {
            f1.Show();
        }
    }
}
