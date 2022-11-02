using StudentsManagementApp.DAO;
using StudentsManagementApp.DTO;
using StudentsManagementApp.Models;

namespace StudentsManagementApp.Service
{
    public class TeacherServiceImpl : ITeacherService
    {
        private readonly ITeacherDAO dao;

        public TeacherServiceImpl(ITeacherDAO dao)
        {
            this.dao = dao;
        }
        public Teacher? DeleteTeacher(TeacherDTO? dto)
        {
            if (dto == null) return null;

            try
            {
                Teacher? teacher = ConvertDTOToTeacher(dto);
                return dao.Delete(teacher);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<Teacher> GetAllTeachers()
        {
            try
            {
                return dao.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Teacher>();
            }
        }

        public Teacher? GetTeacher(int id)
        {

            try
            {
                return dao.GetTeacher(id);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void InsertTeacher(TeacherDTO? dto)
        {

            if (dto == null) return;

            try
            {
                Teacher? teacher = ConvertDTOToTeacher(dto);
                dao.Insert(teacher);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void UpdateTeacher(TeacherDTO? dto)
        {
            if (dto == null) return;

            try
            {
                Teacher? teacher = ConvertDTOToTeacher(dto);
                dao.Update(teacher);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        private Teacher? ConvertDTOToTeacher(TeacherDTO? dto)
        {
            if (dto == null) return null;

            return new Teacher()
            {
                Id = dto.Id,
                Firstname = dto.Firstname,
                Lastname = dto.Lastname
            };
        }
    }
}
