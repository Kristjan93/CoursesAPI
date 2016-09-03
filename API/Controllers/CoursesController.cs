using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CoursesAPI.Models;

namespace CoursesAPI.API.Controllers
{
    [Route("api/courses")]
    public class CoursesController : Controller
    {   
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<CourseLiteDTO> GetCoursesOnSemester(string semester = null)
        {
            return new List<CourseLiteDTO>
            {
                new CourseLiteDTO 
                {
                    ID = 1,
                    Name = "Web services",
                    Semester = "20163"
                }
            };
        }
    }
}
