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
        public List<CourseLiteDTO> GetCoursesBySemester(string semester = null)
        {
            return _service.GetCoursesBySemester(semester);
            /*
            return new List<CourseLiteDTO>
            {
                new CourseLiteDTO 
                {
                    ID = 1,
                    Name = "Web services",
                    Semester = "20163" 
                }
            };
            */
        }
    }
}
