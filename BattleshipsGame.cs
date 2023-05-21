namespace BattleShips;

public class BattleshipsGame
{
    private readonly Grid _grid;
    private readonly Random _random;

    private readonly List<Ship> _ships;

    public BattleshipsGame()
    {
        _grid = new Grid(10);
        _random = new Random();
        _ships = new List<Ship>
        {
            new Battleship {ShipSymbol = '0'},
            new Destroyer {ShipSymbol = '1'},
            new Destroyer {ShipSymbol = '2'}
        };
    }

    public void Play()
    {
        InitializeGrid();
        PlaceShips();

        while (_ships.Exists(ship => !ship.IsSunk))
        {
            _grid.Display();
            string? target = GetUserInput("Enter coordinates to target (e.g., A5): ");
            if (target != null) ProcessTurn(target);
        }

        _grid.Display();
        Console.WriteLine("Congratulations! You sunk all the ships!");
    }

    private void InitializeGrid()
    {
        for (int row = 0; row < _grid.Size; row++)
        {
            for (int col = 0; col < _grid.Size; col++)
            {
                _grid.MarkCoordinate(row, col, ' ');
            }
        }
    }

    private void PlaceShips()
    {
        foreach (Ship ship in _ships)
        {
            bool placed = false;
            int attempts = 0;
            while (!placed && attempts < 100)
            {
                int row = _random.Next(0, _grid.Size);
                int col = _random.Next(0, _grid.Size);
                bool isVertical = _random.Next(2) == 0;

                if (CanPlaceShip(row, col, ship.Size, isVertical))
                {
                    PlaceShipOnGrid(row, col, ship.Size, isVertical, ship);
                    placed = true;
                }
                attempts++;
            }
        }
    }

    private bool CanPlaceShip(int row, int col, int size, bool isVertical)
    {
        int rowEnd = row + (isVertical ? size : 1);
        int colEnd = col + (isVertical ? 1 : size);

        if (rowEnd > _grid.Size || colEnd > _grid.Size)
            return false;

        for (int i = row; i < rowEnd; i++)
        {
            for (int j = col; j < colEnd; j++)
            {
                if (!_grid.IsValidCoordinate(i, j) || !_grid.IsEmptyCoordinate(i, j))
                    return false;
            }
        }

        return true;
    }

    private void PlaceShipOnGrid(int row, int col, int size, bool isVertical, Ship ship)
    {
        int rowEnd = row + (isVertical ? size : 1);
        int colEnd = col + (isVertical ? 1 : size);

        char symbol = ship.ShipSymbol;
        for (int i = row; i < rowEnd; i++)
        {
            for (int j = col; j < colEnd; j++)
            {
                _grid.MarkCoordinate(i, j, symbol);
            }
        }

        _grid.RegisterShip(symbol, ship);
    }

    private void ProcessTurn(string target)
    {
        Console.Clear();
        char column = char.ToUpper(target[0]);
        if (!int.TryParse(target.Substring(1), out var row) || row < 1 || row > 10 || column < 'A' || column > 'J')
        {
            Console.WriteLine("Invalid target! Try again.");
            return;
        }
        row--; // Adjust row to 0-based index

        if (_grid.IsAlreadyTargetedCoordinate(row, column - 'A'))
        {
            Console.WriteLine("You already targeted this position!");
            return;
        }

        if (_grid.IsEmptyCoordinate(row, column - 'A'))
        {
            Console.WriteLine("Miss!");
            _grid.MarkCoordinate(row, column - 'A', 'M');
        }
        else
        {
            var shipSymbol = _grid.GetSymbol(row, column - 'A');
            Console.WriteLine("Hit!");

            var ship = _grid.GetShip(shipSymbol);
            ship.RegisterHit();
            _grid.MarkCoordinate(row, column - 'A', 'X');

            if (ship.IsSunk)
            {
                Console.WriteLine($"You sunk the {ship.Name}!");
            }
        }
    }

    private string? GetUserInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }
}
