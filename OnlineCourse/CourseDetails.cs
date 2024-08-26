using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourse
{
    public class CourseDetails
    {
        public static int s_courseID=2000;
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public string TrainerName { get; set; }
        public int CourseDuration { get; set; }
        public int SeatsAvailable { get; set; }

        public CourseDetails(string name, string trainerName, int duration, int seatsAvailable){
            s_courseID++;
            CourseID="CS"+s_courseID;
            CourseName=name;
            TrainerName=trainerName;
            CourseDuration=duration;
            SeatsAvailable=seatsAvailable;
            
        }
    }
}