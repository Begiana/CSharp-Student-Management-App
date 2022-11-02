using System.Data.SqlClient;

namespace StudentsManagementApp.DAO.DBUtil
{
    public class DBHelper
    {
        private static SqlConnection? conn;

        //No instances of this class available .U T I L I T Y   C L A S S 
        private DBHelper() { }

        public static SqlConnection? GetConnection()
        {
            try
            {
                ConfigurationManager configurationManager = new();
                configurationManager.AddJsonFile("appsettings.json");
                string url = configurationManager.GetConnectionString("DefaultConnection");
                //string url = "Data Source=localhost\\sqlexpress;Initial Catalog=SevDB;Integrated Security=True";
                conn = new SqlConnection(url);
                return conn;
            }
            catch ( Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        public static void CloseConnection()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
    }
}
