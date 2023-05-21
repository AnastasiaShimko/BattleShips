namespace BattleShips;

public abstract class Ship
{
    public string Name { get; }
    public int Size { get; }
    public int Hits { get; private set; }

    public bool IsSunk => Hits >= Size;
    public char ShipSymbol { get; set; }

    protected Ship(string name, int size)
    {
        Name = name;
        Size = size;
        Hits = 0;
    }

    public void RegisterHit()
    {
        Hits++;
    }
}