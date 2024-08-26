using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourse
{
    public class Operations
    {
        public static List<UserDetails> userList = new List<UserDetails>();
        public static List<CourseDetails> courseList = new List<CourseDetails>();
        public static List<EnrollmentDetail> enrollmentList = new List<EnrollmentDetail>();
        public static EnrollmentDetail lastentry;
        public static UserDetails loggedInStudent;
        public static void MainMenu()
        {
            try
            {

                bool flag = true;
                do
                {
                    Console.WriteLine("Enter your option \n 1.User Registration \n 2.User Login \n 3.Exit");
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            {
                                Registraion();
                                break;
                            }
                        case 2:
                            {
                                Login();
                                break;
                            }
                        case 3:
                            {
                                flag = false;
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
        public static void Registraion()
        {
            try
            {
                Console.WriteLine("Enter your name ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter your age");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter your gender");
                GenderDetails gender = Enum.Parse<GenderDetails>(Console.ReadLine());
                Console.WriteLine("Enter your Qualification");
                string qualification = Console.ReadLine();
                Console.WriteLine("Enter ypur Mobile Number");
                long phoneNumber = long.Parse(Console.ReadLine());
                Console.WriteLine("Enter ypur mail ID");
                string mailID = Console.ReadLine();
                UserDetails user = new UserDetails(name, age, gender, qualification, phoneNumber, mailID);
                Console.WriteLine(user.RegistrationID);
                userList.Add(user);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        public static void Login()
        {
            try
            {
                bool flag = true;
                do
                {
                    Console.WriteLine("Enter the user ID");
                    string userID = Console.ReadLine();
                    bool present = true;
                    foreach (UserDetails user in userList)
                    {
                        if (user.RegistrationID == userID)
                        {
                            Console.WriteLine("Login Successfull");
                            present = false;
                            loggedInStudent = user;
                            SubMenu();
                            flag=false;
                            
                        }
                    }
                    if (present)
                    {
                        Console.WriteLine("Invalid User ID");
                    }
                } while (flag);
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
                bool flag = true;
                do
                {
                    Console.WriteLine("Enter your choice \n 1.Enroll Course \n 2.View Enrollment History \n 3.Next Enrollment \n 4.Exit");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                EnrollCourse();
                                break;
                            }
                        case 2:
                            {
                                EnrollmentHistory();
                                break;
                            }
                        case 3:
                            {
                                NextEnrollment();
                                break;
                            }
                        case 4:
                            {
                                flag = false;
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
        public static DateTime date1, date2;
        public static void EnrollCourse()
        {
            try
            {
                foreach (CourseDetails course in courseList)
                {
                    Console.WriteLine($"{course.CourseID}   {course.CourseName}     {course.TrainerName}    {course.CourseDuration}     {course.SeatsAvailable}");
                }
                bool present = true;
                Console.WriteLine("Enter the Course ID");
                string courseID = Console.ReadLine();
                foreach (CourseDetails course in courseList)
                {
                    if (courseID == course.CourseID && course.SeatsAvailable > 0)
                    {
                        present = false;
                        int count = 0;
                        date1 = new DateTime(2001, 10, 03);

                        foreach (EnrollmentDetail enroll in enrollmentList)
                        {
                            if (enroll.RegistrationID == loggedInStudent.RegistrationID)
                            {
                                count++;
                                if (count == 1)
                                    date1 = enroll.EnrollmentDate.AddDays(course.CourseDuration);
                                    

                                if (count == 2)
                                {
                                    date2 = enroll.EnrollmentDate.AddDays(course.CourseDuration);
                                    if (date1 > date2)
                                    {
                                        Console.WriteLine("You have already enrolled in two courses. You can enroll in the next course on "+ date2);
                                    }
                                    else
                                    {
                                        Console.WriteLine("You have already enrolled in two courses. You can enroll in the next course on "+ date1);
                                    }
                                    break;
                                }
                            }
                        }
                        if (count < 2)
                        {
                            //allowed to enroll for the online course
                            course.SeatsAvailable -= 1;
                            EnrollmentDetail enroll = new EnrollmentDetail(course.CourseID, loggedInStudent.RegistrationID, DateTime.Now);
                            Console.WriteLine("You are added successfully");
                            enrollmentList.Add(enroll);
                            lastentry = enroll;
                        }
                        break;
                    }
                }
                if (present)
                {
                    Console.WriteLine("Seats are not available for the current course");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        public static void EnrollmentHistory()
        {
            try
            {
                foreach (EnrollmentDetail enroll in enrollmentList)
                {
                    if (enroll.RegistrationID == loggedInStudent.RegistrationID)
                    {
                        Console.WriteLine($"{enroll.EnrollmentID}   {enroll.CourseID}   {enroll.RegistrationID} {enroll.EnrollmentDate}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        public static void NextEnrollment()
        {
            try
            {
                if (loggedInStudent.RegistrationID == lastentry.RegistrationID)
                {
                    if (date1 > date2)
                    {
                        Console.WriteLine("You can enroll in the next course on "+ date2.AddDays(1));
                    }
                    else
                    {
                        Console.WriteLine("You can enroll in the next course on "+ date1.AddDays(1));
                    }
                }
                else
                {
                    Console.WriteLine("You can enroll in the next course now");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        public static void Default()
        {
            userList.Add(new UserDetails("Ravichandran", 30, GenderDetails.Male, "ME", 9938388333, "ravi@gmail.com"));
            userList.Add(new UserDetails("Priyadharshini", 25, GenderDetails.Female, "BE", 9944444455, "priya@gmail.com"));

            courseList.Add(new CourseDetails("C#", "Baskaran", 5, 0));
            courseList.Add(new CourseDetails("HTML", "Ravi", 2, 5));
            courseList.Add(new CourseDetails("CSS", "Priyadharshini", 3, 3));
            courseList.Add(new CourseDetails("JS", "Baskaran", 3, 1));
            courseList.Add(new CourseDetails("TS", "Ravi", 1, 2));

            enrollmentList.Add(new EnrollmentDetail("CS2001", "SYNC1001",DateTime.ParseExact("28/01/2024","dd/MM/yyyy",null)) );
            enrollmentList.Add(new EnrollmentDetail("CS2003", "SYNC1001", DateTime.ParseExact("15/02/2024","dd/MM/yyyy",null)));
            enrollmentList.Add(new EnrollmentDetail("CS2004", "SYNC1002", DateTime.ParseExact("18/02/2024","dd/MM/yyyy",null)));
            enrollmentList.Add(new EnrollmentDetail("CS2002", "SYNC1002", DateTime.ParseExact("20/02/2024","dd/MM/yyyy",null)));


        }
    }
}



