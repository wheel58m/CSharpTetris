using System.Drawing;
namespace Classes;

public abstract class Piece : IBlockObject {
    public GridCoordinate Location { get; set; }
    public Color Color { get; set; }
    public Rotation Orientation { get; set; }
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
    public void Move(int x, int y, bool rerender = true) {
        if (rerender) {
            Clear(); // Erase the piece from the console
        }
        foreach (Block block in Blocks) {
            block.Move(x, y);
        }

        // Update Location Property
        Location = new GridCoordinate(Location.ColumnX + x, Location.RowY + y);
    }
    public virtual void Rotate(bool clear = true) {
        // Clear Piece
        if (clear) {
            Clear();
        }

        // Calculate the center of the piece
        (int centerX, int centerY) = Utility.CalculateCenter(this);

        // Rotate each block around the center
        foreach (Block block in Blocks) {
            int newX = centerX + (centerY - block.Location.RowY);
            int newY = centerY - (centerX - block.Location.ColumnX);
            block.Move(newX - block.Location.ColumnX, newY - block.Location.RowY);
        }

        // Update Location Property
        Location = Blocks[0].Location;

        // Update Orientation Property
        Orientation++; 
    }
    public void EnforceBounds((int xMin, int xMax, int yMin, int yMax) bounds, bool stickToTop = false) {
        (int x, int y) = (0, 0);
        int stickyYOffset = Blocks[0].Location.RowY;

        foreach (Block block in Blocks) {
            if (block.Location.ColumnX < bounds.xMin) {
                x = bounds.xMin - block.Location.ColumnX;
            }
            else if (block.Location.ColumnX > bounds.xMax) {
                x = bounds.xMax - block.Location.ColumnX;
            }
            else if (block.Location.RowY < bounds.yMin) {
                y = bounds.yMin - block.Location.RowY;
            }
            else if (block.Location.RowY > bounds.yMax) {
                y = bounds.yMax - block.Location.RowY;
            }

            // Identify minimum y value for the piece
            if (block.Location.RowY < stickyYOffset) {
                stickyYOffset = block.Location.RowY;
            }
        }

        // If the piece should stick to the top of the board, calculate the y offset.
        if (stickToTop && stickyYOffset > bounds.yMin) {
            y = bounds.yMin - stickyYOffset;
        }

        Move(x, y, false);
    }
    public void ChangeColor(Color color) {
        Color = color;

        foreach (Block block in Blocks) {
            block.Color = color;
        }
    }
}
public class IPiece : Piece {
    public IPiece(GridCoordinate location, Color color , Rotation orientation = Rotation.Up) {
        Location = location;
        Color = color;
        Orientation = orientation;
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
    public OPiece(GridCoordinate location, Color color, Rotation orientation = Rotation.Up) {
        Location = location;
        Color = color;
        Orientation = orientation;
        Blocks = new Block[] {
            // new(new GridCoordinate(location.ColumnX, location.RowY), Color.Yellow),
            new(new GridCoordinate(location.ColumnX, location.RowY), color),
            new(new GridCoordinate(location.ColumnX + 1, location.RowY), color),
            new(new GridCoordinate(location.ColumnX, location.RowY + 1), color),
            new(new GridCoordinate(location.ColumnX + 1, location.RowY + 1), color)
        };
    }
    public override void Rotate(bool clear = false) { 
        Render(); // Rotate does nothing for the O piece, except render it again
    }
}
public class TPiece : Piece {
    public TPiece(GridCoordinate location, Color color, Rotation orientation = Rotation.Up) {
        Location = location;
        Color = color;
        Orientation = orientation;
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
    public SPiece(GridCoordinate location, Color color, Rotation orientation = Rotation.Up) {
        Location = location;
        Color = color;
        Orientation = orientation;
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
    public ZPiece(GridCoordinate location, Color color, Rotation orientation = Rotation.Up) {
        Location = location;
        Color = color;
        Orientation = orientation;
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
    public JPiece(GridCoordinate location, Color color, Rotation orientation = Rotation.Up) {
        Location = location;
        Color = color;
        Orientation = orientation;
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
    public LPiece(GridCoordinate location, Color color, Rotation orientation = Rotation.Up) {
        Location = location;
        Color = color;
        Orientation = orientation;
        Blocks = new Block[] {
            // new(new GridCoordinate(location.ColumnX, location.RowY), Color.Yellow),
            new(new GridCoordinate(location.ColumnX, location.RowY), color),
            new(new GridCoordinate(location.ColumnX, location.RowY + 1), color),
            new(new GridCoordinate(location.ColumnX, location.RowY + 2), color),
            new(new GridCoordinate(location.ColumnX + 1, location.RowY + 2), color)
        };
    }
}

public enum Rotation { Up, Right, Down, Left }