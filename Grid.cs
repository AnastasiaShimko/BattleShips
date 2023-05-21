namespace BattleShips;

internal class Grid
{
    private readonly char[,] _grid;
    private readonly Dictionary<char, Ship> _shipMap;

    public int Size { get; }

    public Grid(int size)
    {
        Size = size;
        _grid = new char[Size, Size];
        _shipMap = new Dictionary<char, Ship>();
    }

    public bool IsValidCoordinate(int row, int col)
    {
        return row >= 0 && row < Size && col >= 0 && col < Size;
    }

    public bool IsEmptyCoordinate(int row, int col)
    {
        return _grid[row, col] == ' ';
    }

    public bool IsAlreadyTargetedCoordinate(int row, int col)
    {
        return _grid[row, col] == 'M' || _grid[row, col] == 'X';
    }
    
    public void MarkCoordinate(int row, int col, char symbol)
    {
        _grid[row, col] = symbol;
    }
    
    public char GetSymbol(int row, int col)
    {
        return _grid[row, col];
    }

    public void RegisterShip(char symbol, Ship ship)
    {
        _shipMap[symbol] = ship;
    }

    public Ship GetShip(char symbol)
    {
        return _shipMap[symbol];
    }

    public void Display()
    {
        Console.WriteLine("   A B C D E F G H I J");
        Console.WriteLine("  ---------------------");
        for (int row = 0; row < Size; row++)
        {
            Console.Write($"{row + 1} |");
            for (int col = 0; col < Size; col++)
            {
                if (_grid[row, col] == ' ' || _grid[row, col] == 'M' || _grid[row, col] == 'X')
                {
                    Console.Write($"{_grid[row, col]}|");
                }
                else
                {
                    Console.Write(" |");
                }
            }
            Console.WriteLine("\n  ---------------------");
        }
        Console.WriteLine();
    }
}
