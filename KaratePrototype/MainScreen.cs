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
        University PlayerUniversity;
        DatabaseOperations databaseOperations = new DatabaseOperations();

        // FirstTime Load
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
            dateLabel.Text = DateTime.Today.ToString("D");
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

            List<string> peopleNameList = new List<string>();
            foreach (var person in databaseOperations.People)
            {
                if (person.UniversityID == universityID)
                {
                    peopleNameList.Add(person.FirstName + " " + person.SecondName);
                }
            }

            peopleListBox.DataSource = peopleNameList;

        }
    }
}
