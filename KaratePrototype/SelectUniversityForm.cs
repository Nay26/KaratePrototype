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
        public string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\naomi\source\repos\KaratePrototype\KaratePrototype\KaratePrototype.mdf;Integrated Security=True";
        DatabaseOperations databaseOperations = new DatabaseOperations();

        public SelectUniversityForm()
        {
            InitializeComponent();
            databaseOperations.InsertUniversityXmlData();
            databaseOperations.LoadUniversities();
            PopulateUniversityListbox();
        }

        private void PopulateUniversityListbox()
        {
            List<string> uniList = new List<string>();
            foreach (University uni in databaseOperations.Universities)
            {
                uniList.Add(uni.Name);
            }
            uniList.Sort();
            universityListBox.DataSource = uniList;
        }
       
        // Change this at some point depending on if want to store the uni description in the database.
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
            GeneratePeople generatePeople = new GeneratePeople(databaseOperations);
            generatePeople.PopulateUniversities();
            foreach (var uni in databaseOperations.Universities)
            {
                Console.WriteLine("Generating Faces for " +  uni.Name);
                generatePeople.GenerateFaces(uni.ID);
            }
            Console.WriteLine("Finished Generating Faces");
            generatePeople.GenerateKaratekaList();
            GoToMainScreen();

        }

        public void GoToMainScreen()
        {

            MainScreen main = new MainScreen();
            main.Show();
            main.Left = this.Left;
            main.Top = this.Top;
            this.Hide();
        }

        private void SelectPlayerUniversity()
        {
            string name = universityNameLabel.Text;
            string uniLogoString = "";
            foreach (var uni in databaseOperations.Universities)
            {
                if (uni.Name.Equals(name))
                {
                    uniLogoString = uni.Logo;
                    UniversityID = uni.ID;
                    break;
                }
            }
            using (StreamWriter outputFile = new StreamWriter(@".\University.txt"))
            {
                outputFile.WriteLine(UniversityID);
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Cleanup.CleanFilesAndDB();
            Application.Exit();
        }
        
    }
        
}
