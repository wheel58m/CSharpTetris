namespace Tetris.Classes;

public static class Game {
    public static Board ActiveBoard { get; set; } = new Board();

    // Methods -----------------------------------------------------------------
    public static void Run() {
        Console.CursorVisible = false; // Hide the Cursor
        ActiveBoard = new Board();
        ActiveBoard.Display();
        
        ActiveBoard.GeneratePiece();
        // ActiveBoard.GeneratePiece(new IPiece(new GridCoordinate(5, -2), Color.Blue, Orientation.Down));
        // ActiveBoard.ActivePiece = new ZPiece(new GridCoordinate(1, 1), Color.Green);
        // ActiveBoard.ActivePiece.Display();

        while (true) {
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