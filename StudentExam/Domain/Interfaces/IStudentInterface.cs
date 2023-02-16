using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IStudentInterface
    {
        Task<List<Student>> GetAllStudentAsync();
        Task<Student> GetStudentByIdAsync(int studentId);
        Task<List<Student>> CreateStudentAsync(Student student);
        Task<List<Student>> UpdateStudentAsync(Student student);
        public void DeleteStudentAsync(int studentId);
    }
}
