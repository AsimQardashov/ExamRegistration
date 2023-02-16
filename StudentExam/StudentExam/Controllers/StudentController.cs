using DataAccess.Repositories;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StudentExam.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentInterface _studentInterface;

        public StudentController(IStudentInterface studentInterface)
        {
            _studentInterface = studentInterface;
        }
        public async Task<IActionResult> Index()
        {
            var students = await _studentInterface.GetAllStudentAsync();
            return View(students);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentName,StudentSurname,Class,Exams")] Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _studentInterface.CreateStudentAsync(student);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                throw;
            }
            return View(student);
        }

        public async Task<IActionResult> Update(int id)
        {
            var stuent = await _studentInterface.GetStudentByIdAsync(id);
            return View(stuent);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Student student)
        {
            await _studentInterface.UpdateStudentAsync(student);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = await _studentInterface.GetStudentByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
        public async Task<IActionResult> Delete(int id)
        {
            _studentInterface.DeleteStudentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
