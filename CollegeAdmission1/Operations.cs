using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission1
{
    public static class Operations
    {
        public static List<StudentDetails> studentList = new List<StudentDetails>();
        public static List<DepartmentDetails> departmentList = new List<DepartmentDetails>();
        public static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();
        static StudentDetails loggedInStudent;
        public static void MainMenu()
        {
            try
            {
                bool choice = true;
                do
                {
                    Console.WriteLine("Enter your choice \n 1.Student Registration \n 2.Student Login \n 3.Department wise seat availability \n 4.Exit");
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            {
                                Registration();
                                break;
                            }
                        case 2:
                            {
                                Login();
                                break;
                            }
                        case 3:
                            {
                               SeatAvailability();
                               break;
                            }
                        case 4:
                            {
                                choice=false;
                                break;
                            }
                    }
                } while (choice);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        public static void SeatAvailability(){
            try{
                foreach(DepartmentDetails department in departmentList){
                    Console.WriteLine($"{department.DepartmentName}   {department.NumberOfSeats}");
                }
            }catch(Exception ex){
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static void Registration()
        {
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your father name");
            string fatherName = Console.ReadLine();
            Console.WriteLine("Enter you dob");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.WriteLine("Emter your Gender");
            GenderDetails gender = Enum.Parse<GenderDetails>(Console.ReadLine(), true);
            Console.WriteLine("Enter the Physics Mark");
            int physics = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Chemistry Mark");
            int chemistry = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Maths Mark");
            int maths = int.Parse(Console.ReadLine());
            StudentDetails student = new StudentDetails(name, fatherName, gender, dob, physics, chemistry, maths);
            studentList.Add(student);
            Console.WriteLine("Student Registered Successfully and StudentID is " + student.StudentID);

        }
        public static void Login()
        {
            try
            {
                Console.WriteLine("Enter the Student ID");
                string studentID = Console.ReadLine();
                bool present = true;
                foreach (StudentDetails student in studentList)
                {
                    if (student.StudentID == studentID)
                    {
                        present = false;
                        Console.WriteLine("Login Succesful");
                        loggedInStudent = student;
                        SubMenu();

                    }
                }
                if (present)
                {
                    Console.WriteLine("Not Valid");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

        }
        public static void SubMenu()
        {
            try
            {
                bool choiceFlag = true;
                do
                {
                    Console.WriteLine("Enter the choice \n 1.Check Eligibility \n 2.Show Details \n 3.Take Admission \n 4.Cancel Admission \n 5.Show Admission Details \n 6.Exit");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                               if(loggedInStudent.IsEligible(75.0)){
                                Console.WriteLine("Student is Eligible");
                               }
                               else{
                                Console.WriteLine("Student is not eligible");
                               }
                               break;
                            }
                        case 2:
                            {
                                Console.WriteLine($"{loggedInStudent.StudentID} \n {loggedInStudent.StudentName} \n {loggedInStudent.FatherName} \n {loggedInStudent.DOB} \n {loggedInStudent.Gender} \n {loggedInStudent.Physics} \n {loggedInStudent.Chemistry} \n {loggedInStudent.Maths}");
                                break;
                            }
                        case 3:
                            {
                                TakeAdmission();
                                break;
                            }
                        case 4:
                            {
                                CancelAdmission();
                                break;
                            }
                        case 5:
                            {
                                ShowAdmission();
                                break;

                            }
                        case 6:
                            {
                                choiceFlag=false;
                                break;
                            }
                    }
                } while (choiceFlag);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        public static void TakeAdmission()
        {
            try{
                foreach(DepartmentDetails department in departmentList){
                    if(department.NumberOfSeats>=1){
                    Console.WriteLine(department.DepartmentID+"     "+ department.DepartmentName+"       "+department.NumberOfSeats);
                    }
                }
                Console.WriteLine("Choose anyone department ID");
                string departmentID=Console.ReadLine();
                bool departmentFlag=true;
                foreach(DepartmentDetails department in departmentList)
                {
                    if(departmentID== department.DepartmentID){
                        departmentFlag=false;
                        double average=loggedInStudent.Average();
                        if(loggedInStudent.IsEligible(average)){
                            if(department.NumberOfSeats>=1){
                                int flag=0;

                                foreach(AdmissionDetails admission in admissionList){
                                    if(loggedInStudent.StudentID==admission.StudentID){
                                        flag=1;
                                        break;
                                    }

                                }
                                if(flag==1){
                                    Console.WriteLine("You have already taken a admission");
                                }
                                else{
                                    department.NumberOfSeats-=1;
                                    AdmissionDetails newAdmission= new AdmissionDetails(loggedInStudent.StudentID,department.DepartmentID,DateTime.Now,AdmissionStatusDetails.Booked);
                                    admissionList.Add(newAdmission);
                                    Console.WriteLine("Admission took successfully. Your admission ID - "+newAdmission.AdmissionID);
                                }
                            }
                            else{
                                Console.WriteLine("Seats not available");
                            }
                        }
                        else{
                            Console.WriteLine("You are not elligible");
                        }
                    }
                }
                if(departmentFlag){
                    Console.WriteLine("Invalid");
                }
            }catch(Exception ex){
                Console.WriteLine(ex.StackTrace);
            }
        
        }
        public static void CancelAdmission(){
            try{
                bool admissionFlag=true;
                foreach(AdmissionDetails admission in admissionList){
                    if(admission.StudentID.ToUpper()==loggedInStudent.StudentID&& admission.AdmissionStatus.ToString()=="Booked"){
                        admission.AdmissionStatus=AdmissionStatusDetails.Cancelled;
                        foreach(DepartmentDetails department in departmentList){
                            if(department.DepartmentID==admission.DepartmentID){
                                department.NumberOfSeats+=1;
                                Console.WriteLine("admission Cancelled Successfully");
                            }
                        }
                        break;
                    }
                }
                if(admissionFlag){
                    Console.WriteLine("you have not been admitted");
                }
            }catch(Exception ex){
                Console.WriteLine(ex.StackTrace);
            }
        }
        public static void ShowAdmission(){
            try{
                bool flag=true;
                foreach(AdmissionDetails admission in admissionList){
                    if(loggedInStudent.StudentID==admission.StudentID){
                        flag=false;
                        Console.WriteLine($"{admission.AdmissionID}  {admission.StudentID}    {admission.DepartmentID}    {admission.AdmissionDate}     {admission.AdmissionStatus}");
                    break;
                    }
                }
                if(flag){
                    Console.WriteLine("your detail is not present in the list");
                }
            }catch(Exception ex){
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static void Default()
        {
            try{
                studentList.Add(new StudentDetails("Ravichandran E","Ettapparajan" , GenderDetails.Male, new DateTime(11/11/1999) ,95,95, 95));
                studentList.Add(new StudentDetails("Baskaran S","Sethurajan",GenderDetails.Male,new DateTime(11/11/1999),95,95,95));

                departmentList.Add(new DepartmentDetails("EEE",29));
                departmentList.Add(new DepartmentDetails("CSE",29));
                departmentList.Add(new DepartmentDetails("MECH",30));
                departmentList.Add(new DepartmentDetails("ECE",30));
                
                admissionList.Add(new AdmissionDetails("SF3001","DID101",new DateTime(11/05/2022),	AdmissionStatusDetails.Booked));
                admissionList.Add(new AdmissionDetails("SF3002","DID102" ,new DateTime(12/05/2022), AdmissionStatusDetails.Booked));

            }catch(Exception ex){
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}