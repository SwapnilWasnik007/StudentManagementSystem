using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementGif.Models.DBModels
{
    public class StudentManagementContext : DbContext
    {
        public StudentManagementContext(DbContextOptions<StudentManagementContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<SchoolClass> SchoolClass { get; set; }
        public DbSet<ParentStudent> ParentStudent { get; set; }
        public DbSet<StudentClass> StudentClass { get; set; }

    }
}
