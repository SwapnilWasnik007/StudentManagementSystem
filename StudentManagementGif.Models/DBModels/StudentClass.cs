using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentManagementGif.Models.DBModels
{
    public class StudentClass
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("StudentUser")]
        public int StudentId { get; set; }
        [ForeignKey("SchoolClass")]
        public int ClassId { get; set; }

        public User StudentUser { get; set; }
        public SchoolClass SchoolClass { get; set; }
    }
}
