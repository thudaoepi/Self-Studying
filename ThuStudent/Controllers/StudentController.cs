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
            //Student student = new Student();
            var student = students.Find(delegate (Student student) { return student.Id == id; });
            return View(student);            
        }
        [HttpPost]
        public IActionResult Edit(Student updatedStudent)
        {
            //Student oldStudent = new Student();
            var oldStudent = students.Find(s => s.Id == updatedStudent.Id);
            students.Remove(oldStudent);
            students.Add(updatedStudent);
            return RedirectToAction("Index");
        }
    }
}
