using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EduTrack.Models
{

    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<MessageReply> MessageReplies { get; set; }

    }
}