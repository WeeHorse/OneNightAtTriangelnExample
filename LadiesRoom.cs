sealed class LadiesRoom : Location
{
    public override string[] Directions { get; } = new[] { "Väster", "Öster" };

    public LadiesRoom()
        : base("Damernas toalett", "Vid handfaten står en halvfull flaska.")
    {
        Items.Add(new Bottle());
    }

    public override void Interact(Player player)
    {
        Console.WriteLine("I spegeln ser du att du har smokingbyxor, skjorta och fluga.");
    }
}
