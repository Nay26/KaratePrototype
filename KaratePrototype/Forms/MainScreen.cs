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
        int kihonTrainingValue = 0;
        int kataTrainingValue = 0;
        int kumiteTrainingValue = 0;
        int TrainingPointsRemaining = 200;
        bool[] TrainingDates = new bool[7];

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
            WriteBirthdays();
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
            
            Calendar.SetDate(currentDate);
            Calendar.TodayDate = currentDate;
            Calendar.Update();
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
            personOverallRatingLabel.Text = SelectedPerson.GetOverallRating().ToString();

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
            personCoordinationLabel.Text = SelectedPerson.Coordination.Level.ToString();
            personPrecisionLabel.Text = SelectedPerson.Precision.Level.ToString();
            personMentalLabel.Text = SelectedPerson.Mental.Level.ToString();
            personPotentialLabel.Text = SelectedPerson.Potential.Level.ToString();
            personKataLabel.Text = SelectedPerson.Kata.Level.ToString();
            personKumiteLabel.Text = SelectedPerson.Kumite.Level.ToString();
            personKihonLabel.Text = SelectedPerson.Kihon.Level.ToString();
            personPunchingLabel.Text = SelectedPerson.Punching.Level.ToString();
            personKickingLabel.Text = SelectedPerson.Kicking.Level.ToString();
            personDefenseLabel.Text = SelectedPerson.Defense.Level.ToString();
            personLearningRateLabel.Text = SelectedPerson.LearningRate.ToString();
            personKarateIQLabel.Text = SelectedPerson.KarateIQ.Level.ToString();
            personBMILabel.Text = SelectedPerson.BMI.ToString();
            personWeightLabel.Text = SelectedPerson.Weight.ToString();

        }



        //++++++++++++++++ GOING TO NEXT DAY +++++++++++++++++++++++

        // When the next day button is clicked, change the current date to that date.
        private void nextDayButton_Click(object sender, EventArgs e)
        {
            SimulateDay();
            currentDate = currentDate.AddDays(1);
            SetDate();
            WriteBirthdays();
        }

        private void WriteBirthdays()
        {
            infoTextBox.Clear();
            foreach (var person in databaseOperations.People)
            {
                if (person.DateOfBirth.DayOfYear == currentDate.DayOfYear)
                {
                    infoTextBox.AppendText("It is " + person.FirstName + " " + person.SecondName + "s birthday today! Be sure to wish " + person.Gender.Objective + " a Happy Birthday! \n");
                }
            }
        }

        // Day simulation
        private void SimulateDay()
        {
            bool canTrain = false;
            switch (currentDate.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    if (TrainingDates[0] == true)
                    {
                        canTrain = true;
                    }
                    break;
                case DayOfWeek.Tuesday:
                    if (TrainingDates[1] == true)
                    {
                        canTrain = true;
                    }
                    break;
                case DayOfWeek.Wednesday:
                    if (TrainingDates[2] == true)
                    {
                        canTrain = true;
                    }
                    break;
                case DayOfWeek.Thursday:
                    if (TrainingDates[3] == true)
                    {
                        canTrain = true;
                    }
                    break;
                case DayOfWeek.Friday:
                    if (TrainingDates[4] == true)
                    {
                        canTrain = true;
                    }
                    break;
                case DayOfWeek.Saturday:
                    if (TrainingDates[5] == true)
                    {
                        canTrain = true;
                    }
                    break;
                case DayOfWeek.Sunday:
                    if (TrainingDates[6] == true)
                    {
                        canTrain = true;
                    }
                    break;
                default:
                    canTrain = false;
                    break;
            }

            if (canTrain == true)
            {
                Random rnd = new Random();
                foreach (var person in databaseOperations.People)
                {
                    SimulateTraining(person, rnd);
                }
                //databaseOperations.UpdatePeople();
                UpdateSelectedPeopleList();
                UpdatePersonInfo();
            }
            
        }

        // Training simulation
        private void SimulateTraining(Person person, Random rnd)
        {
            int increment = 0;
            increment = rnd.Next(-50,50);
            person.Speed.AddXP(kihonTrainingValue+increment);
            person.Power.AddXP(kataTrainingValue+increment);
            person.Stamina.AddXP(kumiteTrainingValue + increment);
            person.Coordination.AddXP(kihonTrainingValue + increment);
            person.Precision.AddXP(kataTrainingValue + increment);
            person.Mental.AddXP(kihonTrainingValue + increment);
            person.KarateIQ.AddXP(kihonTrainingValue + increment);
            person.Kata.AddXP(kataTrainingValue + increment);
            person.Kumite.AddXP(kumiteTrainingValue + increment);
            person.Kihon.AddXP(kihonTrainingValue + increment);
            person.Punching.AddXP(kumiteTrainingValue + increment);
            person.Kicking.AddXP(kumiteTrainingValue + increment);
            person.Defense.AddXP(kumiteTrainingValue + increment);
        }



        //+++++++++++++++++ Training Sliders ++++++++++++++++++++++++++++++++++++++

        private void speedTrainingTrackBar_Scroll(object sender, EventArgs e)
        {
            TrackBar trackbar = kihonTrainingTrackBar;
            Label trainingLabel = kihonTrainingNumberLabel;
            kihonTrainingValue = UpdateTrainingTrackBars(trackbar,trainingLabel,kihonTrainingValue);
        }

        private void powerTrainingTrackBar_Scroll(object sender, EventArgs e)
        {
            TrackBar trackbar = kataTrainingTrackBar;
            Label trainingLabel = kataTrainingNumberLabel;
            kataTrainingValue = UpdateTrainingTrackBars(trackbar, trainingLabel, kataTrainingValue);
        }

        private void staminaTrainingTrackBar_Scroll(object sender, EventArgs e)
        {
            TrackBar trackbar = kumiteTrainingTrackBar;
            Label trainingLabel = kumiteTrainingNumberLabel;
            kumiteTrainingValue = UpdateTrainingTrackBars(trackbar, trainingLabel, kumiteTrainingValue);
        }

        private int UpdateTrainingTrackBars(TrackBar trackbar, Label label,int prevvalue)
        {
            int difference = 0;
            int maxMovement = prevvalue + TrainingPointsRemaining;
            
            if (trackbar.Value > maxMovement)
            {
                trackbar.Value = (prevvalue);
            }
            
            difference = prevvalue - trackbar.Value;
            TrainingPointsRemaining = TrainingPointsRemaining + difference;

            trainingPointsNumberLabel.Text = TrainingPointsRemaining.ToString();
            label.Text = trackbar.Value.ToString();
            return trackbar.Value;
        }



        //+++++++++++++++++++ Training Dates +++++++++++++++++++++++++++++++
        private void mondayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TrainingDates[0] = mondayCheckBox.Checked;
        }

        private void tuesdayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TrainingDates[1] = tuesdayCheckBox.Checked;
        }

        private void wednesdayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TrainingDates[2] = wednesdayCheckBox.Checked;
        }

        private void thursdayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TrainingDates[3] = thursdayCheckBox.Checked;
        }

        private void fridayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TrainingDates[4] = fridayCheckBox.Checked;
        }

        private void saturdayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TrainingDates[5] = saturdayCheckBox.Checked;
        }

        private void sundayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TrainingDates[6] = sundayCheckBox.Checked;
        }
    }
}
