// Location beskriver det som alla platser har gemensamt.
// Klassen är abstract eftersom spelet aldrig ska skapa en ospecificerad plats.
abstract class Location
{
    public string Name { get; }
    public string Description { get; }
    public List<Item> Items { get; } = new();

    // Varje konkret plats anger vilka utgångar som ska visas i rörelsemenyn.
    public abstract string[] Directions { get; }

    protected Location(string name, string description)
    {
        Name = name;
        Description = description;
    }

    // Varje konkret plats måste bestämma vad Interact betyder där.
    public abstract void Interact(Player player);
}
