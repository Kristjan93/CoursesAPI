using System;

namespace CoursesAPI.Models.DTOModels
{
    public class CourseDetailsDTO
    {
        /// <summary>
        /// Database-genarated ID of the course.
        /// </summary>
        public int ID { get; set; }

        public string CourseID { get; set; }

        /// <summary>
        /// The Name of the course.
        /// Example: "Web services"
        /// </summary>
        public string Name { get; set; }
        public int Credits { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        /// <summary>
        /// The semester tells the time during which the course holds classes.
        /// The form of the value is " year + semester".
        /// Values for "semester" and it's representation can be 1: spring, 2:summer and 3:fall.
        /// Example: "20151": course holds classes in the  spring 2015
        /// /// </summary>
        public string Semester { get; set; }
        
    }
}
