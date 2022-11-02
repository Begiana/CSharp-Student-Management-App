using StudentsManagementApp.DAO;
using StudentsManagementApp.DTO;
using StudentsManagementApp.Models;

namespace StudentsManagementApp.Service
{
    public class EnrollServiceImpl : IEnrollService
    {
        private readonly IEnrollDAO dao;

        public EnrollServiceImpl(IEnrollDAO dao)
        {
            this.dao = dao;
        }
        public Enroll? DeleteEnroll(EnrollDTO? dto)
        {
            if (dto == null) return null;

            try
            {
                Enroll? enroll = ConvertDTOToEnroll(dto);
                return dao.Delete(enroll);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<Enroll> GetAllEnrollments()
        {
            try
            {
                return dao.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Enroll>();
            }
        }

        public List<Course> GetAllCourses()
        {
            try
            {
                return dao.GetAllCourses();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Course>();
            }
        }
        public List<Student> GetAllStudents()
        {
            try
            {
                return dao.GetAllStudents();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Student>();
            }
        }
        public void InsertEnroll(EnrollDTO? dto)
        {
            if (dto == null) return;

            try
            {
                Enroll? enroll = ConvertDTOToEnroll(dto);
                dao.Insert(enroll);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private Enroll? ConvertDTOToEnroll(EnrollDTO? dto)
        {
            if (dto == null) return null;

            return new Enroll()
            {
                StudentId = dto.StudentId,
                CourseId = dto.CourseId
            };
        }

       
    }
}
