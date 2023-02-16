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
    public class ExamRepository : IExamInterface
    {
        private readonly ApplicationDbContext _context;
        public ExamRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Exam>> CreateExamAsync(Exam exam)
        {
            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();
            return await _context.Exams.ToListAsync();
        }

        public void DeleteExamAsync(int examId)
        {
            Exam exam = _context.Exams.Find(examId);
            _context.Exams.Remove(exam);
            _context.SaveChanges();
        }

        public async Task<List<Exam>> GetAllExamAsync()
        {
            return await _context.Exams.ToListAsync();
        }

        public async Task<List<Lesson>> GetAllLessonAsync()
        {
            return await _context.Lessons.ToListAsync();
        }

        public async Task<Exam> GetExamByIdAsync(int examId)
        {
            return await _context.Exams.FindAsync(examId);
        }

        public async Task<List<Student>> GetAllStudentAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<List<Exam>> UpdateExamAsync(Exam exam)
        {
            _context.Exams.Update(exam);
            await _context.SaveChangesAsync();
            return await _context.Exams.ToListAsync();
        }
    }
}
