using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee_evaluation
{
    internal class Path_class
    {
        //string mainFolderPath = @"C:\Desktop\Reports";
        string mainFolderPath = @""+ Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Desktop\\Report";

        //string subFolderPath = @"C:\Desktop\Reports\"+ DateTime.Now.ToString("MM-dd-yyyy")+"\\Evaluation";
        string subFolderPath;

        public string MainFolderPath ()
        {
            return mainFolderPath;
        }

        public string SubFolderPath()
        {
            return subFolderPath = mainFolderPath + "\\Evaluation - " + DateTime.Now.ToString("MM-dd-yyyy");
        }
    }
}
