using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace employee_evaluation
{
    internal class Create_Folder
    {
        string defaulFilePath = @"" + Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Desktop\\Performance Output";
        public void createDesktopFolder()
        {
            // this checks if the folder has been created. and if not create one
            // compilation of system output 
            if(!Directory.Exists(defaulFilePath))
            {
                // create folder
                Directory.CreateDirectory(defaulFilePath);
                MessageBox.Show("Folder is created @ \n" + defaulFilePath);
            }
            else
            {
                MessageBox.Show("Folder compilation is existing.");
            }
        }
    }
}
