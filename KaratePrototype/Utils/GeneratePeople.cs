using System;
using System.Collections.Generic;
using System.Drawing;

namespace KaratePrototype
{
    class GeneratePeople
    {
        DatabaseOperations databaseOperations;

        // On instantiation load the database operations object from the select university form.
        public GeneratePeople(DatabaseOperations dataOp)
        {
            databaseOperations = dataOp;
        }

        // The main method to populate all universities in the database with new generated people.
        public void PopulateUniversities()
        {
            List<int> universityIDList = new List<int>();
            List<int> universityReputationList = new List<int>();
            foreach (var uni in databaseOperations.Universities)
            {
                universityIDList.Add(uni.ID);
                universityReputationList.Add(uni.Reputation);
            }
            Random rnd = new Random();
            List<Person> uniPeopleList = new List<Person>();
            List<Person> allPeopleList = new List<Person>();
            for (int i = 0; i < universityIDList.Count; i++)
            {
                uniPeopleList =  GeneratePeopleList(universityIDList[i],universityReputationList[i],rnd);
                allPeopleList.AddRange(uniPeopleList);
            }
            databaseOperations.People = allPeopleList;
            databaseOperations.InsertPeople();
            databaseOperations.LoadPeople();
        }

        // For the university asociated with the university ID, Add a number(GenerateNumberOfPeople()) of new people who go to that uni..
        private List<Person> GeneratePeopleList(int uniID, int uniRep, Random rnd)
        {
            List<Person> peopleList = new List<Person>();        
            int numberToGen = GenerateNumberOfPeople(uniRep);
            for (int i = 0; i < numberToGen; i++)
            {
                Person person = new Person(rnd);
                person.UniversityID = uniID;
                peopleList.Add(person);      
            }         
            return peopleList;
        }

        // Use the universities reputation to generate an integer amount of new people based on that reputation.
        private int GenerateNumberOfPeople(int uniRep)
        {
            int num = 25 + uniRep;
            return num;
        }

        // Generates face images for all people in the database assosiated with given UniversityID.
        public void GenerateFaces(int uniid, Random rnd, ImageCombiner combiner)
        {
            List<int> peopleIDList = new List<int>();
            foreach (var person in databaseOperations.People)
            {
                if (person.UniversityID == uniid)
                {
                    peopleIDList.Add(person.ID);
                }
            }
            foreach (var personid in peopleIDList)
            {
                combiner.SelectRandomImageFromDirectories(rnd,personid);                         
            }
            peopleIDList.Clear();
            peopleIDList.TrimExcess();
        }
    }
}
