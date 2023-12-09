namespace Tetris.Classes;

public static class Game {
    public static Board ActiveBoard { get; set; } = new Board();

    // Methods -----------------------------------------------------------------
    public static void Run() {
        Console.CursorVisible = false; // Hide the Cursor
        ActiveBoard = new Board();
        ActiveBoard.Display();

        ActiveBoard.GeneratePiece();
        // ActiveBoard.ActivePiece = new ZPiece(new GridCoordinate(1, 1), Color.Green);
        // ActiveBoard.ActivePiece.Display();
        // ActiveBoard.ActivePiece?.Fall(ActiveBoard.FallSpeed);

        while (true) {
            Console.SetCursorPosition(0, ActiveBoard.Height + 2);
            for (int i = 0; i < 50; i++) {
                Console.Write(" ");
            }
            Console.WriteLine();
            for (int i = 0; i < 50; i++) {
                Console.Write(" ");
            }
            Console.WriteLine();
            for (int i = 0; i < 50; i++) {
                Console.Write(" ");
            }
            Console.SetCursorPosition(0, ActiveBoard.Height + 2);
            Console.WriteLine($"Shape: {ActiveBoard.ActivePiece?.Shape}");
            Console.WriteLine($"Position: ({ActiveBoard.ActivePiece?.Position.X}, {ActiveBoard.ActivePiece?.Position.Y})");
            Console.WriteLine($"Orientation: {ActiveBoard.ActivePiece?.Orientation}");

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key) {
                case ConsoleKey.Spacebar:
                    ActiveBoard.ActivePiece?.Rotate();
                    break;
                case ConsoleKey.LeftArrow:
                    if (ActiveBoard.CheckForCollision(-1, 0)) {
                        ActiveBoard.ActivePiece?.Move(-1, 0);
                    }
                    ActiveBoard.ActivePiece?.Move(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    if (ActiveBoard.CheckForCollision(1, 0)) {
                        ActiveBoard.ActivePiece?.Move(1, 0);
                    }
                    ActiveBoard.ActivePiece?.Move(1, 0);
                    break;
                case ConsoleKey.DownArrow:
                    if (ActiveBoard.CheckForCollision(0, 1)) {
                        ActiveBoard.ActivePiece?.Move(0, 1);
                    }
                    ActiveBoard.ActivePiece?.Move(0, 1);
                    break;
                case ConsoleKey.UpArrow:
                    if (ActiveBoard.CheckForCollision(0, -1)) {
                        ActiveBoard.ActivePiece?.Move(0, -1);
                    }
                    ActiveBoard.ActivePiece?.Move(0, -1);
                    break;
                default:
                    ActiveBoard.ActivePiece?.Clear();
                    ActiveBoard.GeneratePiece();
                    break;
            }
        }
    }
}