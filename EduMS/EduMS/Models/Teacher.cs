using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EduMS.Models
{
    public class Teacher
    {
        public int ID { get; set; }
        [Display(Name = "工号")]
        public int T_Id { get; set; }
        [Display(Name = "教师姓名")]
        public string T_Name { get; set; }
    }
}