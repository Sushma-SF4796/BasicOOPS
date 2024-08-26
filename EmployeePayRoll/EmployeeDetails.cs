using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayRoll
{
    public class EmployeeDetails
    {
        private int _id=1000;
        public string EmployeeID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public WorkLocationDetails WorkLocation { get; set; }
        public string TeamName { get; set; }
        public DateTime JoiningDate { get; set; }
        public int LeavesTaken { get; set; }
        public GenderDetails Gender { get; set; }
        public int WorkingDays { get; set; }

        public EmployeeDetails(string name, string role,WorkLocationDetails workLocation, string teamName, DateTime joiningDate, int leavesTaken, GenderDetails gender, int workingDays){
            _id++;
            EmployeeID="SF"+_id;
            Name=name;
            Role= role;
            WorkLocation= workLocation;
            TeamName=teamName;
            JoiningDate= joiningDate;
            WorkingDays=workingDays;
            LeavesTaken=leavesTaken;
            Gender= gender;
            

        }
        public int salary(int workingDays,int leavesTaken){
            return (workingDays-leavesTaken)*500;
        }
    }
}