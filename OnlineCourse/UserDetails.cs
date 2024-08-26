using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourse
{
    public class UserDetails
    {
        public static int s_registrationID=1000;
        public string RegistrationID { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public GenderDetails Gender { get; set; }
        public String Qualification { get; set; }
        public long PhoneNumber { get; set; }
        public string MailID { get; set; }

        public UserDetails(string name, int age, GenderDetails gender,string qualification, long phoneNumber, string mailID){
            s_registrationID++;
            RegistrationID="SYNC"+s_registrationID;
            UserName=name;
            Qualification=qualification;
            Age=age;
            Gender=gender;
            PhoneNumber=phoneNumber;
            MailID= mailID;
        }

    }
}