using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EduTrack.Models
{
    public class Teacher : User
    {
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Announcement> Announcements { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
