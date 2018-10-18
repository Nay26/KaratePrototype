using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace KaratePrototype
{
    public partial class MainScreen : Form
    {
        public int UniversityID;
        public string UniversityName;
        public string UniversityLogo;
        public string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\naomi\source\repos\KaratePrototype\KaratePrototype\KaratePrototype.mdf;Integrated Security=True";
        public MainScreen()
        {
            InitializeComponent();
            RetrivePlayerUniversityInfo();
            PopulateUniversityComboBox();
            LoadUniversityImage();
            LoadUniversityName();
            SetDate();
        }

        private void SetDate()
        {
            dateLabel.Text = DateTime.Today.ToString("D");
        }

        private void LoadUniversityName()
        {
            universityNameLabel.Text = UniversityName;
        }

        private void LoadUniversityImage()
        {
            universityLogoPictureBox.ImageLocation = (@".\UniversityLogos\" + UniversityLogo + ".png");
            universityLogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void RetrivePlayerUniversityInfo()
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(@".\University.txt");
            line = file.ReadLine();
            UniversityID = Int32.Parse(line);
            UniversityName = file.ReadLine(); 
            UniversityLogo = file.ReadLine(); ;
            file.Close();

        }

        private void PopulateUniversityComboBox()
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
            universityComboBox.DataSource = uniList;
            universityComboBox.SelectedIndex = universityComboBox.FindStringExact(UniversityName);

        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Cleanup clean = new Cleanup();
            clean.CleanFilesAndDB();
            Application.Exit();
        }

        private void universityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            SqlCommand myCommand = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            List<string> peopleNameList = new List<string>();
            List<int> peopleIDList = new List<int>();     
            conn.ConnectionString = connectionString;
            conn.Open();
            string query = "SELECT People.PersonID, People.FirstName, People.SecondName FROM People INNER JOIN Universities ON People.UniversityID = Universities.UniversityID WHERE Universities.UniversityName = @uniname";
            myCommand = new SqlCommand(query, conn);
            myCommand.Parameters.AddWithValue("@uniname", universityComboBox.Text);
            SqlDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                peopleIDList.Add(reader.GetInt32(0));
                peopleNameList.Add(reader.GetString(1) + " " + reader.GetString(2));
            }
            conn.Close();
            peopleListBox.DataSource = peopleNameList;

        }
    }
}
