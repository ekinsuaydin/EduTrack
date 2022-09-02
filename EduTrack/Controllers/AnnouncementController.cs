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

namespace EduTrack.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnnouncementController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            IEnumerable<Announcement> announcementList = _context.Announcements
                .Include(a => a.Course)
                .Include(a => a.Teacher);

            return View(announcementList);
        }

        // GET: Announcements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcements
                .Include(a => a.Course)
                .Include(a => a.Teacher)
                .FirstOrDefaultAsync(m => m.AnnouncementID == id);
            if (announcement == null)
            {
                return NotFound();
            }

            return View(announcement);
        }

        // GET: Announcements/Create
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

        // POST: Announcements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnnouncementID,AnnouncementName,AnnouncementText,Id,CourseID")] Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                announcement.Id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _context.Add(announcement);
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
            return View(announcement);
        }

        // GET: Announcements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcements.FindAsync(id);
            if (announcement == null)
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
            return View(announcement);
        }

        // POST: Announcements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnnouncementID,AnnouncementName,AnnouncementText,Id,CourseID")] Announcement announcement)
        {
            if (id != announcement.AnnouncementID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    announcement.Id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    _context.Update(announcement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnouncementExists(announcement.AnnouncementID))
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
            return View(announcement);
        }

        // GET: Announcements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcements
                .Include(a => a.Course)
                .Include(a => a.Teacher)
                .FirstOrDefaultAsync(m => m.AnnouncementID == id);
            if (announcement == null)
            {
                return NotFound();
            }

            return View(announcement);
        }

        // POST: Announcements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var announcement = await _context.Announcements.FindAsync(id);
            _context.Announcements.Remove(announcement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnnouncementExists(int id)
        {
            return _context.Announcements.Any(e => e.AnnouncementID == id);
        }

        // GET: Announcements
        public async Task<IActionResult> IndexTeacher(int? id)
        {

            var course = _context.Courses.Find(id);

            IEnumerable<Announcement> announcementList = _context.Announcements
                .Include(a => a.Course)
                .Include(a => a.Teacher)
                .Where(a => a.CourseID == course.CourseID);

            return View(announcementList);
        }

        public async Task<IActionResult> IndexStudent(int? id)
        {
            var course = _context.Courses.Find(id);

            IEnumerable<Announcement> announcementList = _context.Announcements
                .Include(a => a.Course)
                .Include(a => a.Teacher)
                .Where(a => a.CourseID == course.CourseID);

            return View(announcementList);
        }
    }
}
