using System;

namespace CoursesAPI.Services.Entities
{
    /// <summary>
    /// The Course class hold information about a course that will be thought or has been thought.
    /// Every Course is build up on a CourseTemplate that holds static values associated to a given Course.
    /// Like Name and Credits which are found in the CourseTemplate 
    /// </summary>
    public class Course 
    {
        /// <summary>
        /// Database generated auto-incremented identifier.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Name of the CourseTemplate that etch Course class instance is associated with.
        /// <example>
        /// TemplateName: "T-111-PROG"  
        /// TemplateName: "T-514-VEFT"
        /// </example>
        /// </summary>
        public string TemplateName { get; set; }

        /// <summary>
        /// Start-Date represents when a course starts
        /// <example>StartDate: "2016-08-06T10:21:56.761901+00:00"</example>
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End-Date represents when a course ends
        /// <example>EndDate: "2016-12-06T10:21:56.761901+00:00"</example>
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Date-Created represents when the course initiated to the database.
        /// It is unrelated to StartDate and EndDate.
        /// <example>DateCreated: "2016-12-06T10:21:56.761901+00:00"</example>
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The semester tells the time during which the course holds classes.
        /// The form of the value is " year + semester".
        /// Values for "semester" and it's representation can be 1: spring, 2:summer and 3:fall.
        /// <example>Semester: "20151", course holds classes in the  spring 2015</example>
        /// /// </summary>
        public string Semester { get; set; }
    }
}
