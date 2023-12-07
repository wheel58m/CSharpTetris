namespace Tetris.Classes;

public class Board {
    public Piece ActivePiece { get; set; } = GeneratePiece();
    public Block[,] Grid { get; set; } = new Block[10, 20];

    // Methods -----------------------------------------------------------------
    public static Piece GeneratePiece() {
        Random random = new();

        // Generate a Random Shape
        int shape = random.Next(1, 8);

        // Generate a Random Color
        int color = random.Next(1, 8);

        // Generate a Random Orientation
        int orientation = random.Next(1, 4);

        // Return the new Piece
        return shape switch {
            1 => new IPiece((Color)color, (Orientation)orientation),
            2 => new OPiece((Color)color, (Orientation)orientation),
            3 => new TPiece((Color)color, (Orientation)orientation),
            4 => new LPiece((Color)color, (Orientation)orientation),
            5 => new JPiece((Color)color, (Orientation)orientation),
            6 => new SPiece((Color)color, (Orientation)orientation),
            7 => new ZPiece((Color)color, (Orientation)orientation),
            _ => new IPiece(),
        };
    }
}