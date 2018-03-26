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
        public int S_Pwd { get; set; }
        [Display(Name = "创建日期")]
        public string S_CreatTime { get; set; }
    }
}