using Tetris.Utilities;
namespace Tetris.Classes;

public class Block {
    public ConsoleColor Color { get; set; }
    public GridPosition Position { get; set; }

    // Constructors ---------------------------------------/
    public Block() {
        Color = ConsoleColor.White;
        Position = new GridPosition(); // Default Position: (0, 0)
    }
    public Block(ConsoleColor color, GridPosition position) {
        Color = color;
        Position = position;
    }

    // Methods --------------------------------------------/
    public void Render() {
        // Set Cursor Position
        (int x, int y) = Position.ToCursorPosition();
        Console.SetCursorPosition(x, y);

        // Print
        Console.ForegroundColor = Color;
        Console.Write(Art.Block.Art);
        Console.ResetColor();
    }
    public void Clear() {
        // Set Cursor Position
        (int x, int y) = Position.ToCursorPosition();
        Console.SetCursorPosition(x, y);

        for (int i = 0; i < Art.Block.Height; i++) {
            for (int j = 0; j < Art.Block.Width; j++) {
                Console.Write(" ");
            }
        }
    }
    public void Move(int x, int y, bool rerender = false) {
        // Rerendering can conflict with the Piece.Move() method by clearing blocks that have already been moved.
        if (rerender) Clear();
        Position = new GridPosition(Position.X + x, Position.Y + y);
        if (rerender) Render();
    }
}