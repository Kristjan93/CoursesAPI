using System;

namespace CoursesAPI.Services.Entities
{
    /// <summary>
    /// CourseStudent connects a course to the students enrolled in it.
    /// </summary>
    public class CourseStudent 
    {
        /// <summary>
        /// Database generated auto-incremented identifier.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// CourseID represents a course. 
        /// </summary>
        public int CourseID { get; set; }

        /// <summary>
        /// StudentsID represents student enrolled in a course.
        /// </summary>
        public int StudentID { get; set; }
    }
}
