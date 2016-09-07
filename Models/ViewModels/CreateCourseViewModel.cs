using System;

namespace CoursesAPI.Models.ViewModels
{
    public class CreateCourseViewModel
    {
        /// <summary>
        /// Name of the CourseTemplate.
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
        /// The semester tells the time during which the course holds classes.
        /// The form of the value is " year + semester".
        /// Values for "semester" and it's representation can be 1: spring, 2:summer and 3:fall.
        /// <example>
        /// Semester: "20151", course holds classes in the  spring 2015
        /// </example>
        /// /// </summary>
        public string Semester { get; set; }
    }
}
