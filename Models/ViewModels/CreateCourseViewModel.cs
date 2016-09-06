using System;

namespace CoursesAPI.Models.ViewModels
{
    public class CreateCourseViewModel
    {
        public string CourseID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        
        public string Semester { get; set; }
    }
}
