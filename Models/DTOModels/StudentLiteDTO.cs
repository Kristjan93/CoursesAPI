using System;

namespace CoursesAPI.Models.DTOModels
{
    public class StudentLiteDTO 
    {
        /// <summary>
        /// Database generated auto-incremented identifier.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Name of the course.
        /// </summary>
        public string Name { get; set; }
    }
}
