using StudentManagementGif.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentManagementGif.Models.ViewModels
{
    public class UserView
    {
        public int Id { get; set; }
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }
        [Display(Name = "Parent Name")]
        public string ParentName { get; set; }
        [Display(Name = "Student Class")]
        public string StudentClass { get; set; }
        [Display(Name = "Parent Email")]
        public string ParentEmail { get; set; }
        [Display(Name = "Parent Mobile")]
        public string ParentMobile { get; set; }
        [Display(Name = "Active")]
        public bool Active { get; set; }
    }
}
