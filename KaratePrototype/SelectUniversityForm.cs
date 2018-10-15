using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace KaratePrototype
{
    public partial class SelectUniversityForm : Form
    {

        public int UniversityID;

        public SelectUniversityForm()
        {
            InitializeComponent();
            PopulateUniversityListbox();
            PopulateUniversityDataBase();
            
        }

        private void PopulateUniversityListbox()
        {
      
            XmlDocument xml = new XmlDocument();
            xml.Load(@".\UniversitiesXML.xml");
            XmlNodeList reminders = xml.SelectNodes("//University");
            List<string> uniList = new List<string>();
            foreach (XmlNode reminder in reminders)
            {
                uniList.Add(reminder.SelectSingleNode("name").InnerText);                                  
            }
            uniList.Sort();
            universityListBox.DataSource = uniList;
        }

        private void PopulateUniversityDataBase()
        {
            string name = "";
            string location = "";
            int reputation = 0;
            string budget = "";
            string logo = "";
            int points = 0;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\naomi\source\repos\KaratePrototype\KaratePrototype\KaratePrototype.mdf;Integrated Security=True";
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

        private void universityListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string universityName = universityListBox.Text;
            string logoFilePath = "";
            universityNameLabel.Text = universityName;
            XmlDocument xml = new XmlDocument();
            xml.Load(@".\UniversitiesXML.xml");
            XmlNodeList reminders = xml.SelectNodes("//University");
            foreach (XmlNode reminder in reminders)
            {
                if (reminder.SelectSingleNode("name").InnerText == universityName)
                {
                   universityReputationLabel.Text = reminder.SelectSingleNode("reputation").InnerText;
                   universityLocationLabel.Text = reminder.SelectSingleNode("location").InnerText;
                   aUBudgetLabel.Text = reminder.SelectSingleNode("budget").InnerText;
                   logoFilePath = reminder.SelectSingleNode("photopath").InnerText;
                   universityDescriptionTextBox.Text = reminder.SelectSingleNode("description").InnerText;
                   bucsPointsLabel.Text = reminder.SelectSingleNode("bucspoints").InnerText;
                   universityLogoPictureBox.ImageLocation = (@".\UniversityLogos\" + logoFilePath + ".png");              
                   universityLogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }  
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            SelectPlayerUniversity();
            GeneratePeople startGameGen = new GeneratePeople();
            startGameGen.PopulateUniversities();
            GoToMainScreen();

        }

        private void GoToMainScreen()
        {

            MainScreen main = new MainScreen();
            main.Show();
            this.Hide();
        }

        private void SelectPlayerUniversity()
        {
            string name = universityNameLabel.Text;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\naomi\source\repos\KaratePrototype\KaratePrototype\KaratePrototype.mdf;Integrated Security=True";
            conn.Open();
            try
            {
                string query = "SELECT UniversityID FROM Universities WHERE UniversityName = @name";
                SqlCommand myCommand = new SqlCommand(query, conn);
                myCommand.Parameters.AddWithValue("@name", name);
                using (SqlDataReader reader = myCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Console.WriteLine(String.Format("{0}", reader["UniversityID"]));
                        string uniIDString = String.Format("{0}", reader["UniversityID"]);
                        UniversityID = Int32.Parse(uniIDString);
                        File.WriteAllText(@".\University.txt", String.Format("{0}", reader["UniversityID"]));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            conn.Close();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
    }
        
}
