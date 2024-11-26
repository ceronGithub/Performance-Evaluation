using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee_evaluation
{
    internal class Employee
    {
        public Employee(string firstName, string middleName, string lastName, string skillOne, string skillTwo, string skillThree, string skillFour, string skillFive, string over_All_Skill)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            this.skillOne = skillOne;
            this.skillTwo = skillTwo;
            this.skillThree = skillThree;
            this.skillFour = skillFour;
            this.skillFive = skillFive;
            Over_All_Skill = over_All_Skill;
        }

        // automatic property
        // similar to private string Firstname;
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string skillOne { get; set; }
        public string skillTwo { get; set; }
        public string skillThree { get; set; }
        public string skillFour { get; set; }
        public string skillFive { get; set; }
        public string Over_All_Skill { get; set; }

        public override string ToString()
        {
            return "First Name: " + FirstName + ", " + "Middle Name: " + MiddleName + ", " + "Last Name: " + LastName + ", " + "C# skill: " + skillOne + ", " + "Javascript skill: " + skillTwo + ", " + "CSS skill: " + skillThree + ", " + "HTML skill: " + skillFour + ", " + "Laravel: " + skillFive + ", " + "Over all performance: " + Over_All_Skill;
        }
    }
}
