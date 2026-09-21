sealed class Stranger : Npc
{
    private bool hasJacket = true;

    public Stranger() : base("Främlingen") { }

    public override void Interact(Player player)
    {
        if (!hasJacket)
        {
            Console.WriteLine("Främlingen tackar för flaskan och går vidare.");
            return;
        }

        if (!player.Inventory.Contains<Bottle>())
        {
            Console.WriteLine("Främlingen tittar misstänksamt på dig.");
            Console.WriteLine("\"Du får inte jackan gratis.\"");
            return;
        }

        player.Inventory.Remove<Bottle>();
        player.Inventory.Add(new TuxedoJacket());
        hasJacket = false;

        Console.WriteLine("Främlingen tar flaskan och lämnar över jackan.");
    }
}
