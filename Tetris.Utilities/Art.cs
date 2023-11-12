namespace Tetris.Utilities;

public static class Art {
    public static class Block {
        public static string[] Art { get; } = new string[] { "[ ]" };
        public static int Width { get; } = Art[0].Length;
        public static int Height { get; } = Art.Length;
    }
}