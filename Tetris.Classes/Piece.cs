using static Tetris.Classes.Color; // Allows the use the Color enum values without the enum name
using static Tetris.Classes.Orientation; // Allows the use the Orientation enum values without the enum name
namespace Tetris.Classes;

public abstract class Piece : IBlockContainer {
    public Shape Shape { get; set; } = Shape.I;
    public Block[] Blocks { get; set; } = new Block[4];
    public Color Color { get; set; } = Green;
    public GridCoordinate Position { get; set; } = new GridCoordinate(0, 0); // Position is Pivot Point (Except for I Piece)
    public Orientation Orientation { get; set; } = Up;
    public Board ActiveBoard { get; init; } = Game.ActiveBoard;

    // Constructor -------------------------------------------------------------
    public Piece(GridCoordinate position, Color color = Green, Orientation orientation = Up) {
        Position = position;
        Color = color;
        Orientation = orientation;
        ActiveBoard = Game.ActiveBoard;
        Shape = Enum.Parse<Shape>(GetType().Name.Replace("Piece", ""));
    }

    // Methods -----------------------------------------------------------------
    public abstract void Build(Orientation orientation);
    public void Display() {
        foreach (Block block in Blocks) {
            try {
                block.Display();
            } catch (Exception ex) when (ex is NullReferenceException || ex is ArgumentOutOfRangeException) {
                HandleException(ex, block);
            }
        }
        Utilities.Debug.DisplayPieceInfo(this);
    }
    public void Clear() {
        foreach (Block block in Blocks) {
            try {
                block.Clear();
            } catch (Exception ex) when (ex is NullReferenceException || ex is ArgumentOutOfRangeException) {
                HandleException(ex, block);
            }
        }
    }
    public virtual void Rotate() {
        Clear();
        Orientation = (Orientation)(((int)Orientation == 3 ? 0 : (int)Orientation + 1) % 4);
        Build(Orientation);
        Display();
    }
    public void Move(int x, int y, bool rerender = true, bool checkForCollision = true) {
        if (checkForCollision) {
            if (ActiveBoard.CheckForCollision(x, y)) { return; } // Check for Boundary Collision
        }

        if (rerender) Clear();
        Position = new GridCoordinate(Position.X + x, Position.Y + y);

        foreach (Block block in Blocks) {
            block.Move(x, y);
        }

        if (rerender) Display();
    }
    public void Drop() {
        Fall(20);
    }
    public void Fall(int speed) {
        while (!ActiveBoard.CheckForStop()) {
            Move(0, 1);
            Thread.Sleep(speed);
        }
    }
    public virtual bool CanRotate() {
        // Check If Rotation Will Exceed Board Boundary
        if (Position.X <= 0 || Position.X == ActiveBoard.Width - 1 || Position.Y == 0 || Position.Y == ActiveBoard.Height - 1) {
            return false; 
        }

        return true;
    }

    // Debug Methods -----------------------------------------------------------
    #region Debug Methods
    public void HandleException(Exception ex, Block block) {
        Console.WriteLine($"{ex.GetType().Name} caught: {ex.Message}");
        DisplayPieceInfo();
        block?.DisplayBlockInfo();
    }
    public void DisplayPieceInfo() {
        Console.WriteLine($"Piece Details: Shape: {Shape}, Block Count: {Blocks.Length}, Color: {Color}, Position: ({Position.X}, {Position.Y}), Orientation: {Orientation}, ActiveBoard: {ActiveBoard}");
    }
    #endregion
}
public class IPiece : Piece {
    // Constructor -------------------------------------------------------------
    public IPiece(GridCoordinate position, Color color = Green, Orientation orientation = Up) : base(position, color, orientation) {
        Build(orientation);
    }

    // Methods -----------------------------------------------------------------
    public override void Build(Orientation orientation) {
        // All block positions are the rotated positions of the Up orientation
        switch (orientation) {
            case Up: // Horizontal Top
                // Position is Top Left Corner of Rotation Box
                Blocks[0] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 1), Color, this); // Origin: Left Block (Up Orientation)
                Blocks[1] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color, this);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 1), Color, this);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 3, Position.Y + 1), Color, this);
                break;
            case Right: // Vertical Right
                // Position is Top Left Corner of Rotation Box
                Blocks[0] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 0), Color, this); // Origin: Left Block (Up Orientation) – Top Block
                Blocks[1] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 1), Color, this);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 2), Color, this);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 3), Color, this);
                break;
            case Down: // Horizontal Bottom
                // Position is Top Left Corner of Rotation Box
                Blocks[0] = new Block(new GridCoordinate(Position.X + 3, Position.Y + 2), Color, this); // Origin: Left Block (Up Orientation) – Right Block
                Blocks[1] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 2), Color, this);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 2), Color, this);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 2), Color, this);
                break;
            case Left: // Vertical Left
               // Position is Top Left Corner of Rotation Box
                Blocks[0] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 3), Color, this); // Origin: Left Block (Up Orientation) – Bottom Block
                Blocks[1] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 2), Color, this);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color, this);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 0), Color, this);
                break;
        }
    }
    public override void Rotate() {
        if (Position.X < 0 || Position.X == ActiveBoard.Width - 4 || Position.Y < 0 || Position.Y > ActiveBoard.Height - 5) { return; }

        base.Rotate(); // Call the base Rotate method to rotate the piece
    }
}
public class OPiece : Piece {
    // Constructor -------------------------------------------------------------
    public OPiece(GridCoordinate position, Color color = Green, Orientation orientation = Up) : base(position, color, orientation) {
        Build(orientation);
    }

    // Methods -----------------------------------------------------------------
    public override void Build(Orientation orientation) {
        Blocks[0] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 0), Color, this);
        Blocks[1] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 0), Color, this);
        Blocks[2] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 1), Color, this);
        Blocks[3] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color, this);
    }
    public override void Rotate() { }
}
public class TPiece : Piece {
    // Constructor -------------------------------------------------------------
    public TPiece(GridCoordinate position, Color color = Green, Orientation orientation = Up) : base(position, color, orientation) {
        Build(orientation);
    }

    // Methods -----------------------------------------------------------------
    public override void Build(Orientation orientation) {
        switch (orientation) {
            case Up: // ⊤
                Blocks[0] = new Block(new GridCoordinate(Position.X, Position.Y), Color, this); // Origin: Pivot Point
                Blocks[1] = new Block(new GridCoordinate(Position.X - 1, Position.Y), Color, this);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 1, Position.Y), Color, this);
                Blocks[3] = new Block(new GridCoordinate(Position.X, Position.Y + 1), Color, this);
                break;
            case Right: // ⊣
                Blocks[0] = new Block(new GridCoordinate(Position.X, Position.Y), Color, this); // Origin: Pivot Point
                Blocks[1] = new Block(new GridCoordinate(Position.X, Position.Y - 1), Color, this);
                Blocks[2] = new Block(new GridCoordinate(Position.X, Position.Y + 1), Color, this);
                Blocks[3] = new Block(new GridCoordinate(Position.X - 1, Position.Y), Color, this);
                break;
            case Down: // ⊥
                Blocks[0] = new Block(new GridCoordinate(Position.X, Position.Y), Color, this); // Origin: Pivot Point
                Blocks[1] = new Block(new GridCoordinate(Position.X + 1, Position.Y), Color, this);
                Blocks[2] = new Block(new GridCoordinate(Position.X - 1, Position.Y), Color, this);
                Blocks[3] = new Block(new GridCoordinate(Position.X, Position.Y - 1), Color, this);
                break;
            case Left: // ⊢
                Blocks[0] = new Block(new GridCoordinate(Position.X, Position.Y), Color, this); // Origin: Pivot Point
                Blocks[1] = new Block(new GridCoordinate(Position.X, Position.Y + 1), Color, this);
                Blocks[2] = new Block(new GridCoordinate(Position.X, Position.Y - 1), Color, this);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 1, Position.Y), Color, this);
                break;
        }
    }
}
public class LPiece : Piece {
    // Constructor -------------------------------------------------------------
    public LPiece(GridCoordinate position, Color color = Green, Orientation orientation = Up) : base(position, color, orientation) {
        Build(orientation);
    }

    // Methods -----------------------------------------------------------------
    public override void Build(Orientation orientation) {
        switch (orientation) {
            case Up:
                Blocks[0] = new Block(new GridCoordinate(Position.X, Position.Y), Color, this); // Origin: Pivot Point
                Blocks[1] = new Block(new GridCoordinate(Position.X, Position.Y - 1), Color, this);
                Blocks[2] = new Block(new GridCoordinate(Position.X, Position.Y + 1), Color, this);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color, this);
                break;
            case Right:
                Blocks[0] = new Block(new GridCoordinate(Position.X, Position.Y), Color, this); // Origin: Pivot Point
                Blocks[1] = new Block(new GridCoordinate(Position.X + 1, Position.Y), Color, this);
                Blocks[2] = new Block(new GridCoordinate(Position.X - 1, Position.Y), Color, this);
                Blocks[3] = new Block(new GridCoordinate(Position.X - 1, Position.Y + 1), Color, this);
                break;
            case Down:
                Blocks[0] = new Block(new GridCoordinate(Position.X, Position.Y), Color, this); // Origin: Pivot Point
                Blocks[1] = new Block(new GridCoordinate(Position.X, Position.Y + 1), Color, this);
                Blocks[2] = new Block(new GridCoordinate(Position.X, Position.Y - 1), Color, this);
                Blocks[3] = new Block(new GridCoordinate(Position.X - 1, Position.Y - 1), Color, this);
                break;
            case Left:
                Blocks[0] = new Block(new GridCoordinate(Position.X, Position.Y), Color, this); // Origin: Pivot Point
                Blocks[1] = new Block(new GridCoordinate(Position.X - 1, Position.Y), Color, this);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 1, Position.Y), Color, this);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 1, Position.Y - 1), Color, this);
                break;
        }
    }
}
public class JPiece : Piece {
    // Constructor -------------------------------------------------------------
    public JPiece(GridCoordinate position, Color color = Green, Orientation orientation = Up) : base(position, color, orientation) {
        Build(orientation);
    }

    // Methods -----------------------------------------------------------------
    public override void Build(Orientation orientation) {
        switch (orientation) {
            case Up:
                Blocks[0] = new Block(new GridCoordinate(Position.X, Position.Y), Color, this); // Origin: Pivot Point
                Blocks[1] = new Block(new GridCoordinate(Position.X, Position.Y - 1), Color, this);
                Blocks[2] = new Block(new GridCoordinate(Position.X, Position.Y + 1), Color, this);
                Blocks[3] = new Block(new GridCoordinate(Position.X - 1, Position.Y + 1), Color, this);
                break;
            case Right:
                Blocks[0] = new Block(new GridCoordinate(Position.X, Position.Y), Color, this); // Origin: Pivot Point
                Blocks[1] = new Block(new GridCoordinate(Position.X + 1, Position.Y), Color, this);
                Blocks[2] = new Block(new GridCoordinate(Position.X - 1, Position.Y), Color, this);
                Blocks[3] = new Block(new GridCoordinate(Position.X - 1, Position.Y - 1), Color, this);
                break;
            case Down:
                Blocks[0] = new Block(new GridCoordinate(Position.X, Position.Y), Color, this); // Origin: Pivot Point
                Blocks[1] = new Block(new GridCoordinate(Position.X, Position.Y + 1), Color, this);
                Blocks[2] = new Block(new GridCoordinate(Position.X, Position.Y - 1), Color, this);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 1, Position.Y - 1), Color, this);
                break;
            case Left:
                Blocks[0] = new Block(new GridCoordinate(Position.X, Position.Y), Color, this); // Origin: Pivot Point
                Blocks[1] = new Block(new GridCoordinate(Position.X - 1, Position.Y), Color, this);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 1, Position.Y), Color, this);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color, this);
                break;
        }
    }
}
public class SPiece : Piece {
    // Constructor -------------------------------------------------------------
    public SPiece(GridCoordinate position, Color color = Green, Orientation orientation = Up) : base(position, color, orientation) {
        Build(orientation);
    }

    // Methods -----------------------------------------------------------------
    public override void Build(Orientation orientation) {
        switch (orientation) {
            case Up:
                Blocks[0] = new Block(new GridCoordinate(Position.X, Position.Y), Color, this); // Origin: Pivot Point
                Blocks[1] = new Block(new GridCoordinate(Position.X - 1, Position.Y), Color, this);
                Blocks[2] = new Block(new GridCoordinate(Position.X, Position.Y - 1), Color, this);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 1, Position.Y - 1), Color, this);
                break;
            case Right:
                Blocks[0] = new Block(new GridCoordinate(Position.X, Position.Y), Color, this); // Origin: Pivot Point
                Blocks[1] = new Block(new GridCoordinate(Position.X, Position.Y - 1), Color, this);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 1, Position.Y), Color, this);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color, this);
                break;
            case Down:
                Blocks[0] = new Block(new GridCoordinate(Position.X, Position.Y), Color, this); // Origin: Pivot Point
                Blocks[1] = new Block(new GridCoordinate(Position.X + 1, Position.Y), Color, this);
                Blocks[2] = new Block(new GridCoordinate(Position.X, Position.Y + 1), Color, this);
                Blocks[3] = new Block(new GridCoordinate(Position.X - 1, Position.Y + 1), Color, this);
                break;
            case Left:
                Blocks[0] = new Block(new GridCoordinate(Position.X, Position.Y), Color, this); // Origin: Pivot Point
                Blocks[1] = new Block(new GridCoordinate(Position.X, Position.Y + 1), Color, this);
                Blocks[2] = new Block(new GridCoordinate(Position.X - 1, Position.Y), Color, this);
                Blocks[3] = new Block(new GridCoordinate(Position.X - 1, Position.Y - 1), Color, this);
                break;
        }
    }
}
public class ZPiece : Piece {
    // Constructor -------------------------------------------------------------
    public ZPiece(GridCoordinate position, Color color = Green, Orientation orientation = Up) : base(position, color, orientation) {
        Build(orientation);
    }

    // Methods -----------------------------------------------------------------
    public override void Build(Orientation orientation) {
        // All block positions are the rotated positions of the Up orientation
        switch (orientation) {
            case Up:
                Blocks[0] = new Block(new GridCoordinate(Position.X, Position.Y), Color, this); // Origin: Pivot Point
                Blocks[1] = new Block(new GridCoordinate(Position.X - 1, Position.Y - 1), Color, this);
                Blocks[2] = new Block(new GridCoordinate(Position.X, Position.Y - 1), Color, this);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 1, Position.Y), Color, this);
                break;
            case Right:
                Blocks[0] = new Block(new GridCoordinate(Position.X, Position.Y), Color, this); // Origin: Pivot Point
                Blocks[1] = new Block(new GridCoordinate(Position.X + 1, Position.Y - 1), Color, this);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 1, Position.Y), Color, this);
                Blocks[3] = new Block(new GridCoordinate(Position.X, Position.Y + 1), Color, this);
                break;
            case Down:
                Blocks[0] = new Block(new GridCoordinate(Position.X, Position.Y), Color, this); // Origin: Pivot Point
                Blocks[1] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color, this);
                Blocks[2] = new Block(new GridCoordinate(Position.X, Position.Y + 1), Color, this);
                Blocks[3] = new Block(new GridCoordinate(Position.X - 1, Position.Y), Color, this);
                break;
            case Left:
                Blocks[0] = new Block(new GridCoordinate(Position.X, Position.Y), Color, this); // Origin: Pivot Point
                Blocks[1] = new Block(new GridCoordinate(Position.X - 1, Position.Y + 1), Color, this);
                Blocks[2] = new Block(new GridCoordinate(Position.X - 1, Position.Y), Color, this);
                Blocks[3] = new Block(new GridCoordinate(Position.X, Position.Y - 1), Color, this);
                break;
        }
    }
}