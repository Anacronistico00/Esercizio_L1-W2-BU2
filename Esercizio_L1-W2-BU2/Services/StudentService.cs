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

        public async Task<bool> UpdateStudentAsync(EditStudentViewModel student)
        {
            try
            {
               var studentToUpdate = await _applicationDBContext.Students.FindAsync(student.Id);

                if(studentToUpdate == null)
                {
                    return false;
                }

                studentToUpdate.Nome = student.Nome;
                studentToUpdate.Cognome = student.Cognome;
                studentToUpdate.DataDiNascita = student.DataDiNascita;
                studentToUpdate.Email = student.Email;
                await _applicationDBContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteStudentAsync(Guid id)
        {
            try
            {
                var studentToDelete = await _applicationDBContext.Students.FindAsync(id);
                if (studentToDelete == null)
                {
                    return false;
                }
                _applicationDBContext.Students.Remove(studentToDelete);
                await _applicationDBContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CreateStudentAsync(AddStudentViewModel student)
        {
            try
            {
                var studentToAdd = new Student()
                {
                    Id = Guid.NewGuid(),
                    Nome = student.Nome,
                    Cognome = student.Cognome,
                    DataDiNascita = student.DataDiNascita,
                    Email = student.Email
                };

                await _applicationDBContext.Students.AddAsync(studentToAdd);
                await _applicationDBContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
