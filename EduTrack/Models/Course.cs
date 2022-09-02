using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduTrack.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        [StringLength(100)]
        public string CourseName { get; set; }       
        public string Id { get; set; }
        [ForeignKey("Id")]
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Announcement> Announcements { get; set; }
        public virtual ICollection<Message> Messages { get; set; }


    }
}
