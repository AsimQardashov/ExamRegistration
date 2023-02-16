using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IExamInterface
    {
        Task<List<Exam>> GetAllExamAsync();
        Task<List<Lesson>> GetAllLessonAsync();
        Task<List<Student>> GetAllStudentAsync();
        Task<Exam> GetExamByIdAsync(int examId);
        Task<List<Exam>> CreateExamAsync(Exam exam);
        Task<List<Exam>> UpdateExamAsync(Exam exam);
        public void DeleteExamAsync(int examId);
    }
}
