using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBBill
{
    public class EBDetails
    {
        private static int _id=1000;
        public string MeterID { get; set; }
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string MailID { get; set; }
        public int Unit { get; set; }

        public EBDetails(string name, long phoneNumber, string mailID, int unit){
            _id++;
            MeterID="EB"+_id;
            Name=name;
            PhoneNumber=phoneNumber;
            MailID=mailID;
            Unit=unit;
        }

        public double PayAmount(int unit){
            if(unit<100){
                return unit;
            }
            else if(unit<200){
                return 100+(unit-100)*2.5;
            }
            else if(unit<400){
                return 100+(100*2.5)+(unit-200)*5;
            }
            else if(unit<500){
                return 100+(100*2.5)+(200*5)+(unit-400)*9;
            }
            else{
                return 100+(100*2.5)+(200*5)+(100*9)+(unit-500)*10;
            }
        }
    }
}