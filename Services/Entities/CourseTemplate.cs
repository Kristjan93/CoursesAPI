using System;
using System.Collections.Generic;

namespace CoursesAPI.Services.Entities
{
    public class CourseTemplate
    {
        /// <summary>
        /// Database generated auto-incremented identifier.
        /// </summary>
        public int ID { get; set; }
        
        /// <summary>
        /// Name of the CourseTemplate.
        /// <example>
        /// TemplateName: "T-111-PROG"  
        /// TemplateName: "T-514-VEFT"
        /// </example>
        /// </summary>
        public string TemplateName { get; set; }  

        /// <summary>
        /// CourseName represent names of courses associated with each courses instance.
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// Credits is a numeric value representing how many points a course will give
        /// when passed.
        /// <example>
        /// Credits: 6
        /// Credits: 12
        /// </example>
        /// </summary>
        public int Credits { get; set; } 
    }
}
