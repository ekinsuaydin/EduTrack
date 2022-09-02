using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduTrack.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }
        [StringLength(100)]
        public string AssignmentName { get; set; }
        public string AssignmentText { get; set; }
        public DateTime DueDate { get; set; }
        public byte[] File { get; set; }
        public string Id { get; set; }
        [ForeignKey("Id")]
        public virtual Teacher Teacher { get; set; }
        public int CourseID { get; set; }
        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }
    }
}
