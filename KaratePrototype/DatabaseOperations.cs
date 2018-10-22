using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaratePrototype
{
    class DatabaseOperations
    {
        public static string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\naomi\source\repos\KaratePrototype\KaratePrototype\KaratePrototype.mdf;Integrated Security=True";
        public SqlCommand myCommand;
        public SqlConnection conn;
        public List<University> Universities = new List<University>();

        public DatabaseOperations()
        {
            myCommand = new SqlCommand();
            conn = new SqlConnection();
            conn.ConnectionString = connectionString;
        }

        public void LoadDatabaseData()
        {
            LoadUniversities();
        }

        public void LoadUniversities()
        {
            University university = new University();
            string query = "SELECT * FROM Universities";
            conn.Open();
            try
            {
                myCommand = new SqlCommand(query, conn);
                SqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    university.ID = reader.GetInt32(0);
                    university.Name = reader.GetString(1);
                    university.Location = reader.GetString(2);
                    university.Reputation = reader.GetInt32(3);
                    university.Budget = reader.GetString(4);
                    university.Logo = reader.GetString(5);
                    university.BucsPoints = reader.GetInt32(6);
                    Universities.Add(university);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            conn.Close();

            Universities.Add(university);

        }
    }

}
