using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourse
{
    public class EnrollmentDetail
    {
        public static int s_enrollmentID=2000;
        public string EnrollmentID { get; set; }
        public string CourseID { get; set; }
        public string RegistrationID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public EnrollmentDetail(string courseID,string registrationID, DateTime enrollmentDate){
            s_enrollmentID++;
            EnrollmentID="EMT"+s_enrollmentID;
            CourseID=courseID;
            RegistrationID=registrationID;
            EnrollmentDate=enrollmentDate;

        }
    }
}