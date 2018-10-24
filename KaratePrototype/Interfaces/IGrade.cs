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
