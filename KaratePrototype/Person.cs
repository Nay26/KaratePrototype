using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaratePrototype
{
    class Person
    {

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IGender Gender { get; set; }
        public string Nationality { get; set; }
        public double Height { get; set; }

        public Person(Random rnd)
        {
           
            GenerateGender(rnd);
            GenerateName(rnd);
            GenerateNationality(rnd);
            GenerateDateOfBirth(rnd);
            GenerateHeight(rnd);
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

    }
}
