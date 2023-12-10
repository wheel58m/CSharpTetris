using static Tetris.Classes.Color; // Allows us to use the Color enum values without the enum name
namespace Tetris.Classes;

public class Block {
    public IBlockContainer? Container { get; set; }
    public GridCoordinate Position { get; set; }
    private string Symbol { get; init; }
    private Color Color { get; set; }

    // Constructor -------------------------------------------------------------
    public Block(GridCoordinate position, Color color = Green, IBlockContainer container = null!) {
        Container = container;
        Position = position;
        Symbol = Utilities.DefaultBlockSymbol;
        Color = color;
    }

    // Methods -----------------------------------------------------------------
    public void Display() {
        (int x, int y) = Position.ConvertToConsoleCoordinate(); // Convert Position to Cursor Position
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = Constants.ColorDictionary[Color];

        if (Utilities.ShowBackground) {
            Console.BackgroundColor = Constants.ColorDictionary[Color];
        }
        if (Utilities.Debug.ShowBlockID && Container != null) {
            Console.Write($"[{GetID()}]");
        } else {  
            Console.Write(Symbol);
        }

        Console.ResetColor();
    }
    public void Clear() {
        (int x, int y) = Position.ConvertToConsoleCoordinate(); // Convert Position to Cursor Position
        Console.SetCursorPosition(x, y);
        Console.Write(Utilities.EmptyBlockSymbol);
    }
    public void Move(int x, int y) {
        Position = new GridCoordinate(Position.X + x, Position.Y + y);
    }

    // Debug Methods -----------------------------------------------------------
    public void DisplayBlockInfo() {
        Console.WriteLine($"Block Details: Position: ({Position.X}, {Position.Y}), Symbol: {Symbol}, Color: {Color}");
    }
    public int GetID() => Container == null ? 0 : Array.IndexOf(Container.Blocks, this);
}