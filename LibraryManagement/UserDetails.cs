using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class UserDetails
    {
        static int s_userID=3000;
        public string UserID { get; }
        public string UserName { get; set; }
        public GenderDetails Gender { get; set; }
        public DepartmentDetails Department { get; set; }
        public long PhoneNumber { get; set; }
        public string MailID { get; set; }
        
        public double WalletBalance { get;set; }

        public UserDetails(string userName,GenderDetails gender,DepartmentDetails department,long phoneNumber, string mailID, double walletBalance){
            s_userID++;
            UserID="SF"+s_userID;
            UserName=userName;
            Gender=gender;
            Department=department;
            PhoneNumber=phoneNumber;
            MailID=mailID;
            WalletBalance=walletBalance;
        }

        public void WalletRecharge(double amount){
            WalletBalance=WalletBalance+amount;
        }
        public void DeducedBalance(double amount){
            WalletBalance=WalletBalance-amount;
        }
    }
}