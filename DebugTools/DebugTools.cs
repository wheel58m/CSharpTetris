using Classes;
using System.Drawing;
namespace DebugTools;

public static class BoardDebug {
    public static void FillGrid(Board board) {
        for (int i = 0; i < board.Rows.Length; i++) {
            for (int j = 0; j < board.Rows[i].Blocks.Length; j++) {
                board.Rows[i].Blocks[j] = new Block(new GridCoordinate(j, i), Color.Red);
                board.Rows[i].Blocks[j].Render();
            }
        }
        Console.SetCursorPosition(0, board.Bounds.yMax + 3);
    }
}
public static class PieceDebug {
    public static void HighlightOrigin(Piece piece, Color color = default) {
        if (color == default) {
            color = Color.Yellow;
        }
        Block origin = piece.Blocks[0];
        origin.Color = color;
        origin.Render();
    }
    public static void HighlightCenter(Piece piece, Color color = default) {
        if (color == default) {
            color = Color.Yellow;
        }

        (int centerX, int centerY) = Utility.CalculateCenter(piece);
        foreach (Block block in piece.Blocks) {
            if (block.Location.ColumnX == centerX && block.Location.RowY == centerY) {
                block.Color = color;
                block.Render();
            }
        }
    }
}