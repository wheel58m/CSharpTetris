namespace Tetris.Classes;

// STRUCTS ---------------------------------------------------------------------
public record GridCoordinate(int X, int Y) {
    private int BorderXOffset => X < 0 ? -1 : 1; // The x offset from the border of the grid
    private int BorderYOffset => Y < 0 ? -1 : 1; // The y offset from the border of the grid

    // Methods
    public (int, int) ConvertToConsoleCoordinate() => (X * 3 + BorderXOffset, Y + BorderYOffset); // Converts the grid coordinate to a console cursor position
}

// ENUMS -----------------------------------------------------------------------
public enum Color { Blue, Green, Cyan, Red, Magenta, Yellow, White, DarkGray } // Colors
public enum Shape { I, O, T, L, J, S, Z } // Tetromino Shapes
public enum Orientation { Up, Right, Down, Left } // Orientations

// CLASS VALUES ----------------------------------------------------------------
public static class Constants {
    public static readonly Dictionary<Color, ConsoleColor> ColorDictionary = new Dictionary<Color, ConsoleColor> {
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