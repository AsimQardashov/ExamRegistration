using DataAccess.Repositories;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.EntityFrameworkCore;

namespace StudentExam.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamInterface _examInterface;
        public ExamController(IExamInterface examInterface)
        {
            _examInterface = examInterface;
        }
        public async Task<IActionResult> Index()
        {
            var exams = await _examInterface.GetAllExamAsync();
            return View(exams);
        }

        public async Task<IActionResult> Create()
        {
            var lessonsdata = await _examInterface.GetAllLessonAsync();
            ViewBag.LessonCode = lessonsdata.Select(x => new SelectListItem()
            {
                Text = x.LessonTitle,
                Value = x.LessonCode
            });
            var studentsData = await _examInterface.GetAllStudentAsync();
            ViewBag.StudentId = studentsData.Select(x => new SelectListItem()
            {
                Text = x.StudentName,
                Value = x.StudentId.ToString()
            });
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExamId,LessonCode,StudentId,ExamDate,Score")] Exam exam)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _examInterface.CreateExamAsync(exam);
                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch (DbUpdateException)
            {
                throw;
            }
            return View(exam);
            
        }
        public async Task<IActionResult> Update(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var exam = await _examInterface.GetExamByIdAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            var lessonsdata = await _examInterface.GetAllLessonAsync();
            ViewBag.LessonCode = lessonsdata.Select(x => new SelectListItem()
            {
                Text = x.LessonTitle,
                Value = x.LessonCode
            });
            var studentsData = await _examInterface.GetAllStudentAsync();
            ViewBag.StudentId = studentsData.Select(x => new SelectListItem()
            {
                Text = x.StudentName,
                Value = x.StudentId.ToString()
            });
            return View(exam);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, [Bind("ExamId,LessonCode,StudentId,ExamDate,Score")] Exam exam)
        {
            if (id != exam.ExamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _examInterface.UpdateExamAsync(exam);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

            }
            return View();
        }

        public async Task<IActionResult> Detail(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = await _examInterface.GetExamByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        public async Task<IActionResult> Delete(int id)
        {
            _examInterface.DeleteExamAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
