using System;
using System.Linq;
using System.Collections.Generic;

using CoursesAPI.Models.ViewModels;
using CoursesAPI.Models.DTOModels;
using CoursesAPI.Services.Entities;

namespace CoursesAPI.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly AppDataContext _db;

        public CoursesService(AppDataContext db)
        {
            _db = db;
        }

        // Create Method
        // TODO Students = []
        // TODO use user's input
        public CreatedCourseDTO CreateCourse(CreateCourseViewModel course) 
        {
            var creCourse = new Course 
            {
                CourseID = course.CourseID,
                StartDate = DateTime.Now.AddMonths(1),
                EndDate = DateTime.Now.AddMonths(5),
                DateCreated = DateTime.Now,
                Semester = course.Semester
            };

            _db.Courses.Add(creCourse);
            _db.SaveChanges();

            return new CreatedCourseDTO
            {
                ID = creCourse.ID,
                CourseID = creCourse.CourseID,
                StartDate = creCourse.StartDate,
                EndDate = creCourse.EndDate,
                Semester = creCourse.Semester
            };  
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
                    //StudentsCount = c.Students(count) 
                }).ToList();
                
                // Incase we don't find a course we return null instead of an empty list 
                if(!courses.Any())
                {
                    return null;
                }
                
                return courses;
        }

        // TODO but it should include list of students
        // TODO StudentsCount = c.Students(count)
        public CourseDetailsDTO GetCourseById(int id)
        {
            var course = (from c in _db.Courses
                join ct in _db.CourseTemplates on c.CourseID  equals ct.CourseID
                where c.ID == id
                orderby ct.Name
                select new CourseDetailsDTO 
                {
                    ID = c.ID,
                    CourseID = c.CourseID,
                    Name = ct.Name,
                    Credits = ct.Credits,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    Semester = c.Semester,
                }).SingleOrDefault();

                return course;
        }

        // api/courses/1 - PUT
        // Mutable are StartDate and EndDate
        public bool modifyCourse(int id, modifyCourseViewModel course)
        {
            var modCourse = _db.Courses.SingleOrDefault(x => x.ID == id);
            
            if(modCourse == null)
            {
                return false;
            }

            modCourse.StartDate = course.StartDate;
            modCourse.EndDate = course.EndDate;

            _db.SaveChanges();

            return true;
        }

        public bool deleteCourse(int id)
        {
            var delCourse = _db.Courses.SingleOrDefault(x => x.ID == id);

            if(delCourse == null)
            {
                return false;
            }

            _db.Courses.Remove(delCourse);
            _db.SaveChanges();
            
            return true;
        }
    }
}
