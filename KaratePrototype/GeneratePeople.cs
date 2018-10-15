using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaratePrototype
{
    class GeneratePeople
    {

        
        public void PopulateUniversities()
        {
            SqlCommand myCommand = new SqlCommand();
            List<int> universityIDList = new List<int>();
            List<int> universityReputationList = new List<int>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\naomi\source\repos\KaratePrototype\KaratePrototype\KaratePrototype.mdf;Integrated Security=True";
            conn.Open();
            try
            {
                string query = "SELECT UniversityID, UniversityReputation FROM Universities";
                myCommand = new SqlCommand(query, conn);
                SqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                        universityIDList.Add(reader.GetInt32(0));
                        universityReputationList.Add(reader.GetInt32(1));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            conn.Close();

            int uniid = 0;
            string firstname = "";
            string secondname = "";
            string nationality = "";
            double height;
            DateTime dateofbirth;
            string gender;
            conn.Open();
            // For every university in database
            Random rnd = new Random();
            List<Person> peopleList = new List<Person>();
            for (int i = 0; i < universityIDList.Count; i++)
            {
                // Add people list to that university
                peopleList =  GeneratePeopleList(universityIDList[i],universityReputationList[i],rnd);
                for (int j = 0; j < peopleList.Count; j++)
                {
                    firstname = peopleList[j].FirstName;
                    secondname = peopleList[j].SecondName;
                    nationality = peopleList[j].Nationality;
                    height = peopleList[j].Height;
                    dateofbirth = peopleList[j].DateOfBirth;
                    gender = peopleList[j].Gender.LongGender;
                    uniid = universityIDList[i];

                    try
                    {
                        string query = "INSERT INTO People (UniversityID, FirstName, SecondName, Nationality, Height, DateOfBirth, Gender) VALUES (@uniid, @firstname,@secondname,@nationality,@height,@dateofbirth,@gender);";
                        myCommand = new SqlCommand(query, conn);
                        myCommand.Parameters.AddWithValue("@uniid", uniid);
                        myCommand.Parameters.AddWithValue("@firstname", firstname);
                        myCommand.Parameters.AddWithValue("@secondname", secondname);
                        myCommand.Parameters.AddWithValue("@nationality", nationality);
                        myCommand.Parameters.AddWithValue("@height", height);
                        myCommand.Parameters.AddWithValue("@dateofbirth", dateofbirth);
                        myCommand.Parameters.AddWithValue("@gender", gender);
                        myCommand.ExecuteNonQuery();
                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                 
                }              
            }
            conn.Close();
            Console.WriteLine("People Generated");

        }

        private List<Person> GeneratePeopleList(int uniID, int uniRep, Random rnd)
        {
            List<Person> peopleList = new List<Person>();        
            int numberToGen = GenerateNumberOfPeople(uniID, uniRep);
            for (int i = 0; i < numberToGen; i++)
            {
  
                Person person = new Person(rnd);       
                peopleList.Add(person);      
            }         
            return peopleList;
        }

        private int GenerateNumberOfPeople(int uniID, int uniRep)        
        {
            int num = 25 + uniRep;
            return num;
        }
        
        public void GenerateFaces()
        {
            //Read uni id of player

            //Get all students with that uni id
            Random rnd = new Random();
            int outputFileName=1;
            List<Image> imageLayerList = new List<Image>() ;
            ImageCombiner combiner = new ImageCombiner();
            RandomFileGrabber grabber = new RandomFileGrabber();

            //For Each Student
            imageLayerList = grabber.SelectRandomImageFromDirectories(rnd);           
            Bitmap faceImage = combiner.MergeImageLayers(imageLayerList);
            combiner.SaveImage(faceImage, outputFileName);

        }
    }
}
