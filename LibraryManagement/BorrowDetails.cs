using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class BorrowDetails
    {
        static int s_borrowID=2000;
        public string BorrowID { get; }
        public string BookID { get; set; }
        public string UserID { get; set; }
        public DateTime BorrowedDate { get; set; }
        public int BorrowedBookCount { get; set; } 
        public StatusDetails Status { get; set; }
        public double PaidFineAmount { get; set; }

        public BorrowDetails(string bookID,string userId, DateTime borrowedDate, int bookCount, StatusDetails status,double fineAmount){
            s_borrowID++;
            BorrowID="LB"+s_borrowID;
            BookID=bookID;
            UserID=userId;
            BorrowedDate=borrowedDate;
            BorrowedBookCount=bookCount;
            Status=status;
            PaidFineAmount=fineAmount;
        }
    }
}