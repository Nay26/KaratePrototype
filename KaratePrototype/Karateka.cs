using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaratePrototype
{
    class Karateka
    {
        public int PersonID { get; set; }
        public int UniversityID { get; set; }
        public IGrade Grade { get; set; }
        public DateTime StartDate { get; set; }

        public Karateka()
        {

        }
        public Karateka(Random rnd) : this()
        {
            Grade = GetRandomGrade(rnd);
            StartDate = DateTime.Today;
        }

        private IGrade GetRandomGrade(Random rnd)
        {
            IGrade grade = new WhiteBelt();
            int roll = rnd.Next(0,100);
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
    }
}
