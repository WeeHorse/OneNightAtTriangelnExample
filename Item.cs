// Item innehåller det som alla föremål har gemensamt.
// Klassen är abstract eftersom alla föremål ska vara av en konkret typ.
abstract class Item
{
    public string Name { get; }
    public string Description { get; }

    protected Item(string name, string description)
    {
        Name = name;
        Description = description;
    }
}

sealed class SmallKey : Item
{
    public SmallKey() : base("Liten nyckel", "En liten mässingsnyckel.") { }
}

sealed class Bottle : Item
{
    public Bottle() : base("Flaska", "En halvfull flaska med något som luktar starkt.") { }
}

sealed class FireAlarmTool : Item
{
    public FireAlarmTool()
        : base("Brandlarmsverktyg", "Ett verktyg för att öppna skyddet framför brandlarmet.") { }
}

sealed class TuxedoJacket : Item
{
    public TuxedoJacket()
        : base("Smokingjacka", "Din jacka. I fickan ligger en ring och en tågbiljett.") { }
}
