namespace Tetris.Classes;

public class Board {
    public Piece ActivePiece { get; set; }
    public Block[,] Grid { get; set; } = new Block[10, 30];

    // Constructor -------------------------------------------------------------
    public Board() {
        ActivePiece = GeneratePiece();
    }

    // Methods -----------------------------------------------------------------
    public void Display() {
        Console.Clear();

        // Display Top Border ------------------------------
        Console.Write("╔"); // Top Left Corner
        for (int i = 0; i < Grid.GetLength(0); i++) {
            Console.Write("═══");
        }
        Console.WriteLine("╗"); // Top Right Corner

        // Display Left Border -----------------------------
        (int x, int y) cursorPosition = (Console.CursorLeft, Console.CursorTop);
        for (int i = 0; i < Grid.GetLength(1); i++) {
            Console.SetCursorPosition(cursorPosition.x, cursorPosition.y + i);
            Console.Write("║"); // Left Border
        }

        // Display Right Border ----------------------------
        cursorPosition = (Grid.GetLength(0) * 3 + 1, 1);
        for (int i = 0; i < Grid.GetLength(1); i++) {
            Console.SetCursorPosition(cursorPosition.x, cursorPosition.y + i);
            Console.Write("║"); // Right Border
        }

        // Display Bottom Border ---------------------------
        Console.SetCursorPosition(0, Grid.GetLength(1) + 1);
        Console.Write("╚"); // Bottom Left Corner
        for (int i = 0; i < Grid.GetLength(0); i++) {
            Console.Write("═══");
        }
        Console.WriteLine("╝"); // Bottom Right Corner
    }
    public Piece GeneratePiece() {
        Random random = new();

        // Generate a Random Shape
        int shape = random.Next(1, 8);

        // Generate a Random Color
        int color = random.Next(1, 8);

        // Generate a Random Position
        int x = random.Next(0, 10);
        // int x = 5;
        int y = 0;
        GridCoordinate position = new(x, y);

        // Generate a Random Orientation
        int orientation = random.Next(1, 4);

        // Return the new Piece
        return shape switch {
            1 => new IPiece(position, (Color)color, (Orientation)orientation) { ActiveBoard = this },
            2 => new OPiece(position, (Color)color, (Orientation)orientation) { ActiveBoard = this },
            3 => new TPiece(position, (Color)color, (Orientation)orientation) { ActiveBoard = this },
            4 => new LPiece(position, (Color)color, (Orientation)orientation) { ActiveBoard = this },
            5 => new JPiece(position, (Color)color, (Orientation)orientation) { ActiveBoard = this },
            6 => new SPiece(position, (Color)color, (Orientation)orientation) { ActiveBoard = this },
            7 => new ZPiece(position, (Color)color, (Orientation)orientation) { ActiveBoard = this },
            _ => new IPiece(new GridCoordinate(Grid.GetLength(0) / 2, 0)) { ActiveBoard = this },
        };
    }
}