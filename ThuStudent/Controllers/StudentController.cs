using Microsoft.AspNetCore.Mvc;
using ThuStudent.Models;

namespace ThuStudent.Controllers
{
    public class StudentController : Controller
    {
        public static List<Student> students = new List<Student>();

        public IActionResult Index()
        {
            return View(students);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            students.Add(student);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {           
            return View();
        }

        public IActionResult Edit(int id)
        {
            var student = students.Find(delegate (Student student) { return student.Id == id; });
            if (student == null)
            {
                return NotFound();
            }
            return View(student);            
        }
        [HttpPost]
        public IActionResult Edit(Student updatedStudent)
        {
            var oldStudent = students.Find(s => s.Id == updatedStudent.Id);
            if (oldStudent == null)
            {
                return NotFound();
            }
            students.Remove(oldStudent);
            students.Add(updatedStudent);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var student = students.Find(delegate (Student student) { return student.Id == id; });
            if (student == null)
            {
                return NotFound();
            }
            students.Remove(student);
            return RedirectToAction("Index");
        }
    }
}
