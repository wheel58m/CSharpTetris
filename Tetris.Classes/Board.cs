namespace Tetris.Classes;

public class Board {
    public Piece ActivePiece { get; set; }
    public Grid Grid { get; set; } = new(10, 30);
    public int Width { get; } = 10;
    public int Height { get; } = 30;
    public int FallSpeed { get; set; } = 1000;

    // Constructor -------------------------------------------------------------
    public Board(int width = 10, int height = 30) {
        Width = width;
        Height = height;
        Grid = new Grid(Width, Height);
        ActivePiece = RandomPiece();
    }

    // Methods -----------------------------------------------------------------
    public void Display() {
        Console.Clear();

        // Display Top Border ------------------------------
        Console.Write("╔"); // Top Left Corner
        for (int i = 0; i < Width; i++) {
            Console.Write("═══");
        }
        Console.WriteLine("╗"); // Top Right Corner

        // Display Left Border -----------------------------
        (int x, int y) cursorPosition = (Console.CursorLeft, Console.CursorTop);
        for (int i = 0; i < Height; i++) {
            Console.SetCursorPosition(cursorPosition.x, cursorPosition.y + i);
            Console.Write("║"); // Left Border
        }

        // Display Right Border ----------------------------
        cursorPosition = (Width * 3 + 1, 1);
        for (int i = 0; i < Height; i++) {
            Console.SetCursorPosition(cursorPosition.x, cursorPosition.y + i);
            Console.Write("║"); // Right Border
        }

        // Display Bottom Border ---------------------------
        Console.SetCursorPosition(0, Height + 1);
        Console.Write("╚"); // Bottom Left Corner
        for (int i = 0; i < Width; i++) {
            Console.Write("═══");
        }
        Console.WriteLine("╝"); // Bottom Right Corner
    }
    public Piece RandomPiece() {
        Random random = new();

        // Generate a Random Shape
        int shape = random.Next(0, 6);
        // int shape = 3; // L Piece

        // Generate a Random Color
        int color = random.Next(0, 7);

        // Generate a Random Position
        int x = random.Next(0, 10);
        // int x = 9;
        int y = 0;
        GridCoordinate position = new(x, y);

        // Generate a Random Orientation
        int orientation = random.Next(0, 3);
        // int orientation = 1; // Right

        // Set the Active Piece
        return shape switch {
            0 => new IPiece(position, (Color)color, (Orientation)orientation) { ActiveBoard = this },
            1 => new OPiece(position, (Color)color, (Orientation)orientation) { ActiveBoard = this },
            2 => new TPiece(position, (Color)color, (Orientation)orientation) { ActiveBoard = this },
            3 => new LPiece(position, (Color)color, (Orientation)orientation) { ActiveBoard = this },
            4 => new JPiece(position, (Color)color, (Orientation)orientation) { ActiveBoard = this },
            5 => new SPiece(position, (Color)color, (Orientation)orientation) { ActiveBoard = this },
            6 => new ZPiece(position, (Color)color, (Orientation)orientation) { ActiveBoard = this },
            _ => new IPiece(new GridCoordinate(Width / 2, 0)) { ActiveBoard = this },
        };
    }

    public void GeneratePiece(Piece? piece = null) {
        // Get Random Piece if no Piece is provided
        ActivePiece = piece ?? RandomPiece();

        // Enforce Boundaries
        EnforceBoundary(true);

        // Display Piece
        if (Utilities.Debug.ShowPieceInfo) Utilities.Debug.DisplayPieceInfo(ActivePiece); // Debug: Display Piece Info
        ActivePiece.Display();
        if (Utilities.Debug.Fall) ActivePiece.Fall(FallSpeed);
    }
    public void EnforceBoundary(bool fixToTop = false) {
        // Enforce Left Boundary
        int minX = ActivePiece.Blocks.Min(block => block.Position.X);
        if (minX < 0) {
            ActivePiece.Move(Math.Abs(minX), 0, false, false);
        }

        // Enforce Right Boundary
        int maxX = ActivePiece.Blocks.Max(block => block.Position.X);
        if (maxX >= Width) {
            ActivePiece.Move(Width - maxX - 1, 0, false, false);
        }

        // Fix to Top
        if (fixToTop) {
            int minY = ActivePiece.Blocks.Min(block => block.Position.Y);
            if (minY < 0) {
                ActivePiece.Move(0, Math.Abs(minY), false, false);
            } else if (minY > 0) {
                ActivePiece.Move(0, -minY, false, false);
            }
        }
    }
    public bool CheckForCollision(int x, int y) {
        foreach (Block block in ActivePiece.Blocks) {
            // Check for Boundary Collision
            if (block.Position.X + x < 0 || block.Position.X + x >= Width || block.Position.Y + y < 0 || block.Position.Y + y >= Height) {
                return true;
            }
            // Check for Block Collision
            if (Grid.Rows[block.Position.Y + y].Blocks[block.Position.X + x] != null) {
                return true;
            }
        }

        return false;
    }
    public bool CheckForStop() {
        foreach (Block block in ActivePiece.Blocks) {
            // Check for Bottom Boundary Collision
            if (block.Position.Y + 1 >= Height) {
                foreach (Block stoppedBlock in ActivePiece.Blocks) {
                    stoppedBlock.Container = Grid.Rows[stoppedBlock.Position.Y];
                    stoppedBlock.Clear();
                    Grid.Rows[stoppedBlock.Position.Y].Blocks[stoppedBlock.Position.X] = stoppedBlock;
                    stoppedBlock.Display();
                }
                return true;
            }
            // Check for Y Block Collision
            if (Grid.Rows[block.Position.Y + 1].Blocks[block.Position.X] != null) {
                foreach (Block stoppedBlock in ActivePiece.Blocks) {
                    stoppedBlock.Container = Grid.Rows[stoppedBlock.Position.Y];
                    stoppedBlock.Clear();
                    Grid.Rows[stoppedBlock.Position.Y].Blocks[stoppedBlock.Position.X] = stoppedBlock;
                    stoppedBlock.Display();
                }
                return true;
            }
        }

        return false;
    }
}

public class Grid {
    public int Width { get; init; } = 10;
    public int Height { get; init; } = 30;
    public Row[] Rows { get; set; } = new Row[30];

    // Constructor -------------------------------------------------------------
    public Grid(int width, int height) {
        Width = width;
        Height = height;
        Rows = new Row[Height];

        // Initialize Rows
        for (int i = 0; i < Height; i++) {
            Rows[i] = new Row(Width);
        }
    }
}

public class Row : IBlockContainer {
    public Block[] Blocks { get; set; } = new Block[10];

    // Constructor -------------------------------------------------------------
    public Row(int width) {
        Blocks = new Block[width];
    }
}