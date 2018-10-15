using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaratePrototype
{
    interface IGender
    {
        string LongGender { get; set; }
        string Nominative { get; set; }
        string Objective { get; set; }
        string PossesiveDeterminer { get; set; }
        string PossesivePronoun { get; set; }
        string Reflexive { get; set; }
        string TextFilePath { get; set; }

    }
}
