using System;
using System.Collections.Generic;
using System.Text;
using EduTrack.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<EduTrack.Models.Course> Courses { get; set; }
        public DbSet<EduTrack.Models.User> Users { get; set; }
        public DbSet<EduTrack.Models.Enrollment> Enrollments { get; set; }
        public DbSet<EduTrack.Models.Assignment> Assignments { get; set; }
        public DbSet<EduTrack.Models.Announcement> Announcements { get; set; }
        public DbSet<EduTrack.Models.Submission> Submissions { get; set; }


    }
}
