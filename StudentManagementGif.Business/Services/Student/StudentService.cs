using StudentManagementGif.Data.Student;
using StudentManagementGif.Models.DBModels;
using StudentManagementGif.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementGif.Business.Services.Student
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<UserView> GetAllStudentService()
        {
            return _studentRepository.GetAllStudentRepository();
        }

        public List<ClassView> GetClassService()
        {
            return _studentRepository.GetClassRepository();
        }

        public UserEditView GetUserByIdService(int Id)
        {
            return _studentRepository.GetStudentByIdRepository(Id);
        }

        public void UpdateStudentService(UserEditView user)
        {
            _studentRepository.UpdateStudentRepository(user);
        }

        public void UpdateStudentStatus(List<StudentStatusUpdateModel> studentStatus)
        {
            _studentRepository.UpdateStudentStatusRepository(studentStatus);
        }
    }
}
