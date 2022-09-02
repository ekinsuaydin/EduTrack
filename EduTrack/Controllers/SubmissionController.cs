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

namespace EduTrack.Controllers
{
    public class SubmissionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubmissionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Submission
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Submissions.Include(s => s.Assignment).Include(s => s.Student)
                .Where(s => s.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Submission/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submission = await _context.Submissions
                .Include(s => s.Assignment)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.SubmissionID == id);
            if (submission == null)
            {
                return NotFound();
            }

            return View(submission);
        }

        // GET: Submission/Create
        public IActionResult Create()
        {
            var assignmentList =
                       (from c in _context.Enrollments
                        join a in _context.Assignments on c.CourseID equals a.CourseID
                        where c.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select new SelectListItem()
                        {
                            Text = a.AssignmentName,
                            Value = a.AssignmentId.ToString()
                        }).ToList();
            assignmentList.Insert(0, new SelectListItem()
            {
                Text = "Choose Assignment",
                Value = string.Empty
            });
            ViewBag.Assignments = assignmentList;
            ViewData["Id"] = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return View();
        }

        // POST: Submission/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Submission submission, IFormFile files)
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
                        submission.File = target.ToArray();
                    }

                }
            }

            if (ModelState.IsValid)
            {
                submission.Id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                submission.SubmissionDate = DateTime.Now;
                _context.Add(submission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var assignmentList =
                        (from c in _context.Enrollments
                        join a in _context.Assignments on c.CourseID equals a.CourseID
                        where c.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select new SelectListItem()
                        {
                            Text = a.AssignmentName,
                            Value = a.AssignmentId.ToString()
                        }).ToList();
            assignmentList.Insert(0, new SelectListItem()
            {
                Text = "Choose Assignment",
                Value = string.Empty
            });
            ViewBag.Assignments = assignmentList;

           
          

            return View(submission);
        }

        

        // GET: Submission/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submission = await _context.Submissions.FindAsync(id);
            if (submission == null)
            {
                return NotFound();
            }

            var assignmentList =
                        (from c in _context.Enrollments
                         join a in _context.Assignments on c.CourseID equals a.CourseID
                         where c.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
                         select new SelectListItem()
                         {
                             Text = a.AssignmentName,
                             Value = a.AssignmentId.ToString()
                         }).ToList();
            assignmentList.Insert(0, new SelectListItem()
            {
                Text = "Choose Assignment",
                Value = string.Empty
            });
            ViewBag.Assignments = assignmentList;
            submission.Id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return View(submission);
        }

        // POST: Submission/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Submission submission)
        {
            if (id != submission.SubmissionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    submission.Id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    submission.SubmissionDate = DateTime.Now;
                    _context.Update(submission);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubmissionExists(submission.SubmissionID))
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
            var assignmentList =
                       (from c in _context.Enrollments
                        join a in _context.Assignments on c.CourseID equals a.CourseID
                        where c.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select new SelectListItem()
                        {
                            Text = a.AssignmentName,
                            Value = a.AssignmentId.ToString()
                        }).ToList();
            assignmentList.Insert(0, new SelectListItem()
            {
                Text = "Choose Assignment",
                Value = string.Empty
            });
            ViewBag.Assignments = assignmentList;
            

            return View(submission);
        }

        // GET: Submission/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submission = await _context.Submissions
                .Include(s => s.Assignment)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.SubmissionID == id);
            if (submission == null)
            {
                return NotFound();
            }

            return View(submission);
        }

        // POST: Submission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var submission = await _context.Submissions.FindAsync(id);
            _context.Submissions.Remove(submission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Submission/Delete/5
        public async Task<IActionResult> SubmittedStudents(int? id)
        {
            var assignment = _context.Assignments.Find(id);


            IEnumerable<Submission> submission =  _context.Submissions
                .Include(s => s.Assignment)
                .Include(s => s.Student)
                .Where(m => m.AssignmentId == assignment.AssignmentId);
                
           

            return View(submission);
        }


        private bool SubmissionExists(int id)
        {
            return _context.Submissions.Any(e => e.SubmissionID == id);
        }

    }
}
