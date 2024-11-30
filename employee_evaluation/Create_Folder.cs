﻿using System;
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
        Path_class folderPath = new Path_class();
        public void createDesktopFolder()
        {
            // this checks if the folder has been created. and if not create one
            // compilation of system output 
            if(!Directory.Exists(folderPath.MainFolderPath()))
            {
                // create folder
                Directory.CreateDirectory(folderPath.MainFolderPath());
                MessageBox.Show("Folder is created @ \n" + folderPath.MainFolderPath());
            }
            else
            {
                //MessageBox.Show("Folder compilation is existing.");
            }
        }

        public void createSubFolder()
        {            
            if (!Directory.Exists(folderPath.SubFolderPath()))
            {
                Directory.CreateDirectory(folderPath.SubFolderPath());               
            }
            else
            {
                // MessageBox.Show("Folder is existing!");
            }
            //return subFolder;
        }

        public void createSub5SkillsFolder()
        {
            if (!Directory.Exists(folderPath.SubFolderBelow5SkillLabelsPath()))
            {
                Directory.CreateDirectory(folderPath.SubFolderBelow5SkillLabelsPath());
            }
            else
            {
                // MessageBox.Show("Folder is existing!");
            }
            //return subFolder;
        }
        public void createSubMoreThan5SkillsFolder()
        {
            if (!Directory.Exists(folderPath.SubFolderMoreThan5SkillLabelsPath()))
            {
                Directory.CreateDirectory(folderPath.SubFolderMoreThan5SkillLabelsPath());
            }
            else
            {
                // MessageBox.Show("Folder is existing!");
            }
            //return subFolder;
        }

        public void createSubChartPictureFolder()
        {
            if (!Directory.Exists(folderPath.chartPicturePath()))
            {
                Directory.CreateDirectory(folderPath.chartPicturePath());
            }
            else
            {
                // MessageBox.Show("Folder is existing!");
            }
            //return subFolder;
        }

        public void ReadMe()
        {
            string readMeFolder = folderPath.ReadMeFolderPath();
            if (!Directory.Exists(folderPath.ReadMeFolderPath()))
            {
                Directory.CreateDirectory(folderPath.ReadMeFolderPath());
            }
            else
            {
                // MessageBox.Show("Folder is existing!");
            }
        }
    }
}
