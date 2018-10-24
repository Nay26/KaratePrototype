using System;

namespace KaratePrototype
{
    class Person
    {
        // Base information (Won't change)
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IGender Gender { get; set; }
        public string Nationality { get; set; }
        public double Height { get; set; }
        public int UniversityID { get; set; }

        // Karate details
        public IGrade Grade { get; set; }
        public DateTime StartDate { get; set; }

        // Statistics
        public Statistic Speed { get; set; }
        public Statistic Power { get; set; }
        public Statistic Stamina { get; set; }

        public Person()
        {
            Speed = new Statistic();
            Power = new Statistic();
            Stamina = new Statistic();
        }

        public Person(Random rnd) : this()
        {
          
            GenerateGender(rnd);
            GenerateName(rnd);
            GenerateNationality(rnd);
            GenerateDateOfBirth(rnd);
            GenerateHeight(rnd);
            Grade = GetRandomGrade(rnd);
            StartDate = DateTime.Today;
            GenerateStats(rnd);
        }


        private void GenerateGender(Random rnd)
        {
            
            int genderPicker = rnd.Next(99);
            if (genderPicker < 49)
            {
                Gender = new Male();
            }
            else if (genderPicker < 98)
            {
                Gender = new Female();
            }
            else
            {
                Gender = new NonBinary();
            }

        }

        public void GenerateName(Random rnd)
        {
            string textFilePath = Gender.TextFilePath;
            string[] linesFirstName = System.IO.File.ReadAllLines(textFilePath);
            int count = linesFirstName.Length;
            int randomNumber = rnd.Next(1, count);
            FirstName = linesFirstName[randomNumber];

            textFilePath = @".\SecondNames.txt";
            string[] linesSecondName = System.IO.File.ReadAllLines(textFilePath);
            count = linesSecondName.Length;
            randomNumber = rnd.Next(1, count);
            SecondName = linesSecondName[randomNumber];
        }

        public void GenerateNationality(Random rnd)
        {
            string fileLocation = "";
            int countryPicker = rnd.Next(99);
            if (countryPicker < 90)
            {
                fileLocation = @".\British.txt";
            }
            else
            {
                fileLocation = @".\Nationalities.txt";
            }

            string[] linesInFile = System.IO.File.ReadAllLines(fileLocation);
            int count = 0;
            foreach (string line in linesInFile)
            {
                count++;
            }
            int randomNumber = rnd.Next(1, count);
            Nationality = linesInFile[randomNumber];
            if (countryPicker < 70)
            {
                Nationality = "British";
            }
        }

        public void GenerateDateOfBirth(Random rnd)
        {
            DateOfBirth = RandomDay(rnd);
        }

        DateTime RandomDay(Random rnd)
        {
            DateTime start = new DateTime(1998, 1, 1);
            DateTime end = new DateTime(2000, 1, 1);
            int range = (end - start).Days;
            return start.AddDays(rnd.Next(range));
        }
      
        public void GenerateHeight(Random rnd)
        {
            if (Gender.LongGender.Equals("Male"))
            {
                Height = 177.8;
            }
            else
            {
                Height = 164.4;
            }

        }

        private IGrade GetRandomGrade(Random rnd)
        {
            IGrade grade = new WhiteBelt();
            int roll = rnd.Next(0, 100);
            if (roll < 25)
            {
                grade = new WhiteBelt();
            }
            else if (roll < 30)
            {
                grade = new OrangeBelt();
            }
            else if (roll < 35)
            {
                grade = new RedBelt();
            }
            else if (roll < 40)
            {
                grade = new YellowBelt();
            }
            else if (roll < 45)
            {
                grade = new GreenBelt();
            }
            else
            {
                grade = new WhiteBelt();
            }
            return grade;
        }

        private void GenerateStats(Random rnd)
        {
            int average = Grade.AverageStat;
            int difference = 5;
            Speed.Level = rnd.Next(average - difference, average + difference);
            Power.Level = rnd.Next(average - difference, average + difference);
            Stamina.Level = rnd.Next(average - difference, average + difference);
        }
    }
}
