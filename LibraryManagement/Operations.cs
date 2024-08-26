using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public static class Operations
    {
        public static List<UserDetails> userList = new List<UserDetails>();
        public static List<BookDetails> bookList = new List<BookDetails>();
        public static List<BorrowDetails> borrowList = new List<BorrowDetails>();
        public static UserDetails loggedInStudent;
        public static void MainMenu()
        {
            try
            {
                bool flag = true;
                do
                {
                    Console.WriteLine("Enter your choice \n 1.User Registration \n 2.User Login \n 3.Exit");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                //User Registration
                                Registration();
                                break;
                            }
                        case 2:
                            {
                                //User Login
                                Login();
                                break;

                        }
                        case 3:
                            {
                                flag=false;
                                break;
                            }
                    }
                } while (flag);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        public static void Registration()
        {
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your gender");
            GenderDetails gender = Enum.Parse<GenderDetails>(Console.ReadLine(), true);
            Console.WriteLine("Enter your department");
            DepartmentDetails department = Enum.Parse<DepartmentDetails>(Console.ReadLine());
            Console.WriteLine("Enter your mobile number");
            long phoneNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your mail ID");
            string mailID = Console.ReadLine();
            Console.WriteLine("Enter your wallet balance");
            double walletBalance = double.Parse(Console.ReadLine());
            UserDetails user = new UserDetails(name, gender, department, phoneNumber, mailID, walletBalance);
            userList.Add(user);
            Console.WriteLine("User ID : " + user.UserID);
        }
        public static void Login()
        {
            try
            {
                
                Console.WriteLine("Enter your user ID");
                string userID = Console.ReadLine().ToUpper();


                bool present = true;
                foreach (UserDetails user in userList)
                {
                    if (user.UserID == userID)
                    {
                        loggedInStudent=user;
                        present = false;
                        Console.WriteLine("Logged In Successfully");
                        SubMenu();
                        
                        break;

                    }

                }
                if (present)
                {
                    Console.WriteLine("Invalid User ID. Please enter a valid one");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        public static void SubMenu(){
            try{
                bool flag=true;
                do
                        {
                            Console.WriteLine("Enter the choice \n 1.Borrow book \n 2.Show Borrowed history \n 3.ReturnBooks \n 4.WalletRecharge \n 5.Exit");
                            int choice = int.Parse(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    {
                                        //Borrow Book
                                        BorrowBook();
                                        break;
                                    }
                                    case 2 : 
                                    {
                                        ShowBorrowHistory();
                                        break;
                                    }
                                    case 3:
                                    {
                                        ReturnBook();
                                        break;
                                    }
                                    case 4:
                                    {
                                        WalletRecharge();
                                        break;
                                    }
                                
                                case 5:
                                    {
                                        flag = false;
                                        break;
                                    }
                            }

                        } while (flag);
            }catch(Exception ex){
                Console.WriteLine(ex.StackTrace);
            }
        }
        public static void ReturnBook(){
            try{
            foreach(BorrowDetails borrow in borrowList ){


                
            }
                    
                    
            }
            catch(Exception ex){
                Console.WriteLine(ex.StackTrace);
            }
        }
        public static void WalletRecharge(){
            Console.WriteLine("Do you wish to recharge the wallet");
            string option=Console.ReadLine().ToLower();
            if(option=="yes"){
                Console.WriteLine("Enter the amount to be recharged");
                double amount=double.Parse(Console.ReadLine());
                loggedInStudent.WalletRecharge(amount);
                Console.WriteLine("Updated amount : "+loggedInStudent.WalletBalance);
            }
            
        }
       
       public static void BorrowBook(){
        foreach(BookDetails book in bookList){
            Console.WriteLine($"{book.BookID}   {book.BookName} {book.AuthorName}   {book.BookCount}");
        }
        Console.WriteLine("Enter Book ID to borrow");
        string bookID=Console.ReadLine().ToUpper();
        bool isAvailable=true;
        foreach(BookDetails book in bookList){
            if(book.BookID==bookID){
                isAvailable=false;
                Console.WriteLine("Enter the count of the book");
                int bookCount=int.Parse(Console.ReadLine());
                int count=0;
                int borrowedBookCount=0;
                if(bookCount<=book.BookCount){
                    foreach(BorrowDetails borrow in borrowList){
                        if(loggedInStudent.UserID==borrow.UserID){
                            count++;
                            borrowedBookCount+=borrow.BorrowedBookCount;
                        }
                    }
                    if(count==3){
                        Console.WriteLine("You have borrowed 3 books already");
                    }
                    else if(borrowedBookCount>3 && bookCount>3)
                    {
                        Console.WriteLine($"You can have maximum of 3 borrowed books. Your already borrowed books count is {borrowedBookCount} and requested count is {bookCount}, which exceeds 3");
                    }
                    else{
                        book.BookCount-=bookCount;
                        BorrowDetails newBorrow =new BorrowDetails(book.BookID,loggedInStudent.UserID,DateTime.Now,bookCount,StatusDetails.Borrowed,0);
                        borrowList.Add(newBorrow);
                        Console.WriteLine("Borrowed Successfully");
                    }
                }
                else{
                    Console.WriteLine("Books are not available for the selected count");
                    foreach(BorrowDetails borrow in borrowList){
                        if(book.BookID==borrow.BookID){
                            Console.WriteLine("The book will be available on "+borrow.BorrowedDate.AddDays(15));
                        }
                    }
                }
                break;
            }
        }
        if(isAvailable){
            Console.WriteLine("Invalid Book ID, Please enter valid ID");
            BorrowBook();
        }
       }
      public static void  ShowBorrowHistory(){
        try{
            foreach(BorrowDetails borrow in borrowList){
                if(loggedInStudent.UserID==borrow.UserID){
                    Console.WriteLine($"{borrow.BorrowID}   {borrow.BookID}     {borrow.UserID}     {borrow.BorrowedDate}      {borrow.BorrowedBookCount}   {borrow.Status} {borrow.PaidFineAmount}");
                }
            }
        }catch(Exception ex){
            Console.WriteLine(ex.StackTrace);
        }
      }
        public static void Default()
        {
            try
            {
                userList.Add(new UserDetails("Ravichandran", GenderDetails.Male, DepartmentDetails.EEE, 9938388333, "ravi@gmail.com", 100));
                userList.Add(new UserDetails("Priyadharshini", GenderDetails.Female, DepartmentDetails.CSE, 9944444455, "priya@gmail.com", 150));

                bookList.Add(new BookDetails("C#", "Author1", 3));
                bookList.Add(new BookDetails("HTML", "Author2", 5));
                bookList.Add(new BookDetails("CSS", "Author1", 3));
                bookList.Add(new BookDetails("JS", "Author1", 3));
                bookList.Add(new BookDetails("TS", "Author2", 2));

                borrowList.Add(new BorrowDetails("BID1001", "SF3001", new DateTime(10 / 09 / 2023), 2, StatusDetails.Borrowed, 0.0));
                borrowList.Add(new BorrowDetails("BID1003", "SF3001", new DateTime(12 / 09 / 2023), 1, StatusDetails.Borrowed, 0));
                borrowList.Add(new BorrowDetails("BID1004", "SF3001", new DateTime(14 / 09 / 2023), 1, StatusDetails.Returned, 16));
                borrowList.Add(new BorrowDetails("BID1002", "SF3002", new DateTime(11 / 09 / 2023), 2, StatusDetails.Borrowed, 0));
                borrowList.Add(new BorrowDetails("BID1005", "SF3002", new DateTime(09 / 09 / 2023), 1, StatusDetails.Returned, 20));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            /*foreach(UserDetails user in userList){
                Console.WriteLine($"{user.UserID}     {user.Gender}     {user.Department}        {user.PhoneNumber}     {user.MailID}     {user.WalletBalance}");
            }
            Console.WriteLine();
            foreach(BookDetails book in bookList){
                Console.WriteLine($"{book.BookID}   {book.BookName} {book.AuthorName}   {book.BookCount}");
            }
             Console.WriteLine();
             foreach(BorrowDetails borrow in borrowList){
                Console.WriteLine($"{borrow.BorrowID}   {borrow.BookID} {borrow.UserID} {borrow.BorrowedDate}   {borrow.BorrowedBookCount}  {borrow.Status} {borrow.PaidFineAmount}");
             }*/
        }
    }
}



/*try{

        }catch(Exception ex){
            Console.WriteLine(ex.StackTrace);
        }*/