using System.Drawing;
namespace Classes;

public static class Utility {
    public static readonly Dictionary<Color, ConsoleColor> ColorMap = new() {
        { Color.Black, ConsoleColor.Black },
        { Color.Blue, ConsoleColor.Blue },
        { Color.Cyan, ConsoleColor.Cyan },
        { Color.DarkBlue, ConsoleColor.DarkBlue },
        { Color.DarkCyan, ConsoleColor.DarkCyan },
        { Color.DarkGray, ConsoleColor.DarkGray },
        { Color.DarkGreen, ConsoleColor.DarkGreen },
        { Color.DarkMagenta, ConsoleColor.DarkMagenta },
        { Color.DarkRed, ConsoleColor.DarkRed },
        { Color.DarkOrange, ConsoleColor.DarkYellow },
        { Color.Gray, ConsoleColor.Gray },
        { Color.Green, ConsoleColor.Green },
        { Color.Magenta, ConsoleColor.Magenta },
        { Color.Red, ConsoleColor.Red },
        { Color.White, ConsoleColor.White },
        { Color.Yellow, ConsoleColor.Yellow }
    };
}