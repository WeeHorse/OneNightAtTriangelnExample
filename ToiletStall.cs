sealed class ToiletStall : Location
{
    public override string[] Directions { get; } = new[] { "Öster" };

    public ToiletStall()
        : base("Toalettbåset", "Du vaknar med huvudvärk. I cisternen glimmar något.")
    {
        Items.Add(new SmallKey());
    }

    public override void Interact(Player player)
    {
        Console.WriteLine("Du försöker minnas hur du hamnade här.");
    }
}
