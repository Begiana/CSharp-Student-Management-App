using StudentsManagementApp.DAO.DBUtil;
using StudentsManagementApp.Models;
using System.Data.SqlClient;

namespace StudentsManagementApp.DAO
{
    public class EnrollDAOImpl : IEnrollDAO
    {
        public Enroll? Delete(Enroll? enroll)
        {
            if (enroll == null) return null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) 
                { 
                    conn.Open(); 
                } else 
                { 
                    return null; 
                }

                string sql = "DELETE FROM STUDENT_COURSE WHERE STUDENT_ID = @studentId AND COURSE_ID=@courseId";

                using SqlCommand command = new(sql, conn);

                command.Parameters.AddWithValue("@studentId", enroll.StudentId);
                command.Parameters.AddWithValue("@courseId", enroll.CourseId);


                int rowsAffected = command.ExecuteNonQuery();
                return (rowsAffected > 0) ? enroll : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public List<Enroll> GetAll()
        {
            List<Enroll> enrolls = new List<Enroll>();

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                if (conn != null)
                {
                    conn.Open();
                }
                string sql = "SELECT * FROM STUDENT_COURSE";

                using SqlCommand command = new SqlCommand(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Enroll enroll = new Enroll()
                    {
                        StudentId = reader.GetInt32(0),
                        CourseId = reader.GetInt32(1)
                    };
                    enrolls.Add(enroll);
                }
                return enrolls;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null)
                {
                    conn.Open();
                }

                string sql = "SELECT * FROM COURSES";
                using SqlCommand command = new SqlCommand(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Course course = new Course()
                    {
                        Id = reader.GetInt32(0),
                        Description = reader.GetString(1),
                        TeacherId = reader.GetInt32(2)
                    };

                    courses.Add(course);
                }

                return courses;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null)
                {
                    conn.Open();
                }

                string sql = "SELECT * FROM STUDENTS";

                using SqlCommand command = new SqlCommand(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Student student = new Student()
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2)
                    };

                    students.Add(student);
                }

                return students;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Insert(Enroll? enroll)
        {
            if (enroll == null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                if (conn != null)
                {
                    conn.Open();
                }
                else { return; }
                string sql = "INSERT INTO STUDENT_COURSE " +
                            "(STUDENT_ID,COURSE_ID) VALUES" +
                            "(@studentId,@courseId)";

                using SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@studentId", enroll.StudentId);
                command.Parameters.AddWithValue("@courseId", enroll.CourseId);


                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

       
    }
}
