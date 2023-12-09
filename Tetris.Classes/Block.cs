using static Tetris.Classes.Color; // Allows us to use the Color enum values without the enum name
namespace Tetris.Classes;

public class Block {
    public GridCoordinate Position { get; set; } = new GridCoordinate(0, 0);
    public int LocalID { get; set; } = 0;
    public string Symbol { get; set; } = "[ ]";
    public Color Color { get; set; } = Green;

    // Constructor -------------------------------------------------------------
    public Block(int id, GridCoordinate position, Color color = Green) {
        LocalID = id;
        Position = position;
        Symbol = Utilities.Debug.ShowBlockID ? $"[{LocalID}]" : "[ ]";
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
        Console.Write(Symbol);
        Console.ResetColor();
    }
    public void Clear() {
        (int x, int y) = Position.ConvertToConsoleCoordinate(); // Convert Position to Cursor Position
        Console.SetCursorPosition(x, y);
        Console.Write("   ");
    }
    public void Move(int x, int y) {
        Position = new GridCoordinate(Position.X + x, Position.Y + y);
    }
}