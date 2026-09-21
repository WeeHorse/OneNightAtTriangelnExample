sealed class Station : Location
{
    public override string[] Directions { get; } = new[] { "Väster" };

    public Station()
        : base("Triangelns station", "Tåget mot Eslöv väntar vid perrongen.") { }

    public override void Interact(Player player)
    {
        if (!player.Inventory.Contains<TuxedoJacket>())
        {
            Console.WriteLine("Du kan åka, men något viktigt känns bortglömt.");
            return;
        }

        Console.WriteLine("\nDu hinner precis med tåget till Eslöv!");
        Console.WriteLine("Men är det din brors bröllop ... eller ditt eget?");
        Console.WriteLine("DU VANN!");
        player.HasWon = true;
    }
}
