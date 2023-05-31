using Microsoft.EntityFrameworkCore;
using StudentManagementGif.Models.DBModels;
using StudentManagementGif.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentManagementGif.Data.Student
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentManagementContext _studentManagementContext;

        public StudentRepository(StudentManagementContext studentManagementContext)
        {
            _studentManagementContext = studentManagementContext;
        }

        public List<UserView> GetAllStudentRepository()
        {
            return _studentManagementContext.ParentStudent
                    .Include(x => x.ParentUser)
                    .Include(a => a.StudentUser)
                    .Join(_studentManagementContext.StudentClass.Include(c => c.SchoolClass),
                    stud => stud.StudentId,
                    studclass => studclass.StudentId,
                    (stud, studclass) => new { ParentStudent = stud, StudClass = studclass })
                    .Select(b => new UserView
                    {
                        Id = b.ParentStudent.StudentId,
                        StudentName = $"{b.ParentStudent.StudentUser.FirstName} {b.ParentStudent.StudentUser.LastName}",
                        ParentName = $"{b.ParentStudent.ParentUser.FirstName} {b.ParentStudent.ParentUser.LastName}",
                        StudentClass = b.StudClass.SchoolClass.Name,
                        ParentEmail = b.ParentStudent.ParentUser.Email,
                        ParentMobile = b.ParentStudent.ParentUser.Phone,
                        Active = b.ParentStudent.StudentUser.Active
                    }).ToList();
        }

        public UserEditView GetStudentByIdRepository(int Id)
        {
            return _studentManagementContext.ParentStudent
                     .Where(s => s.StudentId == Id)
                     .Include(x => x.ParentUser)
                     .Include(a => a.StudentUser)
                     .Join(_studentManagementContext.StudentClass.Include(c => c.SchoolClass),
                     stud => stud.StudentId,
                     studclass => studclass.StudentId,
                     (stud, studclass) => new { ParentStudent = stud, StudClass = studclass })
                     .Select(b => new UserEditView
                     {
                         Id = b.ParentStudent.StudentId,
                         StudentName = $"{b.ParentStudent.StudentUser.FirstName} {b.ParentStudent.StudentUser.LastName}",
                         ParentName = $"{b.ParentStudent.ParentUser.FirstName} {b.ParentStudent.ParentUser.LastName}",
                         ClassId = b.StudClass.SchoolClass.Id,
                         ParentEmail = b.ParentStudent.ParentUser.Email,
                         ParentMobile = b.ParentStudent.ParentUser.Phone,
                         Active = b.ParentStudent.StudentUser.Active
                     }).FirstOrDefault();
        }

        public List<ClassView> GetClassRepository()
        {
            return _studentManagementContext.SchoolClass
                .Select(x => new ClassView
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
        }

        public void UpdateStudentRepository(UserEditView editView)
        {
            ParentStudent user = _studentManagementContext.ParentStudent
                .Include(x => x.StudentUser)
                .Include(y => y.ParentUser)
                .Where(x => x.StudentId == editView.Id)
                .FirstOrDefault();

            if (user != null)
            {
                user.StudentUser.FirstName = editView.StudentName.Split(" ", 2)[0];
                user.StudentUser.LastName = editView.StudentName.Split(" ", 2)[1];
                user.ParentUser.Email = editView.ParentEmail;
                user.ParentUser.Phone = editView.ParentMobile;
                user.StudentUser.Active = editView.Active;
            }

            StudentClass studClass = _studentManagementContext.StudentClass
                .Where(x => x.StudentId == editView.Id)
                .FirstOrDefault();

            if (studClass != null)
            {
                studClass.ClassId = editView.ClassId;
            }
            _studentManagementContext.SaveChanges();
        }

        public void UpdateStudentStatusRepository(List<StudentStatusUpdateModel> studentStatus)
        {
            foreach (var status in studentStatus)
            {
                _studentManagementContext.User.Where(x => x.Id == status.Id).FirstOrDefault().Active = status.Active;
            }
            _studentManagementContext.SaveChanges();
        }
    }
}
