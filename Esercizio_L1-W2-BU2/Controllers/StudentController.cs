using Esercizio_L1_W2_BU2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Esercizio_L1_W2_BU2.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("students/GetAllStudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            var studentsList = await _studentService.GetAllStudentsAsync();
            return PartialView("_StudentsList", studentsList);
        }
    }
}
