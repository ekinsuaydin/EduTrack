using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduTrack.Models
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        public string MessageName { get; set; }
        public string MessageText { get; set; }
        public string Time { get; set; }
        //[ForeignKey("User")]
        //public int UserID { get; set; }
        //public virtual User User { get; set; }
        public int CourseID { get; set; }
        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }
        public virtual ICollection<MessageReply> MessageReplies { get; set; }
    }
}
