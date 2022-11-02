using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsManagementApp.DAO;
using StudentsManagementApp.DTO;
using StudentsManagementApp.Models;
using StudentsManagementApp.Service;

namespace StudentsManagementApp.Pages.Teachers
{
    public class DeleteModel : PageModel
    {
        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
        private readonly ITeacherService service;

        public DeleteModel()
        {
            service = new TeacherServiceImpl(teacherDAO);
        }

        internal string errorMessage = "";
        public void OnGet()
        {
            TeacherDTO teacherDTO = new TeacherDTO();
            try
            {

                Teacher? teacher;

                int id = int.Parse(Request.Query["id"]);
                teacherDTO.Id = id;
                teacher = service!.DeleteTeacher(teacherDTO);
                Response.Redirect("/Teachers/Index");

            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }
    }
}
