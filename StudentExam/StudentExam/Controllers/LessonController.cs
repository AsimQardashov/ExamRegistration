using DataAccess.Repositories;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StudentExam.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonController(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _lessonRepository.GetAllLessonAsync();
            return View(result);
        }

        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LessonCode,LessonTitle,Class,TeacherName,TeacherSurname")] Lesson lesson)
        { 
            try
            {
                if (ModelState.IsValid)
                {
                    await _lessonRepository.CreateLessonAsync(lesson);
                    //await _lessonRepository.CommitAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                throw;
            }
            return View(lesson);
        }

        //[Route("id")]
        public async Task<IActionResult> Update(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = await _lessonRepository.GetLessonByCodeAsync(id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Lesson lesson)
        {
            await _lessonRepository.UpdateLessonAsync(lesson);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            _lessonRepository.DeleteLessonAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = await _lessonRepository.GetLessonByCodeAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }



    }
}
