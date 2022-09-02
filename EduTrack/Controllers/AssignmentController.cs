using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EduTrack.Data;
using EduTrack.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;

namespace EduTrack.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly string wwwrootDirectory =
        //    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

        public AssignmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Assignments
        public async Task<IActionResult> Index()
        {

            var applicationDbContext = _context.Assignments
                .Include(a => a.Course)
                .Include(a => a.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Assignments
        public async Task<IActionResult> IndexTeacher(int? id)
        {
            var course = _context.Courses.Find(id);           
            var applicationDbContext = _context.Assignments
                .Include(a => a.Course)
                .Include(a => a.Teacher)
                .Where(a => a.CourseID == course.CourseID);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> IndexStudent(int? id)
        {
            var course = _context.Courses.Find(id);

            var applicationDbContext = _context.Assignments.Include(a => a.Course).Include(a => a.Teacher).Where(a => a.CourseID == course.CourseID);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Assignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments
                .Include(a => a.Course)
                .Include(a => a.Teacher)
                .FirstOrDefaultAsync(m => m.AssignmentId == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // GET: Assignments/Create
        public IActionResult Create()
        {
            var courseList = (from course in _context.Courses
                              where course.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
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
            ViewBag.Courses = courseList;
            ViewData["Id"] = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return View();
        }

        // POST: Assignments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssignmentId,AssignmentName,AssignmentText,DueDate,File,Id,CourseID")] Assignment assignment, IFormFile files)
        {
            if (files != null)
            {
                if (files.Length > 0)
                {
                    var fileName = Path.GetFileName(files.FileName);
                    var fileExtension = Path.GetExtension(fileName);
                    // concatenating  FileName + FileExtension
                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        assignment.File = target.ToArray();
                    }

                }
            }
                if (ModelState.IsValid)
                {
                    assignment.Id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    _context.Add(assignment);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                var courseList = (from course in _context.Courses
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
                ViewBag.Courses = courseList;

                return View(assignment);
        }
        

        // GET: Assignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            var courseList = (from course in _context.Courses
                              where course.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
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
            ViewBag.Courses = courseList;
            ViewData["Id"] = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return View(assignment);
        }

        // POST: Assignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssignmentId,AssignmentName,AssignmentText,DueDate,File,Id,CourseID")] Assignment assignment, IFormFile files)
        {
            if (id != assignment.AssignmentId)
            {
                return NotFound();
            }

            if (files != null)
            {
                if (files.Length > 0)
                {
                    var fileName = Path.GetFileName(files.FileName);
                    var fileExtension = Path.GetExtension(fileName);
                    // concatenating  FileName + FileExtension
                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        assignment.File = target.ToArray();
                    }

                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    assignment.Id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    _context.Update(assignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignmentExists(assignment.AssignmentId))
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
            var courseList = (from course in _context.Courses
                              where course.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
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
            ViewBag.Courses = courseList;
            return View(assignment);
        }

        // GET: Assignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments
                .Include(a => a.Course)
                .Include(a => a.Teacher)
                .FirstOrDefaultAsync(m => m.AssignmentId == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignmentExists(int id)
        {
            return _context.Assignments.Any(e => e.AssignmentId == id);
        }
    }
}
