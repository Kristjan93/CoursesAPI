using System;

namespace CoursesAPI.Services.Entities
{
    /// <summary>
    /// This class represents general information for an enrolled student.
    /// </summary>
    public class Student 
    {
        /// <summary>
        /// Database generated auto-incremented identifier.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// SSN stands for social security number and is used throughout the API
        /// as an identifier in query statements.
        /// <example>SSN: "2104933449"</example>
        /// </summary>
        public string SSN { get; set; }

        /// <summary>
        /// Name represents the full name of a student.  
        /// <example>Name: "Jón Jónsson"</example>
        /// </summary>
        public string Name { get; set; }
    }
}
