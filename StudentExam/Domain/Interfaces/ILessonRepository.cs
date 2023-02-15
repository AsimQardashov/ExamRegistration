using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILessonRepository
    {
        Task<List<Lesson>> GetAllLessonAsync();
        Task<Lesson> GetLessonByCodeAsync(string lessonCode);
        Task<List<Lesson>> CreateLessonAsync(Lesson lesson);
        Task<List<Lesson>> UpdateLessonAsync(Lesson lesson);
        public void DeleteLessonAsync(string lessonCode);
    }
}
