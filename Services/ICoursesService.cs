using System;
using System.Collections.Generic;

using CoursesAPI.Models;

namespace CoursesAPI.Services
{
    public interface ICoursesService
    {
        List<CourseLiteDTO> GetCoursesBySemester(string semester);
        //TODO add more...
    }
}
