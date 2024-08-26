using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission1
{
    public class AdmissionDetails
    {
        static int s_admissionID=1000;
        public string AdmissionID { get; set; }
        public string StudentID { get; set; }
        public string DepartmentID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public AdmissionStatusDetails AdmissionStatus { get; set; }

        public AdmissionDetails(string studentID,string departmentID, DateTime admissionDate,AdmissionStatusDetails admissionStatus){
            s_admissionID++;
            AdmissionID="AID"+s_admissionID;
            StudentID=studentID;
            DepartmentID=departmentID;
            AdmissionDate=admissionDate;
            AdmissionStatus=admissionStatus;
        }
    }
}