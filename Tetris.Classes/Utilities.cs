using System.Runtime.InteropServices;
namespace Tetris.Classes;

public static class Utilities {
    public static bool ShowBackground { get; set; } = false;
    public static string DefaultBlockSymbol { get; set; } = $"[#]";
    public static string EmptyBlockSymbol { get; set; } = "   ";

    // Debug Tool --------------------------------------------------------------
    public static class Debug {
        public static bool ShowBlockID { get; set; } = false;
        public static bool ShowDebugInfo { get; set; } = false;
        public static DebugItem DebugInfo { get; set; } = DebugItem.Board;
        public static bool Fall { get; set; } = true;
        public static void DisplayBoardInfo(Board board) {
            ClearInfo();
            Console.SetCursorPosition(0, board.Height + 2);
            Console.WriteLine($"Fallspeed: {board.FallSpeed}");   
        }
        public static void DisplayPieceInfo(Piece piece) {
            ClearInfo();
            Console.SetCursorPosition(0, piece.ActiveBoard.Height + 2);
            Console.WriteLine($"Shape: {piece.Shape}");
            Console.WriteLine($"Position: ({piece.Position.X}, {piece.Position.Y})");
            Console.WriteLine($"Orientation: {piece.Orientation}");
            Console.WriteLine($"Color: {piece.Color} ({(int)piece.Color!})");
        }
        public static void DisplayBlocksInfo(Block[] blocks) {
            ClearInfo();
            Console.SetCursorPosition(0, Game.ActiveBoard.Height + 2);
            foreach (Block block in blocks) {
                Console.WriteLine($"Block {block.GetID()}: ({block.Position.X}, {block.Position.Y})");
            }
        }
        public static void ClearInfo() {
            Console.SetCursorPosition(0, Game.ActiveBoard.Height + 2);
            ClearLine();
            ClearLine();
            ClearLine();
            ClearLine();
        
        }
    }
    // Console Utilities -------------------------------------------------------
        public static void Resize(int x, int y) {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                Console.WindowWidth = x;
                Console.WindowHeight = y;
            } else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
                MacTerminal.ResizeTerminal(x, y);
            }
        }
        // Code To Resize Terminal Window on Mac (https://stackoverflow.com/questions/31522500/mono-resize-terminal-on-mac-os-x)
        public static class MacTerminal {
            [DllImport ("libc")]
            private static extern int system (string exec);

            public static void ResizeTerminal (int x, int y) {
                system(@$"printf '\e[8;{x};{y}t'");
            }
        }
    public static void ClearLine() {
        for (int i = 0; i < 50; i++) {
            Console.Write(" ");
        }
        Console.WriteLine();
    }
    public static void PrintError(string message) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}

public enum DebugItem { Game, Board, Piece, Block }