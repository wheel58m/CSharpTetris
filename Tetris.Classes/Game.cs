namespace Tetris.Classes;

public static class Game {
    public static Board ActiveBoard { get; set; } = new Board();

    // Methods -----------------------------------------------------------------
    public static void Run() {
        Console.CursorVisible = false; // Hide the Cursor
        ActiveBoard = new Board();
        ActiveBoard.Display();

        while (true) {
            ActiveBoard.GeneratePiece();
            // ActiveBoard.GeneratePiece(new IPiece(new GridCoordinate(5, -2), Color.Blue, Orientation.Down));
            // ActiveBoard.ActivePiece = new ZPiece(new GridCoordinate(1, 1), Color.Green);
            // ActiveBoard.ActivePiece.Display();

            while (!ActiveBoard.CheckForStop()) {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key) {
                    case ConsoleKey.Spacebar:
                        ActiveBoard.ActivePiece?.Rotate();
                        continue;
                    case ConsoleKey.LeftArrow:
                        ActiveBoard.ActivePiece?.Move(-1, 0);
                        continue;
                    case ConsoleKey.RightArrow:
                        ActiveBoard.ActivePiece?.Move(1, 0);
                        continue;
                    case ConsoleKey.DownArrow:
                        ActiveBoard.ActivePiece?.Drop();
                        continue;
                    case ConsoleKey.UpArrow:
                        ActiveBoard.ActivePiece?.Move(0, -1);
                        continue;
                    default:
                        break;
                }
            }
        }
    }
}