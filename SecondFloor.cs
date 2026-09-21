sealed class SecondFloor : Location
{
    public override string[] Directions { get; } = new[] { "Väster", "Söder" };

    public SecondFloor()
        : base("Andra våningen", "Triangeln är mörkt. En rulltrappa leder nedåt.") { }

    public override void Interact(Player player)
    {
        Console.WriteLine("Alla butiker är stängda och köpcentrumet är helt tyst.");
    }
}
