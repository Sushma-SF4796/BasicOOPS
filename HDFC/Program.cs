using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace HDFC
{
    public class Program
    {
        static double balance;
        public static void Main(string[] args)
        {
            int option;
            bool opt=true;
            BankDetails hdfc;
            List<BankDetails> customerList = new List<BankDetails>();
            do
            {
                Console.WriteLine("1.Registration");
                Console.WriteLine("2.Login");
                Console.WriteLine("3.Exit");
                Console.WriteLine("ENTER THE OPTION");
                option = int.Parse(Console.ReadLine());
                
                    switch (option)
                    {
                        case 1:
                        {
                            Console.WriteLine("ENTER YOUR NAME");
                            string name = Console.ReadLine();
                            Console.WriteLine("ENTER YOUR GENDER");
                            GenderDetails gender = Enum.Parse<GenderDetails>(Console.ReadLine(), true);
                            Console.WriteLine("ENTER THE PHONE NUMBER");
                            long phoneNumber = long.Parse(Console.ReadLine());
                            Console.WriteLine("ENTER THE MAIL ID");
                            string mailId = Console.ReadLine();
                            Console.WriteLine("ENTER YOUR DATE OF BIRTH");
                            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                            hdfc = new BankDetails(name, gender, phoneNumber, mailId, dob);
                            Console.WriteLine(hdfc.CustomerId);
                            customerList.Add(hdfc);
                            break;


                        }
                        case 2:
                        {
                            Console.WriteLine("ENTER THE CUSTOMER ID");
                            string id = Console.ReadLine();
                            bool present = true;
                            foreach (BankDetails hdfc1 in customerList)
                            {
                                if (hdfc1.CustomerId == id)
                                {
                                    present =false;
                                    bool stop = true;
                                    do
                                    {
                                    Console.WriteLine("1.Deposite");
                                    Console.WriteLine("2.Withdraw");
                                    Console.WriteLine("3.Balance Check");
                                    Console.WriteLine("4.Exit");
                                    Console.WriteLine("ENTER YOUR CHOICE");
                                    int choice = int.Parse(Console.ReadLine());
                                    
                                    
                                        switch (choice)
                                        {
                                            case 1:
                                                {
                                                    double bal = hdfc1.Balance;
                                                    Console.WriteLine("ENTER THE AMOUNT TO BE DEPOSITED");
                                                    double deposite = double.Parse(Console.ReadLine());
                                                    balance = hdfc1.Deposite(deposite, bal);
                                                    Console.WriteLine(balance);
                                                    break;

                                                }
                                            case 2:
                                                {

                                                    Console.WriteLine("ENTER THE AMOUNT TO WITHDRAW");
                                                    double withdraw = double.Parse(Console.ReadLine());
                                                    if (balance - withdraw <= 0)
                                                    {
                                                        Console.WriteLine("Insufficient Balance");
                                                    }
                                                    else
                                                    {
                                                        balance = hdfc1.Withdraw(withdraw, balance);
                                                        Console.WriteLine(balance);
                                                    }
                                                    break;
                                                }
                                            case 3:
                                                {
                                                    Console.WriteLine(balance);
                                                    break;
                                                }
                                            case 4:
                                                {
                                                    stop = false;
                                                    break;
                                                }
                                        }
                                    } while (stop);
                                }
                            }
                            if (present)
                                Console.WriteLine("Invalid UserId");
                            break;
                        }
                        case 3:
                        {
                            opt=false;
                            break;
                        }
                    

                    
                }
            } while (opt);

        }
    }
}
