namespace Classes;

public struct GridCoordinate {
    public int ColumnX { get; set; }
    public int RowY { get; set; }

    public GridCoordinate(int x, int y) {
        ColumnX = x;
        RowY = y;
    }

    public readonly (int, int) ConvertToConsoleCoordinates() {
        return (ColumnX * Art.Block.Width + Settings.BoardBuffer, RowY + Settings.BoardBuffer);
    }
}