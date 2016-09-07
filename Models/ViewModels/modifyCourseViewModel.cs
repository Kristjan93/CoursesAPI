using System;

namespace CoursesAPI.Models.ViewModels
{
    /// <summary>
    /// When modifying a course we only give the user the option to change the StartDate and EndDate.
    /// </summary>
    public class modifyCourseViewModel
    {
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
    }
}
