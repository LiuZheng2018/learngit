using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SercicesMS.Models
{
    public class Service
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "服务名称")]
        public string S_Name { get; set; }
        [Required]
        [Display(Name = "服务地址")]
        public string S_Path { get; set; }
        //图片存储路径
        public string Pic_Path { get; set; }
        [Display(Name = "用户名")]
        public string S_User { get; set; }
        [MinLength(6)]
        [Display(Name = "用户密码")]
        public string S_Pwd { get; set; }
        [Display(Name = "创建日期")]
        public string S_CreatTime { get; set; }
        [Display(Name = "上次修改日期")]
        public string S_LastTime { get; set; }
        [Display(Name = "负责人")]
        public string S_Admin { get; set; }
        [Display(Name = "备注")]
        public string S_Remark { get; set; }
    }

}