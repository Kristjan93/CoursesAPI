using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CoursesAPI.Models.ViewModels;
using CoursesAPI.Models.DTOModels;
using CoursesAPI.Services;


namespace CoursesAPI.API.Controllers
{
    [Route("api/courses")]
    public class CoursesController : Controller
    {   
        private readonly ICoursesService _service;
        
        public CoursesController(ICoursesService service) 
        {
            _service = service;
        }
        
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
    }
}
