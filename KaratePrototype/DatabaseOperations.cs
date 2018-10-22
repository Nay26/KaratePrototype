using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml;

namespace KaratePrototype
{
    class DatabaseOperations
    {
        public static string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\naomi\source\repos\KaratePrototype\KaratePrototype\KaratePrototype.mdf;Integrated Security=True";
        public SqlCommand myCommand;
        public SqlConnection conn;
        public List<University> Universities = new List<University>();
        public List<Person> People = new List<Person>();

        public DatabaseOperations()
        {
            myCommand = new SqlCommand();
            conn = new SqlConnection();
            conn.ConnectionString = connectionString;
        }

        public void LoadDatabaseData()
        {
            LoadUniversities();
            LoadPeople();
        }

        public void LoadPeople()
        {
            People.Clear();
            string query = "SELECT * FROM People";
            string tempGender;
            conn.Open();
            try
            {
                myCommand = new SqlCommand(query, conn);
                SqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    Person person = new Person();
                    person.ID = reader.GetInt32(0);
                    person.UniversityID = reader.GetInt32(1);
                    person.FirstName = reader.GetString(2);
                    person.SecondName = reader.GetString(3);
                    person.Nationality = reader.GetString(4);
                    person.Height = reader.GetDouble(5);
                    person.DateOfBirth = reader.GetDateTime(6);
                    tempGender = reader.GetString(7);
                    switch (tempGender)
                    {
                        case "Male":
                            person.Gender = new Male();
                            break;
                        case "Female":
                            person.Gender = new Female();
                            break;
                        case "Non Binary":
                            person.Gender = new NonBinary();
                            break;
                        default:
                            person.Gender = new NonBinary();
                            break;
                    }
                    People.Add(person);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            conn.Close();
        }

        public void LoadUniversities()
        {
            Universities.Clear();
            string query = "SELECT * FROM Universities";
            conn.Open();
            try
            {
                myCommand = new SqlCommand(query, conn);
                SqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    University university = new University();
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

        }

        public void InsertUniversityXmlData()
        {
            string name = "";
            string location = "";
            int reputation = 0;
            string budget = "";
            string logo = "";
            int points = 0;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            XmlDocument xml = new XmlDocument();
            xml.Load(@".\UniversitiesXML.xml");
            XmlNodeList reminders = xml.SelectNodes("//University");
            foreach (XmlNode reminder in reminders)
            {
                name = (reminder.SelectSingleNode("name").InnerText);
                location = (reminder.SelectSingleNode("location").InnerText);
                reputation = Int32.Parse(reminder.SelectSingleNode("reputation").InnerText);
                points = Int32.Parse(reminder.SelectSingleNode("bucspoints").InnerText);
                budget = (reminder.SelectSingleNode("budget").InnerText);
                logo = (reminder.SelectSingleNode("photopath").InnerText);
                try
                {
                    string query = "INSERT INTO Universities (UniversityName, UniversityLocation, UniversityReputation, UniversityBudget, UniversityLogo, UniversityBUCSPoints) VALUES (@name,@location,@reputation,@budget,@logo,@points);";
                    SqlCommand myCommand = new SqlCommand(query, conn);
                    myCommand.Parameters.AddWithValue("@name", name);
                    myCommand.Parameters.AddWithValue("@location", location);
                    myCommand.Parameters.AddWithValue("@reputation", reputation);
                    myCommand.Parameters.AddWithValue("@budget", budget);
                    myCommand.Parameters.AddWithValue("@logo", logo);
                    myCommand.Parameters.AddWithValue("@points", points);
                    myCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            conn.Close();
        }

        public void InsertPeople()
        {
            foreach (var person in People)
            {
                conn.Open();
                try
                {
                    string query = "INSERT INTO People (UniversityID, FirstName, SecondName, Nationality, Height, DateOfBirth, Gender) VALUES (@uniid, @firstname,@secondname,@nationality,@height,@dateofbirth,@gender);";
                    myCommand = new SqlCommand(query, conn);
                    myCommand.Parameters.AddWithValue("@uniid", person.UniversityID);
                    myCommand.Parameters.AddWithValue("@firstname", person.FirstName);
                    myCommand.Parameters.AddWithValue("@secondname", person.SecondName);
                    myCommand.Parameters.AddWithValue("@nationality", person.Nationality);
                    myCommand.Parameters.AddWithValue("@height", person.Height);
                    myCommand.Parameters.AddWithValue("@dateofbirth", person.DateOfBirth);
                    myCommand.Parameters.AddWithValue("@gender", person.Gender.LongGender);
                    myCommand.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                conn.Close();
            }
        }


    }

}
