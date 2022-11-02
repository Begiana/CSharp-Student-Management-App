using StudentsManagementApp.DAO;
using StudentsManagementApp.DTO;
using StudentsManagementApp.Models;
using System.Xml;

namespace StudentsManagementApp.Service
{
    public class StudentServiceImpl : IStudentService
    {
        private readonly IStudentDAO dao;

        public StudentServiceImpl(IStudentDAO dao)
        {
            this.dao = dao;
        }
        public Student? DeleteStudent(StudentDTO? dto)
        {
            if (dto == null) return null;

            try
            {
                Student? student = ConvertDTOToStudent(dto);
                return dao.Delete(student);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<Student> GetAllStudents()   
        {
            try
            {
                return dao.GetAll();
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Student>();
            }
        }

        public Student? GetStudent(int id)
        {
            try
            {
              return  dao.GetStudent(id);

            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void InsertStudent(StudentDTO? dto)
        {
            if (dto == null) return;

            try
            {
                Student? student = ConvertDTOToStudent(dto);
                dao.Insert(student);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void UpdateStudent(StudentDTO? dto)
        {
            if (dto == null) return;

            try
            {
                Student? student = ConvertDTOToStudent(dto);
                dao.Update(student);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private Student? ConvertDTOToStudent(StudentDTO? dto)
        {
            if (dto == null) return null;

            return new Student ()
            {
                Id = dto.Id,
                Firstname=dto.Firstname,
                Lastname=dto.Lastname   
            };
        }
    }
}
