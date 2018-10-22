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

        public MainScreen()
        {
            InitializeComponent();
            LoadData();
            RetrivePlayerUniversityInfo();
            PopulateUniversityComboBox();
            LoadUniversityImage();
            LoadUniversityName();
            SetDate();          
        }

        public void LoadData()
        {
            databaseOperations.LoadDatabaseData();
        }

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

        private void SetDate()
        {
            dateLabel.Text = currentDate.ToString("D");
        }

        private void LoadUniversityName()
        {
            universityNameLabel.Text = PlayerUniversity.Name;
        }

        private void LoadUniversityImage()
        {
            universityLogoPictureBox.ImageLocation = (@".\UniversityLogos\" + PlayerUniversity.Logo + ".png");
            universityLogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }        

        private void quitButton_Click(object sender, EventArgs e)
        {
            
            Cleanup.CleanFilesAndDB();
            Application.Exit();
        }

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

        private void peopleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int listIndex = peopleListBox.SelectedIndex;
            SelectedPerson = currentlySelectedUniversityPeople[listIndex];
            personFirstNameLabel.Text = SelectedPerson.FirstName;
            personSecondNameLabel.Text = SelectedPerson.SecondName;
            personNationalityLabel.Text = SelectedPerson.Nationality;
            personHeightLabel.Text = SelectedPerson.Height.ToString();
            personDobLabel.Text = SelectedPerson.DateOfBirth.ToString("dd/MM/yyyy");
            var today = DateTime.Today;
            var age = today.Year - SelectedPerson.DateOfBirth.Year;
            if (SelectedPerson.DateOfBirth > today.AddYears(-age)) age--;
            personAgeLabel.Text = age.ToString();
            personGenderLabel.Text = SelectedPerson.Gender.LongGender;
            personPictureBox.ImageLocation = (@".\Creation\CreatedImages\" + SelectedPerson.ID + ".png");
            personPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void nextDayButton_Click(object sender, EventArgs e)
        {
            currentDate = currentDate.AddDays(1);
            SetDate();
        }
    }
}
