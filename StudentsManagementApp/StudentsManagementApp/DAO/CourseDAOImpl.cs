using StudentsManagementApp.DAO.DBUtil;
using StudentsManagementApp.Models;
using System.Data.SqlClient;

namespace StudentsManagementApp.DAO
{
    public class CourseDAOImpl : ICourseDAO
    {
        public Course? Delete(Course? course)
        {
            if (course == null) return null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                
                string sql1 = "DELETE FROM STUDENT_COURSE WHERE COURSE_ID = @id";
                string sql2 = "DELETE FROM COURSES WHERE ID = @id";

                using SqlCommand command1 = new(sql1, conn);
                using SqlCommand command2 = new(sql2, conn);


                command1.Parameters.AddWithValue("@id", course.Id);
                command2.Parameters.AddWithValue("@id", course.Id); ;

                command1.ExecuteNonQuery();
                int rowsAffected = command2.ExecuteNonQuery();
                return (rowsAffected > 0) ? course : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public List<Course> GetAll()
        {
            List<Course> courses = new List<Course>();

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                if (conn != null)
                {
                    conn.Open();
                }
                string sql ="SELECT * FROM COURSES";

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

        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null)
                {
                    conn.Open();
                }

                string sql = "SELECT * FROM TEACHERS";

                using SqlCommand command = new SqlCommand(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Teacher teacher = new()
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2)
                    };

                    teachers.Add(teacher);
                }
                return teachers;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public Course? GetCourse(int id)
        {
            Course? course = null;
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                if (conn != null)
                {
                    conn.Open();
                }
                string sql = "SELECT * FROM COURSES WHERE ID=@id";

                using SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    course = new Course()
                    {
                        Id = reader.GetInt32(0),
                        Description = reader.GetString(1),
                        TeacherId = reader.GetInt32(2)
                    };

                }
                return course;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Insert(Course? course)
        {
            if (course == null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                if (conn != null)
                {
                    conn.Open();
                }
                else { return; }
                string sql = "INSERT INTO COURSES " +
                            "(DESCRIPTION,TEACHER_ID) VALUES" +
                            "(@description,@teacherId)";

                using SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@description", course.Description);
                command.Parameters.AddWithValue("@teacherId", course.TeacherId);


                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Update(Course? course)
        {
            if (course == null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                if (conn != null)
                {
                    conn.Open();
                }
                else { return; }
                string sql = "UPDATE COURSES SET DESCRIPTION = @description, " +
                    "TEACHER_ID = @teacherId WHERE ID = @id";


                using SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@description", course.Description);
                command.Parameters.AddWithValue("@teacherId", course.TeacherId);
                command.Parameters.AddWithValue("@id", course.Id);

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

