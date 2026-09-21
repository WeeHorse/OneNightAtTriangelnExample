class Player
{
    // Row och Column är spelarens adress i kartans array av arrayer.
    public int Row { get; set; }
    public int Column { get; set; }
    public bool HasWon { get; set; }
    public Inventory Inventory { get; } = new();

    public Player(int startRow, int startColumn)
    {
        Row = startRow;
        Column = startColumn;
    }
}
