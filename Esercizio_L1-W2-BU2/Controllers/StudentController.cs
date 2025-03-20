using Esercizio_L1_W2_BU2.Models;
using Esercizio_L1_W2_BU2.Services;
using Esercizio_L1_W2_BU2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Esercizio_L1_W2_BU2.Controllers
{
    [Authorize(Roles = "Docente")]
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;
        private readonly LoggerService _loggerService;
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentController(StudentService studentService, LoggerService loggerService, UserManager<ApplicationUser> userManager)
        {
            _studentService = studentService;
            _loggerService = loggerService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("students/GetAllStudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            var studentsList = new StudentsListViewModel();

            try
            {
                studentsList = await _studentService.GetAllStudentsAsync();
                _loggerService.LogInformation("Students retrieved successfully");
            }
            catch
            {
                studentsList.Students = null;
                _loggerService.LogError("Error while retrieving students");
            }
            
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

        [HttpGet("students/Edit/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);

            if (student == null)
            {
                TempData["Error"] = "Error while finding entity on database";
                return RedirectToAction("Index");
            }

            var editStudentViewModel = new EditStudentViewModel()
            {
                Id = student.Id,
                Nome = student.Nome,
                Cognome = student.Cognome,
                DataDiNascita = student.DataDiNascita,
                Email = student.Email
            };
            return PartialView("_EditStudent", editStudentViewModel);
        }

        [HttpPost("students/Edit/save")]
        public async Task<IActionResult> Edit(EditStudentViewModel student)
        {
            var result = await _studentService.UpdateStudentAsync(student);

            if (!result)
            {
                return Json(
                    new
                    {
                        success = false,
                        message = "Error while updating entity on database"
                    }
                );
            }

            string logMessage = "Entity updated successfully";
            _loggerService.LogInformation(logMessage);

            return Json(new
            {
                success = true,
                message = logMessage
            }); ;
        }

        [HttpPost("students/Delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _studentService.DeleteStudentAsync(id);

            if (!result)
            {
                return Json(
                    new
                    {
                        success = false,
                        message = "Error while deleting entity on database"
                    }
                );
            }

            string logMessage = "Entity deleted successfully";
            _loggerService.LogInformation(logMessage);

            return Json(new
            {
                success = true,
                message = logMessage
            });
        }

        public IActionResult Add()
        {
            return PartialView("_addStudent");
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel student)
        {
            try
            {
                _studentService.CreateStudentAsync(student);

                string logMessage = "Entity Added successfully";
                _loggerService.LogInformation(logMessage);

                return Json(new
                {
                    success = true,
                    message = logMessage
                });
            }
            catch
            {
                return Json(
                    new
                    {
                        success = false,
                        message = "Error while adding entity on database"
                    }
                );
            }
        }
    }
}
