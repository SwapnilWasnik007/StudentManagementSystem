using StudentManagementGif.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementGif.Data.Student
{
    public interface IStudentRepository
    {
        List<UserView> GetAllStudentRepository();
        UserEditView GetStudentByIdRepository(int Id);
        List<ClassView> GetClassRepository();
        void UpdateStudentRepository(UserEditView editView);
        void UpdateStudentStatusRepository(List<StudentStatusUpdateModel> studentStatus);
    }
}
