using System;

namespace CoursesAPI.Models.DTOModels
{
    public class CreatedCourseDTO
    {
        public int ID { get; set; }
        
        public string CourseID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        
        public string Semester { get; set; }
    }
}
