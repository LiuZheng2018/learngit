using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EduMS.Models
{
    public class Course
    {
        public int ID { get; set; }
        [Display(Name = "课程号")]
        public int C_Id { get; set; }
        [Display(Name = "课程名")]
        public string C_Name { get; set; }

        public virtual ICollection<Student > Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
    }
}