namespace Tetris.Classes;

public static class Game {
    public static Board ActiveBoard { get; set; } = new Board();

    // Methods -----------------------------------------------------------------
    public static void Run() {
        Console.CursorVisible = false; // Hide the Cursor
        ActiveBoard.Display();

        while (true) {
            ActiveBoard.ActivePiece?.Clear();
            ActiveBoard.ActivePiece = ActiveBoard.GeneratePiece();
            ActiveBoard.ActivePiece.Display();

            Console.ReadKey(true);
        }
    }
}