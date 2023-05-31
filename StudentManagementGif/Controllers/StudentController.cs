using Microsoft.AspNetCore.Mvc;
using StudentManagementGif.Business.Services.Student;
using StudentManagementGif.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementGif.App.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View(_studentService.GetAllStudentService());
        }

        public IActionResult Edit(int Id)
        {
            var studData = _studentService.GetUserByIdService(Id);
            ViewData["Classes"] = _studentService.GetClassService();
            return View(studData);
        }

        public IActionResult Save(UserEditView userEditView)
        {
            _studentService.UpdateStudentService(userEditView);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateActiveStatus([FromBody]List<StudentStatusUpdateModel> activeStatus)
        {
            _studentService.UpdateStudentStatus(activeStatus);
            return RedirectToAction("Index");
        }
    }
}