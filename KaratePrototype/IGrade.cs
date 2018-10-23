using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaratePrototype
{
    interface IGrade
    {

        string BeltColour { get; set; }
        string BeltColourRef { get; set; }
        string GradeName { get; set; }
        int AverageStat { get; set; }

    }
}
