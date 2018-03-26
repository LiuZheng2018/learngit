using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EduMS.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }

        [Display(Name ="学号")]
        public int S_Id { get; set; }
        [Display(Name = "学生姓名")]
        public string S_Name { get; set; }
        [Display (Name ="性别")]
        public string S_Sex { get; set; }
        [Display (Name ="年龄")]
        public int S_Age { get; set; }

        public virtual ICollection <Course> Courses { get; set; }
        public virtual ICollection <Score > Scores { get; set; }


    }
}