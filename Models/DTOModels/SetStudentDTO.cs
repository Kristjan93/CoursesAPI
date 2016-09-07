using System;

namespace CoursesAPI.Models.DTOModels
{
    public class SetStudentDTO
    {
        /// <summary>
        /// Database generated auto-incremented identifier.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// SSN stands for social security number and is used as a query property
        /// for finding a student.
        /// <example>SSN: "2104933449"</example>
        /// </summary>
        public string SSN { get; set; }

        /// <summary>
        /// Simple work-a-round because i don't know how to throw an error.
        /// </summary>
        /// <returns></returns>
        public string HttpAnswer { get; set; }
    }
}
