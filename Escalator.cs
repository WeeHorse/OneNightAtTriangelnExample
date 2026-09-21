sealed class Escalator : Location
{
    public override string[] Directions { get; } = new[] { "Norr", "Söder" };

    public Escalator()
        : base("Rulltrappan", "Rulltrappan står stilla, men du kan gå nedför den.") { }

    public override void Interact(Player player)
    {
        Console.WriteLine("Bredvid rulltrappan finns en grön knapp.");
        Console.WriteLine("Det känns som en dålig idé att trycka på den.");
    }
}
