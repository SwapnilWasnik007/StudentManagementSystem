using StudentManagementGif.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementGif.Business.Services.Student
{
    public interface IStudentService
    {
        List<UserView> GetAllStudentService();
        UserEditView GetUserByIdService(int Id);
        List<ClassView> GetClassService();
        void UpdateStudentService(UserEditView user);
        void UpdateStudentStatus(List<StudentStatusUpdateModel> studentStatus);
    }
}
