using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission1
{
    public class StudentDetails
    {
        static int s_studentID=3000;
        public string  StudentID { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public DateTime DOB { get; set; }
        public GenderDetails Gender { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Maths { get; set; }


        public StudentDetails(string name,string fatherName, GenderDetails gender, DateTime dob, int physics, int chemistry, int maths){
           s_studentID++;
           StudentID="SF"+s_studentID;
            StudentName=name;//"Name" is a property and "name" is a local variable
            FatherName=FatherName;
            Gender=gender;
            DOB=dob;
            Physics=physics;
            Chemistry=chemistry;
            Maths=maths;
    }
     public int TotalMarks(){
            return Physics+Chemistry+Maths;
        }
        public double Average(){
            return (double)TotalMarks()/3;
        }
        public bool IsEligible(double cutoff){
            if(Average()>=cutoff)
            return true;
            return false;
        }
}
}