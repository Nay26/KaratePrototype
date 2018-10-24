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


        //+++++++++++++++ INITIALISATION +++++++++++++++++++++++++

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



        //+++++++++++++++++ USER CONTROLS ++++++++++++++++++++++++

        // When a university is selected from the combo box, add all people from that university to the people listbox.
        private void universityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectedPeopleList();
        }

        // When person is selected from listbox, load that persons information into the form.
        private void peopleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePersonInfo();
        }

        // When the players university button is clicked, select that university from the combobox.
        private void selectPlayerUniversityButton_Click(object sender, EventArgs e)
        {
            universityComboBox.SelectedItem = PlayerUniversity.Name;
        }

        // Runs the cleanup process and quits the application.
        private void quitButton_Click(object sender, EventArgs e)
        {

            Cleanup.CleanFilesAndDB();
            Application.Exit();
        }



        //+++++++++++++++++++++ UPDATING DATA +++++++++++++++++++++++

        // Add all people from selected university to the people listbox, update selected people list
        private void UpdateSelectedPeopleList()
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

        // Load the currently selected persons information into the form.
        private void UpdatePersonInfo()
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
      


        //++++++++++++++++ GOING TO NEXT DAY +++++++++++++++++++++++

        // When the next day button is clicked, change the current date to that date.
        private void nextDayButton_Click(object sender, EventArgs e)
        {
            SimulateDay();
            currentDate = currentDate.AddDays(1);
            SetDate();
        }

        // Day simulation
        private void SimulateDay()
        {
            foreach (var person in databaseOperations.People)
            {
                SimulateTraining(person);
            }
            databaseOperations.UpdatePeople();
            UpdateSelectedPeopleList();
            UpdatePersonInfo();
        }

        // Training simulation
        private void SimulateTraining(Person person)
        {
            person.Speed.AddXP(100);
            person.Power.AddXP(100);
            person.Stamina.AddXP(100);
        }
    
    }
}
