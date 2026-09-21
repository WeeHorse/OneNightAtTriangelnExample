class Menu
{
    // Menu vet inte vad alternativen betyder. Den visar bara texter,
    // läser ett giltigt nummer och lämnar tillbaka spelarens val.
    public int Ask(string heading, List<string> options)
    {
        Console.WriteLine($"\n{heading}");

        for (int i = 0; i < options.Count; i++)
        {
            // Listans första index är 0, men användaren får menyval från 1.
            Console.WriteLine($"{i + 1}. {options[i]}");
        }

        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int choice) &&
                choice >= 1 &&
                choice <= options.Count)
            {
                return choice;
            }

            Console.WriteLine("Välj ett av numren i menyn.");
        }
    }
}
