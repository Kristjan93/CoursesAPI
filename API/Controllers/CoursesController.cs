using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CoursesAPI.Models.ViewModels;
using CoursesAPI.Models.DTOModels;
using CoursesAPI.Services;
using CoursesAPI.Services.Entities;


namespace CoursesAPI.API.Controllers
{
    /// <summary>
    /// CoursesController implements API methods for courses and there students
    /// </summary>
    [Route("api/courses")]
    public class CoursesController : Controller
    {   
        private readonly ICoursesService _service;
        
        public CoursesController(ICoursesService service) 
        {
            _service = service;
        }
        
        /// <summary>
        /// CreateCourse creates a new course instance.
        /// </summary>
        /// <param name="course">
        /// Hold the necessary properties for a new Corse instance to be created.
        /// </param>
        /// <returns>
        /// Given an invalid model object return BadRequest-400Status.
        /// If not an invalid model Created-201 and the location/url to the newly created instance is returned.
        /// </returns>
        [HttpPost]
        public IActionResult CreateCourse([FromBody] CreateCourseViewModel course)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var creCourse = _service.CreateCourse(course);
            var location = Url.Link("GetCourseById", new { id = creCourse.ID });
            return Created(location, creCourse);
        }
        
        /// <summary>
        /// GetCoursesBySemester fetches courses specified from a query string.
        /// </summary>
        /// <param name="semester">
        /// Is a an optional query string parameter that if left empty will be set to a default "20163"
        /// or the current semester.
        /// </param>
        /// <example>
        /// "20153": the 3 at the end representing fall
        /// 20152: summer
        /// 20161: spring
        /// </example>
        /// <returns>
        /// NotFound status if the requested semester does not exist or there where no courses taught at that time.
        /// OK status and a list of courses if found.
        /// </summary>
        [HttpGet]
        public IActionResult GetCoursesBySemester(string semester = null)
        {   
            var courses = _service.GetCoursesBySemester(semester); 
            
            if(courses == null)
            {
                return NotFound();
            }

            return Ok(courses);
        }

        /// <summary>
        ///  GetCourseById gets a course by it's id and returns the a detailed model containing 
        /// information about the course. 
        /// </summary>
        /// <param name="id">Is used to find the specific course</param>
        /// <returns>
        /// NotFound the service return null.
        /// OK status and a courses instance found by id.
        /// <returns>
        [HttpGet]
        [Route("{id:int}", Name="GetCourseById")]
        public IActionResult GetCourseById(int id)
        {   
            var course = _service.GetCourseById(id); 
            
            if(course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        /// <summary>
        /// Modifies/Updates a course by id.
        /// Only StartDate and EndDate can be modified by the user.
        /// </summary>
        /// <param name="id">Represents the course id</param>
        /// <param name="course">Is a class instance with properties that the user can change</param>
        /// <returns>
        /// Given an invalid model object return BadRequest-400Status.
        /// NotFound if no course was found by the course id.
        /// Ok on Course being successfully modified.
        ///</returns> 
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult modifyCourse(int id, [FromBody] modifyCourseViewModel course)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            bool wasUpdated = _service.modifyCourse(id, course);

            if(wasUpdated == false)
            {
                return NotFound();
            }

            return Ok();
        }

        /// <summary>
        /// Deletes a course by id.
        /// </summary>
        /// <param name="id">Represents the course id</param>
        /// <returns>
        /// NotFound if a course was not found by the course id.
        /// NoContentResult if a course was successfully deleted.
        /// </returns>
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult deleteCourse(int id)
        {
            bool wasDeleted = _service.deleteCourse(id);

            if(wasDeleted == false)
            {
                return NotFound();
            }

            return new NoContentResult();
        }

        /// <summary>
        /// GetCourseStudentsByCourseId fetches a list of all students given a course id. 
        /// </summary>
        /// <param name="id">Represents the course id</param>
        /// <returns>
        /// NotFound if a course was not found by the course id.
        /// OK status and a student list from students enrolled in a course. 
        /// </returns>
        [HttpGet]
        [Route("{id:int}/students", Name="GetCourseStudentsByCourseId")]
        public IActionResult GetCourseStudentsByCourseId(int id)
        {
            var students = _service.GetCourseStudentsByCourseId(id); 
            
            if(students == null)
            {
                return NotFound();
            }

            return Ok(students);
        }

        /// <summary>
        /// SetStudentToCourse takes an existing student and enrolls him in a course.
        /// </summary>
        /// <param name="student">A model containing only the SSN of the student</param>
        /// <returns>
        /// Given an invalid model object return BadRequest-400Status.
        /// _service.SetStudentToCourse return a model with a property HttpAnswer
        /// indication what http status code should be called.
        /// Since i am no C# expert and it is getting very late i am sorry for my bad english.
        /// </returns>
        [HttpPost]
        [Route("{courseId:int}/students")]
        public IActionResult SetStudentToCourse(int courseId, [FromBody] SetStudentViewModel student)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var setStudent = _service.SetStudentToCourse(courseId, student);

            string httpAnswer = setStudent.HttpAnswer;

            if(httpAnswer == "Created")
            {
                return Created("", setStudent); 
            }
            else if(httpAnswer == "Conflict")
            {
                // There is no Conflict response in core it seems
                return BadRequest();
            }
            else 
            {
                return NotFound();
            }
        }

    }
}
