using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduTrack.Models
{
    public class Announcement
    {
        [Key]
        public int AnnouncementID { get; set; }
        [StringLength(100)]
        public string AnnouncementName { get; set; }
        public string AnnouncementText { get; set; }
        public string Id { get; set; }
        public int CourseID { get; set; }
        [ForeignKey("Id")]
        public virtual Teacher Teacher { get; set; }
        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }
    }
}
