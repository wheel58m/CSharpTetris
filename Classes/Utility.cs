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
    public static Color GetRandomColor() {
        Random random = new();
        int randomColorIndex = random.Next(0, ColorMap.Count);
        return ColorMap.Keys.ElementAt(randomColorIndex);
    }
    // Get a random color that is not the same as the given color
    public static Color GetRandomColor(Color color) {
        Random random = new();
        int randomColorIndex = random.Next(0, ColorMap.Count);
        Color randomColor = ColorMap.Keys.ElementAt(randomColorIndex);

        while (randomColor == color) {
            randomColorIndex = random.Next(0, ColorMap.Count);
            randomColor = ColorMap.Keys.ElementAt(randomColorIndex);
        }

        return randomColor;
    }
    public static (int columnX, int rowY) CalculateCenter(Piece piece) {
        int centerX = 0;
        int centerY = 0;

        switch (piece) {
            case OPiece:
                centerX = piece.Blocks[0].Location.ColumnX;
                centerY = piece.Blocks[0].Location.RowY;
                break;
            case IPiece:
                centerX = piece.Blocks[1].Location.ColumnX;
                centerY = piece.Blocks[1].Location.RowY;
                break;
            case TPiece:
                centerX = piece.Blocks[0].Location.ColumnX;
                centerY = piece.Blocks[0].Location.RowY;
                break;
            case LPiece:
                centerX = piece.Blocks[1].Location.ColumnX;
                centerY = piece.Blocks[1].Location.RowY;
                break;
            case JPiece:
                centerX = piece.Blocks[1].Location.ColumnX;
                centerY = piece.Blocks[1].Location.RowY;
                break;
            case SPiece:
                centerX = piece.Blocks[0].Location.ColumnX;
                centerY = piece.Blocks[0].Location.RowY;
                break;
            case ZPiece:
                centerX = piece.Blocks[0].Location.ColumnX;
                centerY = piece.Blocks[0].Location.RowY;
                break;
        }

        return (centerX, centerY);
    }
}