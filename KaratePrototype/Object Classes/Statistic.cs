using System;

namespace KaratePrototype
{
    class Statistic
    {
        private double Constant = 250;
        private int maxLevel = 99;
        
        private double experiance;
        public double Experiance {
            get { return experiance; }
            set {
                experiance = value;
                if (experiance < 1)
                {
                    experiance = 1;
                } 
                CalculateLevel();
            }
        }       
        
        private int level;
        public int Level
        {
            get { return level; }
            set
            {
                level = value;
                if (level > maxLevel)
                {
                    level = maxLevel;
                }
                if (level < 1)
                {
                    level = 1;
                }
                CalculateXP();              
            }           
        }

        public void AddXP(double xp)
        {
            Experiance = Experiance +  xp;
            CalculateLevel();
        }

        public void RemoveXP(double xp)
        {
            Experiance = Experiance - xp;
            CalculateLevel();
        }

        public void CalculateLevel()
        {
            double lvl = 100 * ( (Math.Sqrt(Experiance)) /Constant);
            level = Convert.ToInt32(Math.Round(lvl));
            if (level > maxLevel)
            {
                level = maxLevel;
            }
        }

        public void CalculateXP()
        {
            double lvl = level;
            experiance = ((lvl/100)*Constant) * ((lvl/100)*Constant);
        }
    }
}
