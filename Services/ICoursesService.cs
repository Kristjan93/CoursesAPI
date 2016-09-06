using System;
using System.Collections.Generic;

using CoursesAPI.Models.ViewModels;
using CoursesAPI.Models.DTOModels;

namespace CoursesAPI.Services
{
    public interface ICoursesService
    {
        List<CourseLiteDTO> GetCoursesBySemester(string semester);

        CourseDetailsDTO GetCourseById(int id);

        CreatedCourseDTO CreateCourse(CreateCourseViewModel creCourse);

        bool modifyCourse(int id, modifyCourseViewModel course);

        bool deleteCourse(int id);
    }
}
