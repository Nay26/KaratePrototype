using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml;

namespace KaratePrototype
{
    class DatabaseOperations
    {
        // The lists declared here are global representations of the database data.
        public static string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\naomi\source\repos\KaratePrototype\KaratePrototype\KaratePrototype.mdf;Integrated Security=True";
        public SqlCommand myCommand;
        public SqlConnection conn;
        public List<University> Universities = new List<University>();
        public List<Person> People = new List<Person>();

        // Set up the connection objects.
        public DatabaseOperations()
        {
            myCommand = new SqlCommand();
            conn = new SqlConnection();
            conn.ConnectionString = connectionString;
        }

        // Runs the load methods for each table to fully load the database.
        public void LoadDatabaseData()
        {
            LoadUniversities();
            LoadPeople();
        }

        // Selects all people from the People table and stores the data into the global people list.
        public void LoadPeople()
        {
            People.Clear();
            string query = "SELECT * FROM People";
            string tempGender;
            string tempGrade;
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
                    tempGrade = reader.GetString(8);
                    switch (tempGrade)
                    {
                        case "10th Kyu":
                            person.Grade = new TenthKyu();
                            break;
                        case "9th Kyu":
                            person.Grade = new NinthKyu();
                            break;
                        case "8th Kyu":
                            person.Grade = new EightKyu();
                            break;
                        case "7th Kyu":
                            person.Grade = new SeventhKyu();
                            break;
                        case "6th Kyu":
                            person.Grade = new SixthKyu();
                            break;
                        case "5th Kyu":
                            person.Grade = new FifthKyu();
                            break;
                        case "4th Kyu":
                            person.Grade = new FourthKyu();
                            break;
                        case "3rd Kyu":
                            person.Grade = new ThirdKyu();
                            break;
                        case "2nd Kyu":
                            person.Grade = new SecondKyu();
                            break;
                        case "1st Kyu":
                            person.Grade = new FirstKyu();
                            break;
                        case "1st Dan":
                            person.Grade = new FirstDan();
                            break;
                        case "2nd Dan":
                            person.Grade = new SecondDan();
                            break;
                        case "3rd Dan":
                            person.Grade = new ThirdDan();
                            break;
                        case "4th Dan":
                            person.Grade = new FourthDan();
                            break;
                        default:
                            person.Grade = new TenthKyu();
                            break;
                    }
                    person.StartDate = reader.GetDateTime(9);
                    person.Speed.Experiance = reader.GetDouble(10);
                    person.Power.Experiance = reader.GetDouble(11);
                    person.Stamina.Experiance = reader.GetDouble(12);
                    People.Add(person);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            conn.Close();
        }

        // Selects all universities from the Universites table and stores the data into the global people list.
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

        // Uses the XML university data file to intially populate the Universities table in the database.
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

        // Takes the global People list and Inserts it into the People table in the database.
        public void InsertPeople()
        {
            conn.Open();
            foreach (var person in People)
            { 
                try
                {
                    string query = "INSERT INTO People (UniversityID, FirstName, SecondName, Nationality, Height, DateOfBirth, Gender, Grade, StartDate,Speed,Power,Stamina) VALUES (@uniid, @firstname, @secondname, @nationality, @height, @dateofbirth, @gender, @grade, @startdate, @speed, @power, @stamina);";
                    myCommand = new SqlCommand(query, conn);
                    myCommand.Parameters.AddWithValue("@uniid", person.UniversityID);
                    myCommand.Parameters.AddWithValue("@firstname", person.FirstName);
                    myCommand.Parameters.AddWithValue("@secondname", person.SecondName);
                    myCommand.Parameters.AddWithValue("@nationality", person.Nationality);
                    myCommand.Parameters.AddWithValue("@height", person.Height);
                    myCommand.Parameters.AddWithValue("@dateofbirth", person.DateOfBirth);
                    myCommand.Parameters.AddWithValue("@gender", person.Gender.LongGender);
                    myCommand.Parameters.AddWithValue("@grade", person.Grade.GradeName);
                    myCommand.Parameters.AddWithValue("@startdate", person.StartDate);
                    myCommand.Parameters.AddWithValue("@speed", person.Speed.Experiance);
                    myCommand.Parameters.AddWithValue("@power", person.Power.Experiance);
                    myCommand.Parameters.AddWithValue("@stamina", person.Stamina.Experiance);
                    myCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
              
            }
            conn.Close();
        }

        public void UpdatePeople()
        {
            conn.Open();
            foreach (var person in People)
            {
                try
                {
                    string query = "UPDATE People SET UniversityID = @uniid, FirstName = @firstname, SecondName=@secondname, Nationality=@nationality, Height=@height, DateOfBirth=@dateofbirth, Gender=@gender, Grade=@grade, StartDate=@startdate,Speed=@speed,Power=@power,Stamina=@stamina WHERE PersonID = @personid;";
                    myCommand = new SqlCommand(query, conn);
                    myCommand.Parameters.AddWithValue("@personid", person.ID);
                    myCommand.Parameters.AddWithValue("@uniid", person.UniversityID);
                    myCommand.Parameters.AddWithValue("@firstname", person.FirstName);
                    myCommand.Parameters.AddWithValue("@secondname", person.SecondName);
                    myCommand.Parameters.AddWithValue("@nationality", person.Nationality);
                    myCommand.Parameters.AddWithValue("@height", person.Height);
                    myCommand.Parameters.AddWithValue("@dateofbirth", person.DateOfBirth);
                    myCommand.Parameters.AddWithValue("@gender", person.Gender.LongGender);
                    myCommand.Parameters.AddWithValue("@grade", person.Grade.GradeName);
                    myCommand.Parameters.AddWithValue("@startdate", person.StartDate);
                    myCommand.Parameters.AddWithValue("@speed", person.Speed.Experiance);
                    myCommand.Parameters.AddWithValue("@power", person.Power.Experiance);
                    myCommand.Parameters.AddWithValue("@stamina", person.Stamina.Experiance);
                    myCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

            }
            conn.Close();
        }

    }

}
