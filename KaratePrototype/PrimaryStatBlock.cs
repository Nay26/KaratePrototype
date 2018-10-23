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
            Speed.Level = 50;
            Power.Level = 50;
            Stamina.Level = 50;
        }
    }
}
