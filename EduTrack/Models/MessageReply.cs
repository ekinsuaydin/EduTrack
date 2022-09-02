using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduTrack.Models
{
    public class MessageReply
    {
        [Key]
        public int ReplyID { get; set; }
        [StringLength(100)]
        //public string ReplyName { get; set; }
        public string ReplyText { get; set; }
        public string Time { get; set; }
        public int MessageID { get; set; }
        [ForeignKey("MessageID")]
        public virtual Message Message { get; set; }
        //[ForeignKey("User")]
        //public int UserID { get; set; }

        //public virtual User User { get; set; }



    }
}

