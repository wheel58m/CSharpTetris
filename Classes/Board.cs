using System.Drawing;
namespace Classes;

public class Board {
    public GridCoordinate Location { get; }
    public (int xMin, int xMax, int yMin, int yMax) Bounds { get; init; }
    public Row[] Rows { get; set; }
    public Piece? ActivePiece { get; set; }

    public Board(int x = 0, int y = 0, int width = 10, int height = 20) {
        Location = new GridCoordinate(x, y);
        Rows = new Row[height];
        for (int i = 0; i < Rows.Length; i++) {
            Rows[i] = new Row(width);
        }
        // Calculate Board Boundaries
        Bounds = (
            xMin: Location.ColumnX,
            xMax: Location.ColumnX + Rows[0].Blocks.Length,
            yMin: Location.RowY,
            yMax: Location.RowY + Rows.Length
        );
    }
    public void Render() {
        // Convert Grid Coordinates to Console Coordinates
        (int x, int y) minimum = Location.ConvertToConsoleCoordinates();
        (int x, int y) maximum = new GridCoordinate(Bounds.xMax, Bounds.yMax).ConvertToConsoleCoordinates();

        // Calculate Console Coordinates for Board Boundaries
        int top = minimum.y - (Settings.BoardBuffer - 1);
        int bottom = maximum.y + (Settings.BoardBuffer - 2);
        int left = minimum.x - (Settings.BoardBuffer - 1);
        int right = maximum.x + (Settings.BoardBuffer - 2);

        // Render Top Border
        Console.SetCursorPosition(left, top);
        Console.Write(Art.Border.TopLeftCorner);
        for (int i = 1; i < right - left; i++) {
            Console.Write(Art.Border.HorizontalWall);
        }
        Console.Write(Art.Border.TopRightCorner);

        // Render Left Border
        for (int i = 1; i < bottom - top + 1; i++) {
            Console.SetCursorPosition(left, top + i);
            Console.Write(Art.Border.VerticalWall);
        }

        // Render Right Border
        for (int i = 1; i < bottom - top + 1; i++) {
            Console.SetCursorPosition(right, top + i);
            Console.Write(Art.Border.VerticalWall);
        }

        // Render Bottom Border
        Console.SetCursorPosition(left, bottom);
        Console.Write(Art.Border.BottomLeftCorner);
        for (int i = 1; i < right - left; i++) {
            Console.Write(Art.Border.HorizontalWall);
        }
        Console.Write(Art.Border.BottomRightCorner);
    }
    public void GeneratePiece() {
        // Get Random Shape
        Random random = new();
        int shape = random.Next(0, 7);

        // Set Position
        (int x, int y) position = (0, 0);

        // Get Random Color
        Color color = Utility.GetRandomColor();

        // Get Random Rotation
        int rotation = random.Next(0, 4);
        // int rotation = 3;

        // Create Piece
        switch (shape) {
            case 0:
                ActivePiece = new IPiece(new GridCoordinate(position.x, position.y), color);
                break;
            case 1:
                ActivePiece = new OPiece(new GridCoordinate(position.x, position.y), color);
                break;
            case 2:
                ActivePiece = new TPiece(new GridCoordinate(position.x, position.y), color);
                break;
            case 3:
                ActivePiece = new LPiece(new GridCoordinate(position.x, position.y), color);
                break;
            case 4:
                ActivePiece = new JPiece(new GridCoordinate(position.x, position.y), color);
                break;
            case 5:
                ActivePiece = new SPiece(new GridCoordinate(position.x, position.y), color);
                break;
            case 6:
                ActivePiece = new ZPiece(new GridCoordinate(position.x, position.y), color);
                break;
            default:
                ActivePiece = new IPiece(new GridCoordinate(position.x, position.y), color);
                break;
        }

        // ActivePiece = new IPiece(new GridCoordinate(position.x, position.y), color);

        // Constrain Piece to Bounds
        if (!WithinBounds(ActivePiece)) {
            ActivePiece.EnforceBounds(Bounds, true);
        }

        // Rotate Piece
        for (int i = 0; i < rotation; i++) {
            ActivePiece.Rotate(false);
            ActivePiece.EnforceBounds(Bounds, true);
        }

        // Render Piece
        ActivePiece.Render();
    }

    public bool WithinBounds(Piece piece) {
        foreach (Block block in piece.Blocks) {
            if (block.Location.ColumnX < Bounds.xMin || block.Location.ColumnX > Bounds.xMax) {
                return false;
            }
            if (block.Location.RowY < Bounds.yMin || block.Location.RowY > Bounds.yMax) {
                return false;
            }
        }
        return true;
    }
}
public class Row {
    public Block[] Blocks { get; set; }
    public Row(int width) {
        Blocks = new Block[width];
    }
}