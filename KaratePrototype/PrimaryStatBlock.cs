using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaratePrototype
{
    class PrimaryStatBlock
    {
        public int PersonID { get; set; }
        public Statistic Speed { get; set; }
        public Statistic Power { get; set; }
        public Statistic Stamina { get; set; }

        public PrimaryStatBlock()
        {
            Speed = new Statistic();
            Power = new Statistic();
            Stamina = new Statistic();
        }

        public PrimaryStatBlock(Random rnd, IGrade grade) :this()
        {
            GenerateStats(rnd, grade);
        }

        private void GenerateStats(Random rnd, IGrade grade)
        {
            int average = grade.AverageStat;
            int difference = 5;
            Speed.Level = rnd.Next(average-difference,average+difference);
            Power.Level = rnd.Next(average - difference, average + difference);
            Stamina.Level = rnd.Next(average - difference, average + difference);
        }
    }
}
