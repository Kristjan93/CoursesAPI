using System;
using System.Linq;
using System.Collections.Generic;

using CoursesAPI.Models;

namespace CoursesAPI.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly AppDataContext _db;

        public CoursesService(AppDataContext db)
        {
            _db = db;
        }

        // TODO but it should include the number of students 
        public List<CourseLiteDTO> GetCoursesBySemester(string semester)
        {
            if(semester == null)
            {
                semester = "20163";
            }

            var courses = (from c in _db.Courses
                join ct in _db.CourseTemplates on c.CourseID  equals ct.CourseID
                where c.Semester == semester
                orderby ct.Name
                select new CourseLiteDTO 
                {
                    ID = c.ID,
                    Name = ct.Name,
                    Semester = c.Semester
                }).ToList();
                
                // Incase we don't find a course we return null instead of an empty list 
                if(!courses.Any())
                {
                    return null;
                }
                
                return courses;
        }
    }
}
