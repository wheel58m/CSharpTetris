using static Tetris.Classes.Color; // Allows us to use the Color enum values without the enum name
namespace Tetris.Classes;

public class Block {
    public GridCoordinate Position { get; set; } = new GridCoordinate(0, 0);
    public static string Symbol { get; } = "[ ]";
    public Color Color { get; set; } = Green;

    // Constructor -------------------------------------------------------------
    public Block(GridCoordinate position, Color color = Green) {
        Position = position;
        Color = color;
    }

    // Methods -----------------------------------------------------------------
    public void Display() {
        (int x, int y) = Position.ConvertToConsoleCoordinate(); // Convert Position to Cursor Position
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = (ConsoleColor)Color;
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