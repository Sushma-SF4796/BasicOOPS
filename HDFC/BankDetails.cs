using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDFC
{
    
     class BankDetails
    {
        private static int _customerID=1000;
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public double Balance { get;  }
        public GenderDetails Gender { get; set; }
        public long PhoneNumber { get; set; }
        public string MailID { get; set; }
        public DateTime DateOfBirth { get; set; }


        public BankDetails(string name, GenderDetails gender,long phoneNumber,string mailID, DateTime dob){
            _customerID++;
            CustomerId="HDFC"+_customerID;
            Name=name;
            Gender=gender;
            PhoneNumber=phoneNumber;
            MailID=mailID;
            DateOfBirth=dob;

        }

        public double Deposite(double deposite, double balance){
            balance=deposite+balance;
            return balance;

        }
        public double Withdraw(double withdraw, double balance){
            if(balance-withdraw<0){
                Console.WriteLine("Insufficent Balance");
                return balance;
            }
            balance=balance-withdraw;
            return balance;
        }

    }
}