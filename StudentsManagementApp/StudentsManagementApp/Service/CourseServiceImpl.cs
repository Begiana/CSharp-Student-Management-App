using StudentsManagementApp.DAO;
using StudentsManagementApp.DTO;
using StudentsManagementApp.Models;

namespace StudentsManagementApp.Service
{
    public class CourseServiceImpl : ICourseService
    {
        private readonly ICourseDAO dao;

        public CourseServiceImpl(ICourseDAO dao)
        {
            this.dao = dao;
        }
        public Course? DeleteCourse(CourseDTO? dto)
        {
            if (dto == null) return null;

            try
            {
                Course? course = ConvertDTOToCourse(dto);
                return dao.Delete(course);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        public List<Course> GetAllCourses()
        {
            try
            {
                return dao.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Course>();
            }
        }

        public List<Teacher> GetAllTeachers()
        {
            try
            {
                return dao.GetAllTeachers();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Teacher>();
            }
        }

        public Course? GetOneCourse(int id)
        {
            try
            {
                return dao.GetCourse(id);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void InsertCourse(CourseDTO? dto)
        {
            if (dto == null) return;

            try
            {
                Course? course = ConvertDTOToCourse(dto);
                dao.Insert(course);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void UpdateCourse(CourseDTO? dto)
        {
            if (dto == null) return;

            try
            {
                Course? course = ConvertDTOToCourse(dto);
                dao.Update(course);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        private Course? ConvertDTOToCourse(CourseDTO? dto)
        {
            if (dto == null) return null;

            return new Course()
            {
                Id = dto.Id,
                Description = dto.Description,
                TeacherId = dto.TeacherId
            };
        }
    }
}
