using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduTrack.Models
{
    public class Submission
    {
        [Key]
        public int SubmissionID { get; set; }
        public string SubmissionComment { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SubmissionDate { get; set; }
        public byte[] File { get; set; }
        public string Id { get; set; } //Any submission is done by a student
        [ForeignKey("Id")]
        public virtual Student Student { get; set; }
        public int AssignmentId { get; set; }
        [ForeignKey("AssignmentId")]
        public virtual Assignment Assignment { get; set; }

        
    }
}
