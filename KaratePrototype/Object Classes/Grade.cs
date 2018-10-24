namespace KaratePrototype
{
    class TenthKyu : IGrade
    {
        public string BeltColour { get; set; }
        public string BeltColourRef { get; set; }
        public string GradeName { get; set; }
        public int AverageStat { get; set; }
        public string CompetitionCategory { get; set; }

        public TenthKyu()
        {
            BeltColour = "White";
            BeltColourRef = "White Belt";
            GradeName = "10th Kyu";
            AverageStat = 30;
            CompetitionCategory = "Novice";
        }
    }

    class NinthKyu : IGrade
    {
        public string BeltColour { get; set; }
        public string BeltColourRef { get; set; }
        public string GradeName { get; set; }
        public int AverageStat { get; set; }
        public string CompetitionCategory { get; set; }

        public NinthKyu()
        {
            BeltColour = "Orange";
            BeltColourRef = "Orange Belt";
            GradeName = "9th Kyu";
            AverageStat = 35;
            CompetitionCategory = "Novice";
        }
    }

    class EightKyu : IGrade
    {
        public string BeltColour { get; set; }
        public string BeltColourRef { get; set; }
        public string GradeName { get; set; }
        public int AverageStat { get; set; }
        public string CompetitionCategory { get; set; }

        public EightKyu()
        {
            BeltColour = "Red";
            BeltColourRef = "Red Belt";
            GradeName = "8th Kyu";
            AverageStat = 40;
            CompetitionCategory = "Novice";
        }
    }

    class SeventhKyu : IGrade
    {
        public string BeltColour { get; set; }
        public string BeltColourRef { get; set; }
        public string GradeName { get; set; }
        public int AverageStat { get; set; }
        public string CompetitionCategory { get; set; }

        public SeventhKyu()
        {
            BeltColour = "Yellow";
            BeltColourRef = "Yellow Belt";
            GradeName = "7th Kyu";
            AverageStat = 45;
            CompetitionCategory = "Novice";
        }
    }

    class SixthKyu : IGrade
    {
        public string BeltColour { get; set; }
        public string BeltColourRef { get; set; }
        public string GradeName { get; set; }
        public int AverageStat { get; set; }
        public string CompetitionCategory { get; set; }

        public SixthKyu()
        {
            BeltColour = "Green";
            BeltColourRef = "Green Belt";
            GradeName = "6th Kyu";
            AverageStat = 50;
            CompetitionCategory = "Novice";
        }
    }

    class FifthKyu : IGrade
    {
        public string BeltColour { get; set; }
        public string BeltColourRef { get; set; }
        public string GradeName { get; set; }
        public int AverageStat { get; set; }
        public string CompetitionCategory { get; set; }

        public FifthKyu()
        {
            BeltColour = "Purple";
            BeltColourRef = "Purple Belt";
            GradeName = "5th Kyu";
            AverageStat = 55;
            CompetitionCategory = "Novice";
        }
    }

    class FourthKyu : IGrade
    {
        public string BeltColour { get; set; }
        public string BeltColourRef { get; set; }
        public string GradeName { get; set; }
        public int AverageStat { get; set; }
        public string CompetitionCategory { get; set; }

        public FourthKyu()
        {
            BeltColour = "Purple";
            BeltColourRef = "Purple Belt White Stripe";
            GradeName = "4th Kyu";
            AverageStat = 60;
            CompetitionCategory = "Novice";
        }
    }

    class ThirdKyu : IGrade
    {
        public string BeltColour { get; set; }
        public string BeltColourRef { get; set; }
        public string GradeName { get; set; }
        public int AverageStat { get; set; }
        public string CompetitionCategory { get; set; }

        public ThirdKyu()
        {
            BeltColour = "Brown";
            BeltColourRef = "Brown Belt";
            GradeName = "3rd Kyu";
            AverageStat = 65;
            CompetitionCategory = "Intermediate";
        }
    }

    class SecondKyu : IGrade
    {
        public string BeltColour { get; set; }
        public string BeltColourRef { get; set; }
        public string GradeName { get; set; }
        public int AverageStat { get; set; }
        public string CompetitionCategory { get; set; }

        public SecondKyu()
        {
            BeltColour = "Brown";
            BeltColourRef = "Brown Belt White Stripe";
            GradeName = "2nd Kyu";
            AverageStat = 70;
            CompetitionCategory = "Intermediate";
        }
    }

    class FirstKyu : IGrade
    {
        public string BeltColour { get; set; }
        public string BeltColourRef { get; set; }
        public string GradeName { get; set; }
        public int AverageStat { get; set; }
        public string CompetitionCategory { get; set; }

        public FirstKyu()
        {
            BeltColour = "Brown";
            BeltColourRef = "Brown Belt Two White Stripes";
            GradeName = "1st Kyu";
            AverageStat = 75;
            CompetitionCategory = "Intermediate";
        }
    }

    class FirstDan : IGrade
    {
        public string BeltColour { get; set; }
        public string BeltColourRef { get; set; }
        public string GradeName { get; set; }
        public int AverageStat { get; set; }
        public string CompetitionCategory { get; set; }

        public FirstDan()
        {
            BeltColour = "Black";
            BeltColourRef = "Black Belt";
            GradeName = "1st Dan";
            AverageStat = 80;
            CompetitionCategory = "Black Belt";
        }
    }

    class SecondDan : IGrade
    {
        public string BeltColour { get; set; }
        public string BeltColourRef { get; set; }
        public string GradeName { get; set; }
        public int AverageStat { get; set; }
        public string CompetitionCategory { get; set; }

        public SecondDan()
        {
            BeltColour = "Black";
            BeltColourRef = "Black Belt";
            GradeName = "2nd Dan";
            AverageStat = 80;
            CompetitionCategory = "Black Belt";
        }
    }

    class ThirdDan : IGrade
    {
        public string BeltColour { get; set; }
        public string BeltColourRef { get; set; }
        public string GradeName { get; set; }
        public int AverageStat { get; set; }
        public string CompetitionCategory { get; set; }

        public ThirdDan()
        {
            BeltColour = "Black";
            BeltColourRef = "Black Belt";
            GradeName = "3rd Dan";
            AverageStat = 85;
            CompetitionCategory = "Black Belt";
        }
    }

    class FourthDan : IGrade
    {
        public string BeltColour { get; set; }
        public string BeltColourRef { get; set; }
        public string GradeName { get; set; }
        public int AverageStat { get; set; }
        public string CompetitionCategory { get; set; }

        public FourthDan()
        {
            BeltColour = "Black";
            BeltColourRef = "Black Belt";
            GradeName = "4th Dan";
            AverageStat = 90;
            CompetitionCategory = "Black Belt";
        }
    }
}
