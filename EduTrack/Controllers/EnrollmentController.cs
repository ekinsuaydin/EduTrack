using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using EduTrack.Data;
using EduTrack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EnrollmentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Enrollment> enrollmentList = _db.Enrollments.Include(n => n.Student).Include(n => n.Course);

            return View(enrollmentList);
        }
        //GET-Create
        public IActionResult Create()
        {
            var courseList = (from course in _db.Courses
                               select new SelectListItem()
                               {
                                   Text = course.CourseName,
                                   Value = course.CourseID.ToString()
                               }).ToList();

            courseList.Insert(0, new SelectListItem()
            {
                Text = "Choose Course",
                Value = string.Empty
            });
            var studentList = (from student in _db.Users
                               where student.RoleName == "Student"
                               select new SelectListItem()
                               {
                                   Text = student.FullName,
                                   Value = student.Id.ToString()
                               }).ToList();

            studentList.Insert(0, new SelectListItem()
            {
                Text = "Enroll Student",
                Value = string.Empty
            });
            ViewBag.Students = studentList;
            ViewBag.Courses = courseList;

            return View();
        }

        //POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Enrollment studentEnrollment)
        {
            
            _db.Enrollments.Add(studentEnrollment);

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET-Enrolment/Details
        public IActionResult Details(int? id = 0)
        {
            var enrollment = _db.Enrollments.Find(id);
            return View(enrollment);

        }

        // GET: /Enrollment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var enrollment = _db.Enrollments.Find(id);
            var studentList = (from student in _db.Users
                               where student.RoleName == "Student"
                               select new SelectListItem()
                               {
                                   Text = student.FullName,
                                   Value = student.Id.ToString()
                               }).ToList();

            studentList.Insert(0, new SelectListItem()
            {
                Text = "Enroll Student",
                Value = string.Empty
            });
            var courseList = (from course in _db.Courses
                              select new SelectListItem()
                              {
                                  Text = course.CourseName,
                                  Value = course.CourseID.ToString()
                              }).ToList();

            courseList.Insert(0, new SelectListItem()
            {
                Text = "Choose Course",
                Value = string.Empty
            });
            ViewBag.Students = studentList;
            ViewBag.Courses = courseList;

            return View(enrollment);
        }

        // POST: /Enrollment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Enrollment studentEnrollment)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(studentEnrollment).State = EntityState.Modified;
                //studentEnrollment.EnrollmentDate = DateTime.Now;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentEnrollment);
        }

        // GET: Enrollment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = _db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollment = _db.Enrollments.Find(id);
            _db.Enrollments.Remove(enrollment);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //GET-MyCourses
        public IActionResult MyCourses()
        {

            IEnumerable<Enrollment> courseList = _db.Enrollments.Include(n => n.Student).Include(n => n.Course)
                            .Where(a => a.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            return View(courseList);

        }
        //GET-MyCourse
        public IActionResult MyCourse(int? id)
        {
            var course = _db.Courses.Find(id);

            return View(course);

        }
        public async Task<IActionResult> ViewStudents_T(int? id)
        {
            var course = _db.Courses.Find(id);

            IEnumerable<Enrollment> studentList = _db.Enrollments         
                .Include(a => a.Student)
                .Where(a => a.CourseID == course.CourseID);


            return View(studentList);

        }

    }
}