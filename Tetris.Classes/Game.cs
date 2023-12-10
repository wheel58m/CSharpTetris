namespace Tetris.Classes;

public static class Game {
    public static Board ActiveBoard { get; set; } = new Board();

    // Methods -----------------------------------------------------------------
    public static void Run() {
        Console.CursorVisible = false; // Hide the Cursor

        ActiveBoard = new Board();
        ActiveBoard.Display();

        Thread userInputThread = new Thread(() => {
            while (true) {
                ConsoleKeyInfo key = Console.ReadKey(true);
                ProcessUserInput(key);
            }
        });

        userInputThread.Start();

        while (true) {
            ActiveBoard.GeneratePiece();

            while (!ActiveBoard.CheckForStop()) {
                ConsoleKeyInfo key = Console.ReadKey(true);
                ProcessUserInput(key);
            }

            if (ActiveBoard.Grid.CheckForCompleteRows()) {
                ActiveBoard.Grid.ClearRows();
                ActiveBoard.Grid.DropRows();
            }
        }
    }
    public static void ProcessUserInput(ConsoleKeyInfo key) {
        switch (key.Key) {
            case ConsoleKey.Spacebar:
                ActiveBoard.ActivePiece?.Drop();
                break;
            case ConsoleKey.LeftArrow:
            case ConsoleKey.A:
                ActiveBoard.ActivePiece?.Move(-1, 0);
                break;
            case ConsoleKey.RightArrow:
            case ConsoleKey.D:
                ActiveBoard.ActivePiece?.Move(1, 0);
                break;
            case ConsoleKey.DownArrow:
            case ConsoleKey.S:
                ActiveBoard.ActivePiece?.Move(0, 1);
                break;
            case ConsoleKey.UpArrow:
                ActiveBoard.ActivePiece?.Rotate();
                break;
            case ConsoleKey.W:
                ActiveBoard.ActivePiece?.Move(0, -1);
                break;
            default:
                ActiveBoard.ActivePiece?.Clear();
                ActiveBoard.GeneratePiece();
                break;
        }
    }
}