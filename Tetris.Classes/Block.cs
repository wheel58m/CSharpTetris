using static Tetris.Classes.Color; // Allows us to use the Color enum values without the enum name
namespace Tetris.Classes;

public class Block {
    public GridCoordinate Position { get; set; } = new GridCoordinate(0, 0);
    public string Symbol { get; } = "[ ]";
    public Color Color { get; set; } = Green;

    // Constructor -------------------------------------------------------------
    public Block(GridCoordinate position, Color color = Green) {
        Position = position;
        Color = color;
    }
}