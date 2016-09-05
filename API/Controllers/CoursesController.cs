using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CoursesAPI.Models;
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

        [HttpGet]
        public IActionResult GetCoursesBySemester(string semester = null)
        {   
            var courses = _service.GetCoursesBySemester(semester); 
            
            if(courses == null)
            {
                return NotFound();
            }

            return Ok(_service.GetCoursesBySemester(semester));
        }
    }
}
