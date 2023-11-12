namespace Tetris.Utilities;

public struct GridPosition {
    public int X { get; set; }
    public int Y { get; set; }

    public GridPosition(int x, int y) {
        X = x;
        Y = y;
    }

    // Conversion Utility (GridPosition -> CursorPosition)
    public (int, int) ToCursorPosition(int gridWidth = -1, int gridHeight = -1) {
        // Optional Parameters for Testing
        gridWidth = gridWidth == -1 ? Art.Block.Width : gridWidth;
        gridHeight = gridHeight == -1 ? Art.Block.Height : gridHeight;

        return (X * gridWidth, Y * gridHeight);
    }
}