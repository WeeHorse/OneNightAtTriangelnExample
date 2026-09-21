// Npc beskriver det som spelets icke spelbara personer har gemensamt.
abstract class Npc
{
    public string Name { get; }

    protected Npc(string name)
    {
        Name = name;
    }

    public abstract void Interact(Player player);
}
