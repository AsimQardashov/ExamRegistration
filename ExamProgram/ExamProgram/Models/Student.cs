using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamProgram.Models
{
    public class Student
    {
        [Key]
        [Required]
        [Column(TypeName = "numeric(5,0)")]
        public int StudentId { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string? StudentName { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string? StudentSurname { get; set; }
        [Required]
        [Column(TypeName = "numeric(2,0)")]
        public int Class { get; set; }
        public ICollection<Exam>? Exams { get; set; }
    }
}
