sealed class FirstFloor : Location
{
    public override string[] Directions { get; } = new[] { "Norr", "Väster", "Söder" };

    public bool ExitIsOpen { get; private set; }

    public FirstFloor()
        : base(
            "Första våningen",
            "Ytterdörrarna är låsta. Bredvid dem sitter ett skyddat brandlarm."
        ) { }

    public override void Interact(Player player)
    {
        if (ExitIsOpen)
        {
            Console.WriteLine("Brandlarmet tjuter och ytterdörrarna står öppna.");
            return;
        }

        if (!player.Inventory.Contains<FireAlarmTool>())
        {
            Console.WriteLine("Du kommer inte åt brandlarmet utan rätt verktyg.");
            return;
        }

        ExitIsOpen = true;
        Console.WriteLine("Du öppnar skyddet och aktiverar brandlarmet.");
        Console.WriteLine("Larmet tjuter och ytterdörrarna låses upp.");
    }
}
