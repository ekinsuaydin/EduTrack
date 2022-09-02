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
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CourseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Course> courseList = _db.Courses.Include(n => n.Teacher);
            return View(courseList);
        }
        //GET-Create
        public IActionResult Create()
        {

            //ViewBag.Id = new SelectList(_db.Users.Where(x => x.RoleName == "Teacher"),"Id");
            var teacherList = (from teacher in _db.Users 
                               where teacher.RoleName=="Teacher"
                               select new SelectListItem()
                               {
                                   Text = teacher.FullName,
                                   Value = teacher.Id.ToString()
                               }).ToList();

            teacherList.Insert(0, new SelectListItem()
            {
                Text = "Assign Teacher",
                Value = string.Empty
            });
            ViewBag.Teachers = teacherList;

            return View();
        }

        //POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            _db.Courses.Add(course);

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET-Course/Details
        public IActionResult Details(int? id = 0)
        {
            var course = _db.Courses.Find(id);
            return View(course);

        }

        // GET: /Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var course = _db.Courses.Find(id);
            var teacherList = (from teacher in _db.Users
                               where teacher.RoleName == "Teacher"
                               select new SelectListItem()
                               {
                                   Text = teacher.FullName,
                                   Value = teacher.Id.ToString()
                               }).ToList();

            teacherList.Insert(0, new SelectListItem()
            {
                Text = "Assign Teacher",
                Value = string.Empty
            });
            ViewBag.Teachers = teacherList;

            return View(course);
        }

        // POST: /Course/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(course).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Course/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _db.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = _db.Courses.Find(id);
            _db.Courses.Remove(course);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //GET-MyCourses
        public IActionResult MyCourses()
        {

            IEnumerable<Course> courseList = _db.Courses.Include(n => n.Teacher)
                            .Where(a => a.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            return View(courseList);

        }

        //GET-MyCourse
        public IActionResult MyCourse(int? id)
        {
            var course = _db.Courses.Find(id);
                                           
            return View(course);

        }

       
    }
}
