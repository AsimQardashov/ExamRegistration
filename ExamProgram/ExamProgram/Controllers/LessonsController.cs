using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamProgram.Models;

namespace ExamProgram.Controllers
{
    public class LessonsController : Controller
    {
        private readonly ExamDbContext _context;

        public LessonsController(ExamDbContext context)
        {
            _context = context;
        }

        // GET: Lessons
        public async Task<IActionResult> Index()
        {
              return View(await _context.Courses.ToListAsync());
        }

        // GET: Lessons/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var lesson = await _context.Courses
                .FirstOrDefaultAsync(m => m.LessonCode == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // GET: Lessons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LessonCode,LessonName,Class,TeacherName,TeacherSurname")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lesson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lesson);
        }

        // GET: Lessons/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var lesson = await _context.Courses.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            return View(lesson);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LessonCode,LessonName,Class,TeacherName,TeacherSurname")] Lesson lesson)
        {
            if (id != lesson.LessonCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lesson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonExists(lesson.LessonCode))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(lesson);
        }

        // GET: Lessons/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var lesson = await _context.Courses
                .FirstOrDefaultAsync(m => m.LessonCode == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Courses == null)
            {
                return Problem("Entity set 'ExamDbContext.Courses'  is null.");
            }
            var lesson = await _context.Courses.FindAsync(id);
            if (lesson != null)
            {
                _context.Courses.Remove(lesson);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonExists(string id)
        {
          return _context.Courses.Any(e => e.LessonCode == id);
        }
    }
}
