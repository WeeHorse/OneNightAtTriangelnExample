class Game
{
    private Map map = new();
    private Player player = new(0, 0);
    private Menu menu = new();
    private bool isRunning = true;

    public void Start()
    {
        Console.WriteLine("ONE NIGHT AT TRIANGELN");
        Console.WriteLine("Du måste hinna med morgontåget till Eslöv.\n");

        // Ett varv i while-loopen är en spelomgång.
        while (isRunning)
        {
            PlayTurn();
        }
    }

    private void PlayTurn()
    {
        Location location = CurrentLocation();

        Console.WriteLine($"\n=== {location.Name.ToUpper()} ===");
        Console.WriteLine(location.Description);

        int choice = menu.Ask("Vad vill du göra?", new List<string>
        {
            "Förflytta dig",
            "Undersök platsen",
            "Ta ett föremål",
            "Interagera",
            "Visa inventory",
            "Avsluta spelet"
        });

        switch (choice)
        {
            case 1:
                ChooseDirection();
                break;
            case 2:
                SearchLocation();
                break;
            case 3:
                ShowTakeItemMenu();
                break;
            case 4:
                Interact();
                break;
            case 5:
                player.Inventory.Print();
                break;
            case 6:
                isRunning = false;
                Console.WriteLine("Spelet avslutas.");
                break;
        }
    }

    private Location CurrentLocation()
    {
        // Spelarens koordinater används som adress i kartan.
        return map.GetLocation(player.Row, player.Column);
    }

    private void ChooseDirection()
    {
        Location location = CurrentLocation();

        // Den konkreta Location-klassen deklarerar vilka riktningar som finns.
        List<string> directions = location.Directions.ToList();

        int choice = menu.Ask("Vart vill du gå?", directions);
        string selectedDirection = directions[choice - 1];

        switch (selectedDirection)
        {
            case "Norr":
                TryMovePlayer(-1, 0);
                break;
            case "Söder":
                TryMovePlayer(1, 0);
                break;
            case "Väster":
                TryMovePlayer(0, -1);
                break;
            case "Öster":
                TryMovePlayer(0, 1);
                break;
        }
    }

    private void TryMovePlayer(int rowChange, int columnChange)
    {
        int newRow = player.Row + rowChange;
        int newColumn = player.Column + columnChange;

        // Skyddar spelet om en platsklass råkar deklarera en riktning
        // som inte leder till en riktig position i kartan.
        if (!map.PositionExists(newRow, newColumn))
        {
            Console.WriteLine("Du kan inte gå åt det hållet.");
            return;
        }

        Location current = CurrentLocation();
        Location destination = map.GetLocation(newRow, newColumn);

        // FirstFloor äger dörrens tillstånd. Mönstermatchningen ger oss
        // FirstFloor-objektet så att ExitIsOpen kan kontrolleras.
        bool triesToLeave =
            current is FirstFloor firstFloor &&
            destination is Outside &&
            !firstFloor.ExitIsOpen;

        bool triesToEnter =
            current is Outside &&
            destination is FirstFloor destinationFloor &&
            !destinationFloor.ExitIsOpen;

        if (triesToLeave || triesToEnter)
        {
            Console.WriteLine("Ytterdörrarna är fortfarande låsta.");
            return;
        }

        // Själva förflyttningen: spelarens koordinater byts ut.
        player.Row = newRow;
        player.Column = newColumn;
    }

    private void SearchLocation()
    {
        Location location = CurrentLocation();

        if (location.Items.Count == 0)
        {
            Console.WriteLine("Du hittar inget löst föremål här.");
            return;
        }

        foreach (Item item in location.Items)
        {
            Console.WriteLine($"Du hittar {item.Name}: {item.Description}");
        }
    }

    private void ShowTakeItemMenu()
    {
        Location location = CurrentLocation();

        if (location.Items.Count == 0)
        {
            Console.WriteLine("Det finns inget föremål att ta.");
            return;
        }

        List<string> itemNames = location.Items
            .Select(item => item.Name)
            .ToList();

        int choice = menu.Ask("Vad vill du ta?", itemNames);
        Item item = location.Items[choice - 1];

        // Samma objekt flyttas från platsens lista till spelarens inventory.
        location.Items.Remove(item);
        player.Inventory.Add(item);
    }

    private void Interact()
    {
        Location location = CurrentLocation();

        // Polymorfism: objektets verkliga klass avgör vilken Interact-metod
        // som körs, trots att variabeln har typen Location.
        location.Interact(player);

        if (player.HasWon)
        {
            isRunning = false;
        }
    }
}
