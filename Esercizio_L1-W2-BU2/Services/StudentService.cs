using Esercizio_L1_W2_BU2.Data;
using Esercizio_L1_W2_BU2.Models;
using Esercizio_L1_W2_BU2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Esercizio_L1_W2_BU2.Services
{
    public class StudentService
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public StudentService(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public async Task<StudentsListViewModel> GetAllStudentsAsync()
        {
            var studentsList = new StudentsListViewModel();
            try
            {
                studentsList.Students = await _applicationDBContext.Students.ToListAsync();
            }
            catch
            {
                studentsList.Students = null;
            }
            return studentsList;
        }

        public async Task<Student> GetStudentByIdAsync(Guid id)
        {
            var student =  await _applicationDBContext.Students.FindAsync(id);
            return student;
        }
    }
}
