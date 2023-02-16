using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class StudentRepesitory : IStudentInterface
    {
        private readonly ApplicationDbContext _context;
        public StudentRepesitory(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Student>> CreateStudentAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return await _context.Students.ToListAsync();
        }

       
        public async void DeleteStudentAsync(int studentId)
        {
            Student student = _context.Students.Find(studentId);
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public async Task<List<Student>> GetAllStudentAsync()
        {
            var a = await _context.Students.ToListAsync();
            return a;
        }

        
        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            var result = _context.Students.FirstOrDefault(x => x.StudentId == studentId);
            return result;
        }

        public Task<List<Student>> UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            return _context.Students.ToListAsync();
        }
    }
}
