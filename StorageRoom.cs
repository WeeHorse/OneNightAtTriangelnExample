sealed class StorageRoom : Location
{
    public override string[] Directions { get; } = new[] { "Väster", "Öster" };

    public StorageRoom()
        : base("Förrådet", "Ett förråd förbinder rulltrappan med en stängd butik.") { }

    public override void Interact(Player player)
    {
        Console.WriteLine("Här finns mest städmaterial och tomma kartonger.");
    }
}
