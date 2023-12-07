namespace Tetris.Classes;

// STRUCTS ---------------------------------------------------------------------
public struct GridCoordinate {
    public int X { get; set; }
    public int Y { get; set; }

    // Constructor
    public GridCoordinate(int x, int y) => (X, Y) = (x, y);
}

// ENUMS -----------------------------------------------------------------------
public enum Color { Black, Blue, Green, Cyan, Red, Magenta, Yellow, White, DarkGray } // Colors
public enum Orientation { Up, Right, Down, Left } // Orientations

// CLASS VALUES ----------------------------------------------------------------
public static class Constants {
    public static Dictionary<Color, ConsoleColor> ColorDictionary = new Dictionary<Color, ConsoleColor> {
        { Color.Black, ConsoleColor.Black },
        { Color.Blue, ConsoleColor.Blue },
        { Color.Green, ConsoleColor.Green },
        { Color.Cyan, ConsoleColor.Cyan },
        { Color.Red, ConsoleColor.Red },
        { Color.Magenta, ConsoleColor.Magenta },
        { Color.Yellow, ConsoleColor.Yellow },
        { Color.White, ConsoleColor.White },
        { Color.DarkGray, ConsoleColor.DarkGray }
    };
}