using System;

namespace CoursesAPI.Models.ViewModels
{
    /// <summary>
    /// SetStudentViewModel is used when enrolling a student to a course.
    /// </summary>
    public class SetStudentViewModel
    {
        /// <summary>
        /// SSN stands for social security number and is used as a query property
        /// for finding a student.
        /// <example>SSN: "2104933449"</example>
        /// </summary>
        public string SSN { get; set; }
    }
}
