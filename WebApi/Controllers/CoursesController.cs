using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private static List<CourseModel> _courses = new List<CourseModel>
        {
            new CourseModel { Id = 1, Title = "Kurs nr 1", Description = "Beskrivning för kurs 1" },
            new CourseModel { Id = 2, Title = "Kurs nr 2", Description = "Beskrivning för kurs 2" }
        };

        [HttpGet]
        public IActionResult GetAllCourses()
        {
            return Ok(_courses);
        }
    }
}
