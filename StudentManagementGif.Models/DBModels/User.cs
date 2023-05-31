using StudentManagementGif.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementGif.Models.DBModels
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType UserType { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
    }
}
