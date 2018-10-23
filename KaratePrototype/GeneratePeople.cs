using System;
using System.Collections.Generic;
using System.Drawing;

namespace KaratePrototype
{
    class GeneratePeople
    {
        public string connectionString;
        DatabaseOperations databaseOperations;

        public GeneratePeople(DatabaseOperations dataOp)
        {
            databaseOperations = dataOp;
            connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\naomi\source\repos\KaratePrototype\KaratePrototype\KaratePrototype.mdf;Integrated Security=True";
        }

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

        private List<Person> GeneratePeopleList(int uniID, int uniRep, Random rnd)
        {
            List<Person> peopleList = new List<Person>();        
            int numberToGen = GenerateNumberOfPeople(uniID, uniRep);
            for (int i = 0; i < numberToGen; i++)
            {
                Person person = new Person(rnd);
                person.UniversityID = uniID;
                peopleList.Add(person);      
            }         
            return peopleList;
        }

        private int GenerateNumberOfPeople(int uniID, int uniRep)        
        {
            int num = 25 + uniRep;
            return num;
        }
        
        public void GenerateFaces(int uniid)
        {
            List<int> peopleIDList = new List<int>();
            foreach (var person in databaseOperations.People)
            {
                if (person.UniversityID == uniid)
                {
                    peopleIDList.Add(person.ID);
                }
            }

            Random rnd = new Random();            
            List<Image> imageLayerList = new List<Image>() ;
            ImageCombiner combiner = new ImageCombiner();
            RandomFileGrabber grabber = new RandomFileGrabber();

            foreach (var personid in peopleIDList)
            {
                imageLayerList = grabber.SelectRandomImageFromDirectories(rnd);
                Bitmap faceImage = combiner.MergeImageLayers(imageLayerList);
                combiner.SaveImage(faceImage, personid);
                faceImage.Dispose();
            }
            imageLayerList.Clear();
            imageLayerList.TrimExcess();

        }

        public void GenerateKaratekaList()
        {
            Random rnd = new Random();
            foreach (var person in databaseOperations.People)
            {
                Karateka karateka = new Karateka(rnd);
                karateka.PersonID = person.ID;
                karateka.UniversityID = person.UniversityID;
                databaseOperations.Karatekas.Add(karateka);
            }
            databaseOperations.InsertKaratekas();
            databaseOperations.LoadKaratekas();
        }

        public void GeneratePrimaryStatBlockList()
        {
            IGrade grade = new WhiteBelt() ;
            Random rnd = new Random();
            foreach (var person in databaseOperations.People)
            {
                foreach (var karateka in databaseOperations.Karatekas)
                {
                    if (karateka.PersonID == person.ID)
                    {
                        grade = karateka.Grade;
                    }
                }
                PrimaryStatBlock primaryStatBlock = new PrimaryStatBlock(rnd,grade);
                primaryStatBlock.PersonID = person.ID;
                databaseOperations.PrimaryStatBlocks.Add(primaryStatBlock);
            }
            databaseOperations.InsertPrimaryStatBlocks();
            databaseOperations.LoadPrimaryStatBlocks();
        }
    }
}
