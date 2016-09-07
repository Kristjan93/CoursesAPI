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
        
        /// <summary>
        /// CreateCourse adds a new course instance to database.
        /// </summary>
        /// <param name="course">
        /// Hold's the necessary properties for a new Corse instance to be created.
        /// </param>
        /// <returns>
        /// A new CreatedCourseDTO instance.
        /// </returns>
        public CreatedCourseDTO CreateCourse(CreateCourseViewModel course) 
        {
            var creCourse = new Course 
            {
                TemplateName = course.TemplateName,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                DateCreated = DateTime.Now,
                Semester = course.Semester
            };

            _db.Courses.Add(creCourse);
            _db.SaveChanges();
            
            return new CreatedCourseDTO
            {
                TemplateName = creCourse.TemplateName,
                ID = creCourse.ID,
                StartDate = creCourse.StartDate,
                EndDate = creCourse.EndDate,
                Semester = creCourse.Semester
            };
        } 
        
        /// <summary>
        /// GetCoursesBySemester fetches the required data of by joining _db.Courses with _db.CourseTemplates.
        /// Since etch course instance does not contain it's name we must fetch it from CourseTemplates.
        /// </summary>
        /// <param name="semester">
        /// String parameter that if left empty will be set to a default "20163"
        /// or the current semester.
        /// </param>
        /// <example>
        /// "20153": the 3 at the end representing fall
        /// 20152: summer
        /// 20161: spring
        /// </example>
        /// <returns>
        /// null no courses where found.
        /// Or a List containing CourseLiteDTO.
        /// </summary>
        public List<CourseLiteDTO> GetCoursesBySemester(string semester)
        {
            if(semester == null)
            {
                semester = "20163";
            }

            var courses = (from c in _db.Courses
                join ct in _db.CourseTemplates on c.TemplateName  equals ct.TemplateName
                where c.Semester == semester
                orderby ct.CourseName
                select new CourseLiteDTO
                {
                    ID = c.ID,
                    Name = ct.CourseName,
                    Semester = c.Semester,
                    NumberOfStudents =  _db.CoursesStudents.Count(x => x.CourseID == c.ID)
                }).ToList();
                 
                if(!courses.Any())
                {
                    return null;
                }
                
                return courses;
        }

        /// <summary>
        ///  GetCourseById gets a course by it's id and returns the a detailed model containing 
        /// information about the course.
        /// First query is create a list of students in the course.
        /// </summary>
        /// <param name="id">Is used to find the specific course</param>
        /// <returns>
        /// 
        /// <returns>
        public CourseDetailsDTO GetCourseById(int id)
        {
            var students = (from s in _db.Students
                join cs in _db.CoursesStudents on s.ID equals cs.StudentID
                where cs.CourseID == id
                select new StudentLiteDTO
                {
                    ID = s.ID,
                    Name = s.Name
                }).ToList();

            var course = (from c in _db.Courses
                join ct in _db.CourseTemplates on c.TemplateName  equals ct.TemplateName
                where c.ID == id
                orderby ct.CourseName
                select new CourseDetailsDTO 
                {
                    ID = c.ID,
                    TemplateName = c.TemplateName,
                    CourseName = ct.CourseName,
                    Credits = ct.Credits,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    Semester = c.Semester,
                    Students = students
                }).SingleOrDefault();

                return course;
        }

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

        public List<StudentLiteDTO> GetCourseStudentsByCourseId(int id)
        {   
            var students = (from s in _db.Students
                join cs in _db.CoursesStudents on s.ID equals cs.StudentID
                where cs.CourseID == id
                select new StudentLiteDTO
                {
                    ID = s.ID,
                    Name = s.Name
                }).ToList();

            return students;
        }

        public SetStudentDTO SetStudentToCourse(int courseId, SetStudentViewModel student)
        {
            var setCourse = _db.Courses.SingleOrDefault(x => x.ID == courseId);
            var setStudent = _db.Students.SingleOrDefault(x => x.SSN == student.SSN);

            if(setCourse == null || setStudent == null)
            {
                return new SetStudentDTO
                {
                    HttpAnswer = "NotFound"
                };
            }

            var existingEntry = (from cs in _db.CoursesStudents
                where cs.CourseID == setCourse.ID && cs.StudentID == setStudent.ID
                select cs).SingleOrDefault();
            
            if(existingEntry != null)
            {
                return new SetStudentDTO
                {
                    HttpAnswer = "Conflict"
                };
            }

            var courseStudent = new CourseStudent
            {
                CourseID = setCourse.ID,
                StudentID = setStudent.ID
            };

            _db.CoursesStudents.Add(courseStudent);
            _db.SaveChanges();

            return new SetStudentDTO
            {
                ID = courseStudent.ID,
                SSN = setStudent.SSN,
                HttpAnswer = "Created"
            };
        }
    }
}
