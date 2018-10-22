namespace KaratePrototype
{

    public class Male : IGender
    {
        public string LongGender { get; set; }
        public string Nominative { get; set; }
        public string Objective { get; set; }
        public string PossesiveDeterminer { get; set; }
        public string PossesivePronoun { get; set; }
        public string Reflexive { get; set; }
        public string TextFilePath { get; set; }

        public Male()
        {
            LongGender = "Male";
            Nominative = "he";
            Objective = "him";
            PossesiveDeterminer = "his";
            PossesivePronoun = "his";
            Reflexive = "himself";
            TextFilePath = @".\FirstNamesBoys.txt";
        }
    }

    class Female : IGender
    {
        public string LongGender { get; set; }
        public string Nominative { get; set; }
        public string Objective { get; set; }
        public string PossesiveDeterminer { get; set; }
        public string PossesivePronoun { get; set; }
        public string Reflexive { get; set; }
        public string TextFilePath { get; set; }

        public Female()
        {
            LongGender = "Female";
            Nominative = "she";
            Objective = "her";
            PossesiveDeterminer = "her";
            PossesivePronoun = "hers";
            Reflexive = "herself";
            TextFilePath = @".\FirstNamesGirls.txt";
        }
    }
    class NonBinary : IGender
    {
        public string LongGender { get; set; }
        public string Nominative { get; set; }
        public string Objective { get; set; }
        public string PossesiveDeterminer { get; set; }
        public string PossesivePronoun { get; set; }
        public string Reflexive { get; set; }
        public string TextFilePath { get; set; }

        public NonBinary()
        {
            LongGender = "Non binary";
            Nominative = "they";
            Objective = "them";
            PossesiveDeterminer = "thier";
            PossesivePronoun = "thiers";
            Reflexive = "themself";
            TextFilePath = @".\FirstNamesAll.txt";
        }
    }

}
