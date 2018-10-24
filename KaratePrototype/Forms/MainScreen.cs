using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KaratePrototype
{
    public partial class MainScreen : Form
    {
        University PlayerUniversity;
        DatabaseOperations databaseOperations = new DatabaseOperations();
        List<Person> currentlySelectedUniversityPeople = new List<Person>();
        Person SelectedPerson = new Person();
        DateTime currentDate = DateTime.Today;

        // Initalise the main screen form.
        public MainScreen()
        {
            InitializeComponent();
            databaseOperations.LoadDatabaseData();
            RetrivePlayerUniversityInfo();
            PopulateFormItems();      
        }

        // Load the relevant information to all ui elements on the form.
        public void PopulateFormItems()
        {            
            PopulateUniversityComboBox();
            LoadUniversityImage();
            LoadUniversityName();
            SetDate();
        }

        // Gets the University ID of the university the player selected from the textfile.
        private void RetrivePlayerUniversityInfo()
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(@".\University.txt");
            line = file.ReadLine();
            int universityID = Int32.Parse(line);
            file.Close();
            foreach (var uni in databaseOperations.Universities)
            {
                if (uni.ID == universityID)
                {
                    PlayerUniversity = uni;
                    break;
                }
            }
        }

        // Populates the university combo box with the university names from the global Univrsities list.
        private void PopulateUniversityComboBox()
        {
            List<string> uniList = new List<string>();
            foreach (University uni in databaseOperations.Universities)
            {
                uniList.Add(uni.Name);
            }
            uniList.Sort();
            universityComboBox.DataSource = uniList;
            universityComboBox.SelectedIndex = universityComboBox.FindStringExact(PlayerUniversity.Name);
        }

        // Sets the date to current date.
        private void SetDate()
        {
            dateLabel.Text = currentDate.ToString("D");
        }

        // Sets the name on some ui elements to that of the players selected university.
        private void LoadUniversityName()
        {
            universityNameLabel.Text = PlayerUniversity.Name;
            selectPlayerUniversityButton.Text = PlayerUniversity.Name;
        }

        // Loads the logo of the players university into the picture box.
        private void LoadUniversityImage()
        {
            universityLogoPictureBox.ImageLocation = (@".\UniversityLogos\" + PlayerUniversity.Logo + ".png");
            universityLogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }        
       
        // When a university is selected fro the combo box, add all people from that university to the people listbox.
        private void universityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {         
            int universityID = 0;
            foreach (var uni in databaseOperations.Universities)
            {
                if (uni.Name.Equals(universityComboBox.Text))
                {
                    universityID = uni.ID;
                    break;
                }
            }
            currentlySelectedUniversityPeople.Clear();
            List<string> peopleNameList = new List<string>();
            foreach (var person in databaseOperations.People)
            {
                if (person.UniversityID == universityID)
                {
                    currentlySelectedUniversityPeople.Add(person);
                    peopleNameList.Add(person.FirstName + " " + person.SecondName);
                }
            }
            peopleListBox.DataSource = peopleNameList;
        }

        // When person is selected from listbox, load that persons information into the form.
        private void peopleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int listIndex = peopleListBox.SelectedIndex;
            SelectedPerson = currentlySelectedUniversityPeople[listIndex];

            personFullNameLabel.Text = SelectedPerson.FirstName + " " + SelectedPerson.SecondName;
            personPictureBox.ImageLocation = (@".\Creation\CreatedImages\" + SelectedPerson.ID + ".png");
            personPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            personNationalityLabel.Text = SelectedPerson.Nationality;
            personHeightLabel.Text = SelectedPerson.Height.ToString();
            personDobLabel.Text = SelectedPerson.DateOfBirth.ToString("dd/MM/yyyy");
            var today = DateTime.Today;
            var age = today.Year - SelectedPerson.DateOfBirth.Year;
            if (SelectedPerson.DateOfBirth > today.AddYears(-age)) age--;
            personAgeLabel.Text = age.ToString();
            personGenderLabel.Text = SelectedPerson.Gender.LongGender;

            personDateJoinedLabel.Text = SelectedPerson.StartDate.ToString("dd/MM/yyyy");
            personGradeaLabel.Text = SelectedPerson.Grade.GradeName;

            personSpeedLabel.Text = SelectedPerson.Speed.Level.ToString();
            personPowerLabel.Text = SelectedPerson.Power.Level.ToString();
            personStaminaLabel.Text = SelectedPerson.Stamina.Level.ToString();      
        }
       
        // When the players university button is clicked, select that university from the combobox.
        private void selectPlayerUniversityButton_Click(object sender, EventArgs e)
        {
            universityComboBox.SelectedItem = PlayerUniversity.Name;
        }

        // When the next day button is clicked, change the current date to that date.
        private void nextDayButton_Click(object sender, EventArgs e)
        {
            currentDate = currentDate.AddDays(1);
            SetDate();
        }

        // Runs the cleanup process and quits the application.
        private void quitButton_Click(object sender, EventArgs e)
        {

            Cleanup.CleanFilesAndDB();
            Application.Exit();
        }
    }
}
