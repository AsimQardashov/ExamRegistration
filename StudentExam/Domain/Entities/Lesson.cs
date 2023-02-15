using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Lesson
    {
        [Key]
        [Required]
        [Column(TypeName = "char(3)")]
        public string? LessonCode { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string? LessonTitle { get; set; }
        [Required]
        [Column(TypeName = "numeric(2,0)")]
        public int Class { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string? TeacherName { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string? TeacherSurname { get; set; }
        public ICollection<Exam>? Exams { get; set; }
    }
}
