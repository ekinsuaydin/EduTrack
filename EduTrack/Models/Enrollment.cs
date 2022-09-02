using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduTrack.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int CourseID { get; set; }
        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }
        public string Id { get; set; }
        [ForeignKey("Id")]
        public virtual Student Student { get; set; }

    }
}
