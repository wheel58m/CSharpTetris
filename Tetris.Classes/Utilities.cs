namespace Tetris.Classes;

public static class Utilities {
    public static class Debug {
        public static bool ShowBlockID { get; set; } = false;
        public static bool ShowPieceInfo { get; set; } = true;
        public static void DisplayPieceInfo(Piece piece) {
            Console.SetCursorPosition(0, piece.ActiveBoard.Height + 2);
            ClearLine();
            ClearLine();
            ClearLine();
            ClearLine();
            Console.SetCursorPosition(0, piece.ActiveBoard.Height + 2);
            Console.WriteLine($"Shape: {piece.Shape}");
            Console.WriteLine($"Position: ({piece.Position.X}, {piece.Position.Y})");
            Console.WriteLine($"Orientation: {piece.Orientation}");
            Console.WriteLine($"Color: {piece.Color} ({(int)piece.Color!})");
        }
    }
    public static void ClearLine() {
        for (int i = 0; i < 50; i++) {
            Console.Write(" ");
        }
        Console.WriteLine();
    }
}