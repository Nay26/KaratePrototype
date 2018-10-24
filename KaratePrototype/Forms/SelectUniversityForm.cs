using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace KaratePrototype
{
    public partial class SelectUniversityForm : Form
    {
        // Always need a database operations object on all forms.
        public int UniversityID;
        DatabaseOperations databaseOperations = new DatabaseOperations();

        // Initialisation ( Insert university info to Database then Load that info from the database with the generated ID's).
        public SelectUniversityForm()
        {
            InitializeComponent();
            databaseOperations.InsertUniversityXmlData();
            databaseOperations.LoadUniversities();
            PopulateUniversityListbox();
        }

        // Use the list of universities (From database operations object) to populate the listbox with the university names.
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
       
        // When the user selects an option from the listbox, Load the university information from the xml file (because uni description not stroed in database)
        // Output this information into the right hand uni details section of the form.
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

        // When the start button is clicked, save the users selected university to a textfile,
        // Generate people for all universities, generate face images for those people,
        // Load the main form.
        private void startButton_Click(object sender, EventArgs e)
        {
            SelectPlayerUniversity();
            GeneratePeople generatePeople = new GeneratePeople(databaseOperations);
            ImageCombiner combiner = new ImageCombiner();
            Random rnd = new Random();
            //generatePeople.PopulateUniversities();
            //foreach (var uni in databaseOperations.Universities)
            //{
            //    Console.WriteLine("Generating Faces for " + uni.Name);
            //    generatePeople.GenerateFaces(uni.ID, rnd, combiner);
            //}
            generatePeople.GenerateFaces(UniversityID, rnd, combiner);
            GoToMainScreen();

        }

        // Gets the university name from the currently selected option in the listbox and saves to a textfile.
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

        // Replaces current form with the main form.
        public void GoToMainScreen()
        {

            MainScreen main = new MainScreen();
            main.Show();
            main.Left = this.Left;
            main.Top = this.Top;
            this.Hide();
        }

        // Runs the database and folder cleanup (for testing) and quits the application.
        private void quitButton_Click(object sender, EventArgs e)
        {
            Cleanup.CleanFilesAndDB();
            Application.Exit();
        }
        
    }
        
}
