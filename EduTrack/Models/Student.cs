using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduTrack.Models
{
    public class Student : User
    {
        public virtual ICollection<Enrollment> Enrollments{ get; set; }

    }
}
