using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce
{
    public class CustomerDetails
    {
        static int s_CustomerID=1000;
        public string CustomerID { get; }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public long PhoneNumber { get; set; }
        private double _walletBalance;
        public double WalletBalance { get{ return _walletBalance;} }
        public string MailID { get; set; }

        public CustomerDetails(string name, string city, long phoneNumber, double walletBalance,string mailID){
            s_CustomerID++;
            CustomerID="CID"+s_CustomerID;
            CustomerName=name;
            City=city;
            PhoneNumber=phoneNumber;
            _walletBalance=walletBalance;
            MailID=mailID;
        }

        public void WalletRecharge(double amount){
            _walletBalance+=amount;
        }

        public void DeductBalance(double amount){
            _walletBalance-=amount;
        }






    }
}