using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Exam
    {
        public int ExamId { get; set; }
        [Required]
        [Column(TypeName = "char(3)")]
        [ForeignKey("Lesson")]
        public string? LessonCode { get; set; }
        public Lesson? Lesson { get; set; }
        [Required]
        [Column(TypeName = "numeric(5,0)")]
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime ExamDate { get; set; }
        [Required]
        [Column(TypeName = "numeric(1,0)")]
        public int Score { get; set; }
    }
}
