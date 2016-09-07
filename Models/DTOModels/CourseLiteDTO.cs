using System;

namespace CoursesAPI.Models.DTOModels
{
    public class CourseLiteDTO
    {
        /// <summary>
        /// Database-genarated ID of the course.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The Name of the course.
        /// Example: "Web services"
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The semester tells the time during which the course holds classes.
        /// The form of the value is " year + semester".
        /// Values for "semester" and it's representation can be 1: spring, 2:summer and 3:fall.
        /// <example>Semester: "20151", course holds classes in the  spring 2015</example>
        /// /// </summary>
        public string Semester { get; set; }

        /// <summary>
        /// NumberOfStudents stores how many students are enrolled in a course.
        /// </summary>
        /// <returns></returns>
        public int NumberOfStudents { get; set; }
    }
}
