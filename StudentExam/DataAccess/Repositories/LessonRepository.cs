using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly ApplicationDbContext _context;
        public LessonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Lesson>> CreateLessonAsync(Lesson lesson)
        {
            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();
            return await _context.Lessons.ToListAsync();
        }

        public void DeleteLessonAsync(string lessonCode)
        {
            Lesson lesson = _context.Lessons.Find(lessonCode);
            _context.Lessons.Remove(lesson);
            _context.SaveChanges();
        }

        public async Task<List<Lesson>> GetAllLessonAsync()
        {
            return await _context.Lessons.ToListAsync();
        }

        public virtual async Task<Lesson> GetLessonByCodeAsync(string lessonCode)
        {
            var result = _context.Lessons.FirstOrDefault(x=>x.LessonCode == lessonCode);
            return result;
        }

        public Task<List<Lesson>> UpdateLessonAsync(Lesson lesson)
        {
            _context.Lessons.Update(lesson);
            _context.SaveChanges();
            return _context.Lessons.ToListAsync();
            
        }
    }
}
