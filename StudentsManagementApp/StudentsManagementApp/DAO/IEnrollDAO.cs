using StudentsManagementApp.Models;

namespace StudentsManagementApp.DAO
{
    public interface IEnrollDAO
    {
        void Insert(Enroll? enroll);
        Enroll? Delete(Enroll? enroll);
 
        List<Enroll> GetAll();

        List<Student> GetAllStudents();
        List<Course> GetAllCourses();


    }
}
