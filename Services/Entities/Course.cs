using System;

namespace CoursesAPI.Services.Entities
{
    public class Course 
    {
        public int ID { get; set; }

        public string CourseID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Semester { get; set; }
    }
}
