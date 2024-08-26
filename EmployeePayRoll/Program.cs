using System;
using System.Collections.Generic;
namespace EmployeePayRoll;
public class Program{
    public static void Main(string [] args){
        bool choice=true;
        EmployeeDetails emp;
        List<EmployeeDetails> list=new List<EmployeeDetails>();
        do{
            Console.WriteLine("1.Registration");
            Console.WriteLine("2.Login");
            Console.WriteLine("3.Exit");
            Console.WriteLine("ENTER YOUR CHOICE");
            int option=int.Parse(Console.ReadLine());
            switch(option){
                case 1:
                {
                    Console.WriteLine("Enter your name");
                    string name=Console.ReadLine();
                    Console.WriteLine("Enter your designation");
                    string role=Console.ReadLine();
                    Console.WriteLine("Enter the work location");
                    WorkLocationDetails workLocation= Enum.Parse<WorkLocationDetails>(Console.ReadLine(), true);
                    Console.WriteLine("Enter your team name");
                    string teamName=Console.ReadLine();
                    Console.WriteLine("Enter the joing date");
                    DateTime joiningDate=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                    Console.WriteLine("Enter the number of leaves taken");
                    int leavesTaken=int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter your gender");
                    GenderDetails gender= Enum.Parse<GenderDetails>(Console.ReadLine(),true);
                    Console.WriteLine("Enter the number of working days");
                    int workingDays=int.Parse(Console.ReadLine());

                    emp=new EmployeeDetails(name,role,workLocation, teamName, joiningDate, leavesTaken,gender, workingDays);
                    Console.WriteLine(emp.EmployeeID);
                    list.Add(emp);
                    break;
                }
                case 2:
                {
                    Console.WriteLine("Enter your EmployeeId");
                    string employeeId=Console.ReadLine();
                    bool flag=true;
                    foreach(EmployeeDetails emp1 in list){
                        if(emp1.EmployeeID==employeeId){
                            
                            flag=false;
                             bool stop1= true;
                    do{
                        Console.WriteLine("1.Calculate the salary");
                        Console.WriteLine("2.Display Details");
                        Console.WriteLine("3.Exit");
                        Console.WriteLine("Enter your choice");
                        int ch=int.Parse(Console.ReadLine());
                        switch(ch){
                            case 1:
                            {
                                Console.WriteLine(emp1.salary(emp1.WorkingDays, emp1.LeavesTaken));
                                break;
                            }
                            case 2:
                            {
                                Console.WriteLine("Name : "+emp1.Name);
                                Console.WriteLine("Employee ID : "+emp1.EmployeeID);
                                Console.WriteLine("Role : "+emp1.Role);
                                Console.WriteLine("Work Location : "+emp1.WorkLocation);
                                Console.WriteLine("Team Name : "+emp1.TeamName);
                                Console.WriteLine("Joining Date : "+emp1.JoiningDate);
                                Console.WriteLine("Leaves Taken : "+emp1.LeavesTaken);
                                Console.WriteLine("Gender : "+emp1.Gender);
                                Console.WriteLine("Number of working days : "+emp1.WorkingDays);
                                break;
                            }
                            case 3:
                            {
                                stop1=false;
                                break;
                            }
                            default:
                            {
                                Console.WriteLine("Invalid");
                                break;
                            }
                        }
                    }while(stop1);
                        }
                    }
                    if(flag){
                        Console.WriteLine("User Invalid ID");
                    }
                    break;
                   
                }
                case 3:
                {
                    choice=false;
                    break;
                }
            }
        }while(choice);
    }
}