using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsManagementApp.DAO;
using StudentsManagementApp.DTO;
using StudentsManagementApp.Models;
using StudentsManagementApp.Service;

namespace StudentsManagementApp.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService service;
        
        public DeleteModel()
        {
            service = new StudentServiceImpl(studentDAO);
        }

        internal string errorMessage = "";
        public void OnGet()
        {
            StudentDTO studentDTO = new StudentDTO();
            try
            {

                Student? student;

                int id = int.Parse(Request.Query["id"]);
                studentDTO.Id = id;
                student = service.DeleteStudent(studentDTO);
                Response.Redirect("/Students/Index");

            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }
    }
}
