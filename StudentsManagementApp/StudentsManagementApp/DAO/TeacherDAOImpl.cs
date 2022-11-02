using StudentsManagementApp.DAO.DBUtil;
using StudentsManagementApp.Models;
using System.Data.SqlClient;

namespace StudentsManagementApp.DAO
{
    public class TeacherDAOImpl : ITeacherDAO
    {
        public Teacher? Delete(Teacher? teacher)
        {
            if (teacher == null) return null;
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                DeleteCourseAndStudentCourse(teacher.Id);
           
                string sql3 = "DELETE FROM TEACHERS WHERE ID=@id";

              
                using SqlCommand command3 = new(sql3, conn);

                
                command3.Parameters.AddWithValue("@id", teacher.Id);

               
                int rowsAffected = command3.ExecuteNonQuery();
                return (rowsAffected > 0) ? teacher : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public List<Teacher> GetAll()
        {
            List<Teacher> teachers = new List<Teacher>();

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                if (conn != null)
                {
                    conn.Open();
                }
                string sql = "SELECT * FROM TEACHERS";

                using SqlCommand command = new SqlCommand(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Teacher teacher = new Teacher()
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

        public Teacher? GetTeacher(int id)
        {
            Teacher? teacher = null;
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                if (conn != null)
                {
                    conn.Open();
                }
                string sql = "SELECT * FROM TEACHERS WHERE ID=@id";

                using SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    teacher = new Teacher()
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2)

                    };

                }
                return teacher;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Insert(Teacher? teacher)
        {
            if (teacher == null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                if (conn != null)
                {
                    conn.Open();
                }
                else { return; }
                string sql = "INSERT INTO TEACHERS " +
                            "(FIRSTNAME,LASTNAME) VALUES" +
                            "(@firstname,@lastname)";

                using SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@firstname", teacher.Firstname);
                command.Parameters.AddWithValue("@lastname", teacher.Lastname);

                command.ExecuteNonQuery(); 

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Update(Teacher? teacher)
        {
            if (teacher == null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                if (conn != null)
                {
                    conn.Open();
                }
                else { return; }
                string sql = "UPDATE TEACHERS SET FIRSTNAME = @firstname, " +
                    "LASTNAME = @lastname WHERE ID = @id";


                using SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@firstname", teacher.Firstname);
                command.Parameters.AddWithValue("@lastname", teacher.Lastname);
                command.Parameters.AddWithValue("@id", teacher.Id);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        
        }

        private void DeleteCourseAndStudentCourse(int id)
        {

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null)
                {
                    conn.Open();

                }
                else { return; }

                string sql1 = "DELETE FROM STUDENT_COURSE WHERE COURSE_ID = " +
                              "(SELECT ID FROM COURSES WHERE TEACHER_ID = @id)";

                string sql2 = "DELETE FROM COURSES WHERE TEACHER_ID = @id";

                using SqlCommand command1 = new SqlCommand(sql1, conn);
                using SqlCommand command2 = new SqlCommand(sql2, conn);

                command1.Parameters.AddWithValue("@id", id);
                command2.Parameters.AddWithValue("@id", id);

                command1.ExecuteNonQuery();
                command2.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }
    }
}
