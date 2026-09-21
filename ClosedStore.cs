sealed class ClosedStore : Location
{
    public override string[] Directions { get; } = new[] { "Öster" };

    // Bara den här platsen behöver känna till kistan.
    private Chest chest = new();

    public ClosedStore()
        : base("Den stängda butiken", "Bakom disken står en dammig träkista.") { }

    public override void Interact(Player player)
    {
        chest.Open(player);
    }
}
