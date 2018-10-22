using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaratePrototype
{
    class WhiteBelt : IGrade
    {
        public string BeltColour { get; set; }
        public string BeltColourRef { get; set; }
        public string GradeName { get; set; }
        
        public WhiteBelt()
        {
            BeltColour = "White";
            BeltColourRef = "White Belt";
            GradeName = "10th Kyu";
        }
    }

    class OrangeBelt : IGrade
    {
        public string BeltColour { get; set; }
        public string BeltColourRef { get; set; }
        public string GradeName { get; set; }

        public OrangeBelt()
        {
            BeltColour = "Orange";
            BeltColourRef = "Orange Belt";
            GradeName = "9th Kyu";
        }
    }

    class RedBelt : IGrade
    {
        public string BeltColour { get; set; }
        public string BeltColourRef { get; set; }
        public string GradeName { get; set; }

        public RedBelt()
        {
            BeltColour = "Red";
            BeltColourRef = "Red Belt";
            GradeName = "8th Kyu";
        }
    }

    class YellowBelt : IGrade
    {
        public string BeltColour { get; set; }
        public string BeltColourRef { get; set; }
        public string GradeName { get; set; }

        public YellowBelt()
        {
            BeltColour = "Yellow";
            BeltColourRef = "Yellow Belt";
            GradeName = "7th Kyu";
        }
    }

    class GreenBelt : IGrade
    {
        public string BeltColour { get; set; }
        public string BeltColourRef { get; set; }
        public string GradeName { get; set; }

        public GreenBelt()
        {
            BeltColour = "Green";
            BeltColourRef = "Green Belt";
            GradeName = "6th Kyu";
        }
    }
}
