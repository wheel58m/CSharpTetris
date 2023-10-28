using System.Drawing;
namespace Classes;

public abstract class Piece : IBlockObject {
    public GridCoordinate Location { get; set; }
    public Color Color { get; set; }
    public Block[] Blocks { get; init; } = new Block[4];

    public void Render() {
        foreach (Block block in Blocks) {
            block.Render();
        }
    }
    public void Clear() {
        foreach (Block block in Blocks) {
            block.Clear();
        }
    }
    public void Move(int x, int y) {
        foreach (Block block in Blocks) {
            block.Move(x, y);
        }
    }
    public virtual void Rotate() {
        // Calculate the center of the piece
        (int centerX, int centerY) = Utility.CalculateCenter(this);

        // Rotate each block around the center
        foreach (Block block in Blocks) {
            int newX = centerX + (centerY - block.Location.RowY);
            int newY = centerY - (centerX - block.Location.ColumnX);
            block.Move(newX - block.Location.ColumnX, newY - block.Location.RowY);
        }       
    }
    public void ChangeColor(Color color) {
        Color = color;

        foreach (Block block in Blocks) {
            block.Color = color;
        }
    }
}
public class IPiece : Piece {
    public IPiece(GridCoordinate location, Color color) {
        Location = location;
        Color = color;
        Blocks = new Block[] {
            // new(new GridCoordinate(location.ColumnX, location.RowY), Color.Yellow),
            new(new GridCoordinate(location.ColumnX, location.RowY), color),
            new(new GridCoordinate(location.ColumnX, location.RowY + 1), color),
            new(new GridCoordinate(location.ColumnX, location.RowY + 2), color),
            new(new GridCoordinate(location.ColumnX, location.RowY + 3), color)
        };
    }
}
public class OPiece : Piece {
    public OPiece(GridCoordinate location, Color color) {
        Location = location;
        Color = color;
        Blocks = new Block[] {
            // new(new GridCoordinate(location.ColumnX, location.RowY), Color.Yellow),
            new(new GridCoordinate(location.ColumnX, location.RowY), color),
            new(new GridCoordinate(location.ColumnX + 1, location.RowY), color),
            new(new GridCoordinate(location.ColumnX, location.RowY + 1), color),
            new(new GridCoordinate(location.ColumnX + 1, location.RowY + 1), color)
        };
    }
    public override void Rotate() { 
        Render(); // Rotate does nothing for the O piece, except render it again
    }
}
public class TPiece : Piece {
    public TPiece(GridCoordinate location, Color color) {
        Location = location;
        Color = color;
        Blocks = new Block[] {
            // new(new GridCoordinate(location.ColumnX, location.RowY), Color.Yellow),
            new(new GridCoordinate(location.ColumnX, location.RowY), color),
            new(new GridCoordinate(location.ColumnX - 1, location.RowY), color),
            new(new GridCoordinate(location.ColumnX + 1, location.RowY), color),
            new(new GridCoordinate(location.ColumnX, location.RowY + 1), color)
        };
    }
}
public class SPiece : Piece {
    public SPiece(GridCoordinate location, Color color) {
        Location = location;
        Color = color;
        Blocks = new Block[] {
            // new(new GridCoordinate(location.ColumnX, location.RowY), Color.Yellow),
            new(new GridCoordinate(location.ColumnX, location.RowY), color),
            new(new GridCoordinate(location.ColumnX + 1, location.RowY), color),
            new(new GridCoordinate(location.ColumnX, location.RowY + 1), color),
            new(new GridCoordinate(location.ColumnX - 1, location.RowY + 1), color)
        };
    }
}
public class ZPiece : Piece {
    public ZPiece(GridCoordinate location, Color color) {
        Location = location;
        Color = color;
        Blocks = new Block[] {
            // new(new GridCoordinate(location.ColumnX, location.RowY), Color.Yellow),
            new(new GridCoordinate(location.ColumnX, location.RowY), color),
            new(new GridCoordinate(location.ColumnX - 1, location.RowY), color),
            new(new GridCoordinate(location.ColumnX, location.RowY + 1), color),
            new(new GridCoordinate(location.ColumnX + 1, location.RowY + 1), color)
        };
    }
}
public class JPiece : Piece {
    public JPiece(GridCoordinate location, Color color) {
        Location = location;
        Color = color;
        Blocks = new Block[] {
            // new(new GridCoordinate(location.ColumnX, location.RowY), Color.Yellow),
            new(new GridCoordinate(location.ColumnX, location.RowY), color),
            new(new GridCoordinate(location.ColumnX, location.RowY + 1), color),
            new(new GridCoordinate(location.ColumnX, location.RowY + 2), color),
            new(new GridCoordinate(location.ColumnX - 1, location.RowY + 2), color)
        };
    }
}
public class LPiece : Piece {
    public LPiece(GridCoordinate location, Color color) {
        Location = location;
        Color = color;
        Blocks = new Block[] {
            // new(new GridCoordinate(location.ColumnX, location.RowY), Color.Yellow),
            new(new GridCoordinate(location.ColumnX, location.RowY), color),
            new(new GridCoordinate(location.ColumnX, location.RowY + 1), color),
            new(new GridCoordinate(location.ColumnX, location.RowY + 2), color),
            new(new GridCoordinate(location.ColumnX + 1, location.RowY + 2), color)
        };
    }
}