class Inventory
{
    private List<Item> items = new();

    public void Add(Item item)
    {
        items.Add(item);
        Console.WriteLine($"Du lägger {item.Name} i inventory.");
    }

    // T är en platshållare för en typ. T måste vara Item eller en subklass till Item.
    public bool Contains<T>() where T : Item
    {
        return items.OfType<T>().Any();
    }

    // Hittar det första föremålet av typen T, tar bort och returnerar det.
    public T? Remove<T>() where T : Item
    {
        T? item = items.OfType<T>().FirstOrDefault();

        if (item != null)
        {
            items.Remove(item);
        }

        return item;
    }

    public void Print()
    {
        Console.WriteLine("\nINVENTORY");

        if (items.Count == 0)
        {
            Console.WriteLine("Du bär inte på någonting.");
            return;
        }

        foreach (Item item in items)
        {
            Console.WriteLine($"- {item.Name}: {item.Description}");
        }
    }
}
