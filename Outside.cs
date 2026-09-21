sealed class Outside : Location
{
    public override string[] Directions { get; } = new[] { "Norr", "Öster" };

    // Komposition: Outside har en Stranger.
    private Stranger stranger = new();

    public Outside()
        : base(
            "Utanför Triangeln",
            "En främling bär en smokingjacka som ser märkligt bekant ut."
        ) { }

    public override void Interact(Player player)
    {
        // Delegering: platsen låter personen hantera mötet.
        stranger.Interact(player);
    }
}
