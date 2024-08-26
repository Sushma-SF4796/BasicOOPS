using System;
using System.Collections.Generic;
namespace EBBill;
public class Program{
    public static void Main(string [] args){
        List<EBDetails> ebList= new List<EBDetails>();
        EBDetails eb;
        bool choice=true;
        do{
            Console.WriteLine("1.Register");
            Console.WriteLine("2.Login");
            Console.WriteLine("3.Exit");
            Console.WriteLine("ENTER YOUR CHOICE");
            int ch=int.Parse(Console.ReadLine());
            switch(ch){
                case 1:
                {
                    Console.WriteLine("Enter your name");
                    string name=Console.ReadLine();
                    Console.WriteLine("Enter your phone number");
                    long phoneNumber=long.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the mail id");
                    string mail=Console.ReadLine();
                    eb=new EBDetails(name,phoneNumber,mail,0);
                    ebList.Add(eb);
                    Console.WriteLine("Meter ID : "+eb.MeterID);
                    break;
                }
                case 2:
                {
                    bool ch1=true;
                    do{
                    Console.WriteLine("Enter the meter ID");
                    string str=Console.ReadLine();
                    bool z=true;
                    foreach(EBDetails eb1 in ebList){
                        if(eb1.MeterID==str){
                            z=false;
                            Console.WriteLine("1.Calculate Amount");
                            Console.WriteLine("2.Display user detail");
                            Console.WriteLine("3.Exit");
                            Console.WriteLine("Enter your choice");
                            int choice1=int.Parse(Console.ReadLine());
                            switch(choice1){
                                case 1:
                                {
                                    Console.WriteLine("Enter the units");
                                    int unit=int.Parse(Console.ReadLine());
                                    double bill=eb1.PayAmount(unit);
                                    Console.WriteLine("Meter Id : "+eb1.MeterID);
                                    Console.WriteLine("Name : "+eb1.Name);
                                    Console.WriteLine("Unit : "+unit);
                                    Console.WriteLine("Amount : "+eb1.PayAmount(unit));
                                    break;
                                }
                                case 2:
                                {
                                    Console.WriteLine("Meter Id : "+eb1.MeterID);
                                    Console.WriteLine("Name : "+eb1.Name);
                                    Console.WriteLine("Phone Number : "+eb1.PhoneNumber);
                                    Console.WriteLine("Mail ID : "+eb1.MailID);
                                    break;
                                }
                                case 3:
                                {
                                    ch1=false;
                                    break;
                                }
                            }

                        }
                    }
                    if(z){
                        Console.WriteLine("User Invalid ID");
                    }
                    }while(ch1);
                    break;
                }
                case 3: {
                    choice= false;
                    break;
                }
                
            }
        }while(choice);
    }
}