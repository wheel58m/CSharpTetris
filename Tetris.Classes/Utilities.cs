namespace Tetris.Classes;

public static class Utilities {
    public static class Debug {
        public static bool ShowBlockID { get; set; } = false;
    }
    public static void ClearLine() {
        for (int i = 0; i < 50; i++) {
            Console.Write(" ");
        }
        Console.WriteLine();
    }
}