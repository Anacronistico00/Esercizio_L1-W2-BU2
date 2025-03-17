using Esercizio_L1_W2_BU2.Models;
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

        [HttpGet("students/GetStudentDetails/{id:guid}")]
        public async Task<IActionResult> GetStudentById(Guid id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);

            if (student == null)
            {
                TempData["Error"] = "Error while finding entity on database";
                return RedirectToAction("Index");
            }

            var studentDetails = new Student()
            {
                Id = student.Id,
                Nome = student.Nome,
                Cognome = student.Cognome,
                DataDiNascita = student.DataDiNascita,
                Email = student.Email
            };

            return Json(studentDetails);
        }

    }
}
