class Map
{
    // Första hakparentesen väljer rad och den andra kolumn.
    private Location?[][] locations;

    public Map()
    {
        locations = CreateLocations();
    }

    public Location GetLocation(int row, int column)
    {
        // Anropande kod har först kontrollerat positionen med PositionExists.
        return locations[row][column]!;
    }

    public bool PositionExists(int row, int column)
    {
        if (row < 0 || row >= locations.Length)
        {
            return false;
        }

        // Rader i en array av arrayer kan ha olika längd.
        if (column < 0 || column >= locations[row].Length)
        {
            return false;
        }

        // null är en tom ruta som spelaren inte kan gå till.
        return locations[row][column] != null;
    }

    private Location?[][] CreateLocations()
    {
        ToiletStall toiletStall = new();
        LadiesRoom ladiesRoom = new();
        SecondFloor secondFloor = new();
        Escalator escalator = new();
        ClosedStore closedStore = new();
        StorageRoom storageRoom = new();
        FirstFloor firstFloor = new();
        Station station = new();
        Outside outside = new();

        //                      kolumn 0       kolumn 1       kolumn 2       kolumn 3
        // rad 0                toiletStall    ladiesRoom     secondFloor
        // rad 1                null           null           escalator
        // rad 2                closedStore    storageRoom    firstFloor
        // rad 3                null           null           outside         station
        //
        // Alla fyra rader får fyra positioner. Platsernas Directions
        // bestämmer vilka av de angränsande rutorna som visas i menyn.
        return new Location?[4][]
        {
            new Location?[4] { toiletStall, ladiesRoom, secondFloor, null },
            new Location?[4] { null, null, escalator, null },
            new Location?[4] { closedStore, storageRoom, firstFloor, null },
            new Location?[4] { null, null, outside, station }
        };
    }
}
