using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentManagementGif.Models.DBModels
{
    public class ParentStudent
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ParentUser")]
        public int ParentId { get; set; }
        [ForeignKey("StudentUser")]
        public int StudentId { get; set; }

        public User ParentUser { get; set; }
        public User StudentUser { get; set; }
    }
}
