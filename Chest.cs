// Kistan är inte ett Item. Den stannar på platsen och innehåller Items.
sealed class Chest
{
    public bool IsOpen { get; private set; }
    private List<Item> items = new();

    public Chest()
    {
        items.Add(new FireAlarmTool());
    }

    public void Open(Player player)
    {
        if (IsOpen)
        {
            Console.WriteLine("Kistan är redan öppen och tom.");
            return;
        }

        if (!player.Inventory.Contains<SmallKey>())
        {
            Console.WriteLine("Kistan är låst. Nyckelhålet är mycket litet.");
            return;
        }

        IsOpen = true;
        Console.WriteLine("Du låser upp kistan med den lilla nyckeln.");

        foreach (Item item in items)
        {
            player.Inventory.Add(item);
        }

        items.Clear();
    }
}
