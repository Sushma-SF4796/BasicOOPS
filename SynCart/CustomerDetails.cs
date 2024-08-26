using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
    public class CustomerDetails
    {
        public static int s_studentID=3000;
        public string Name { get; set; }
        public string City { get; set; }
        public long PhoneNumber { get; set; }
        public double Balance { get; set; }
        public string MailID { get; set; }
        public string CustomerID { get; set; }

        public CustomerDetails(string name, string city, long phoneNumber,double balance, string mailID){
            Name= name;
            City= city;
            PhoneNumber= phoneNumber;
            Balance= balance;
            MailID=mailID;
            s_studentID++;
            CustomerID="CID"+s_studentID;
        }
    }
}