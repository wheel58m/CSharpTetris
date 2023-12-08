namespace Tetris.Classes;

public static class Game {
    public static Board ActiveBoard { get; set; } = new Board();

    // Methods -----------------------------------------------------------------
    public static void Run() {
        Console.CursorVisible = false; // Hide the Cursor
        ActiveBoard.Display();

        ActiveBoard.GeneratePiece();
        ActiveBoard.ActivePiece.Display();
        // ActiveBoard.ActivePiece.Fall(ActiveBoard.FallSpeed);

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
            Console.WriteLine($"Shape: {ActiveBoard.ActivePiece.Shape}");
            Console.WriteLine($"Position: ({ActiveBoard.ActivePiece.Position.X}, {ActiveBoard.ActivePiece.Position.Y})");
            Console.WriteLine($"Orientation: {ActiveBoard.ActivePiece.Orientation}");

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key) {
                case ConsoleKey.Spacebar:
                    ActiveBoard.ActivePiece.Rotate();
                    break;
                case ConsoleKey.LeftArrow:
                    ActiveBoard.ActivePiece.Move(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    ActiveBoard.ActivePiece.Move(1, 0);
                    break;
                case ConsoleKey.DownArrow:
                    ActiveBoard.ActivePiece.Move(0, 1);
                    break;
                case ConsoleKey.UpArrow:
                    ActiveBoard.ActivePiece.Move(0, -1);
                    break;
                default:
                    ActiveBoard.ActivePiece?.Clear();
                    ActiveBoard.ActivePiece = ActiveBoard.GeneratePiece();
                    ActiveBoard.ActivePiece.Display();
                    break;
            }
        }
    }
}