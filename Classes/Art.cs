namespace Classes;

public static class Art {
    public static class Block {
        public static string Art { get; } = "[ ]";
        // public static string Art { get; } = "██";
        public static int Width { get; } = Art.Length;
    }
    // Wall Art
    public static class Border {
        public static string TopLeftCorner { get; } = "╔";
        public static string TopRightCorner { get; } = "╗";
        public static string BottomLeftCorner { get; } = "╚";
        public static string BottomRightCorner { get; } = "╝";
        public static string HorizontalWall { get; } = "═";
        public static string VerticalWall { get; } = "║";
    }
}