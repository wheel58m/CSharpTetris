using static Tetris.Classes.Color; // Allows the use the Color enum values without the enum name
using static Tetris.Classes.Orientation; // Allows the use the Orientation enum values without the enum name
namespace Tetris.Classes;

public abstract class Piece : IBlockContainer {
    #region Properties
    public Shape Shape { get; set; } = Shape.I;
    public Block[] Blocks { get; set; } = new Block[4];
    public Color Color { get; set; } = Green;
    public GridCoordinate Position { get; set; } = new GridCoordinate(0, 0); // Position is Pivot Point (Except for I Piece)
    public Orientation Orientation { get; set; } = Up;
    protected Dictionary<Orientation, GridCoordinate[]> BlockPositions { get; init; } = new();
    public Board ActiveBoard { get; init; } = Game.ActiveBoard;
    #endregion

    // Constructor -------------------------------------------------------------
    public Piece(GridCoordinate position, Color color = Green, Orientation orientation = Up) {
        Position = position;
        Color = color;
        Orientation = orientation;
        ActiveBoard = Game.ActiveBoard;
        Shape = Enum.Parse<Shape>(GetType().Name.Replace("Piece", ""));
    }

    // Methods -----------------------------------------------------------------
    public void Build(Orientation orientation) {
        GridCoordinate[] positions = BlockPositions[orientation];
        for (int i = 0; i < Blocks.Length; i++) {
            Blocks[i] = new Block(new GridCoordinate(Position.X + positions[i].X, Position.Y + positions[i].Y), Color, this);
        }
    }
    public void Display() {
        foreach (Block block in Blocks) {
            try {
                block.Display();
            } catch (Exception ex) when (ex is NullReferenceException || ex is ArgumentOutOfRangeException) {
                HandleException(ex, block);
            }
        }
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
        Game.ShowGameInfo();
    }
    public void Drop() {
        while (!ActiveBoard.CheckForStop()) {
            Fall(20);
        }
    }
    public void Fall(int speed) {
        Thread.Sleep(speed);
        Move(0, 1);
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
    public IPiece(GridCoordinate position, Color color = Blue, Orientation orientation = Up) : base(position, color, orientation) {
        BlockPositions = new Dictionary<Orientation, GridCoordinate[]> {
            { Up, new[] { new GridCoordinate(0, 1), new GridCoordinate(1, 1), new GridCoordinate(2, 1), new GridCoordinate(3, 1) } },
            { Right, new[] { new GridCoordinate(2, 0), new GridCoordinate(2, 1), new GridCoordinate(2, 2), new GridCoordinate(2, 3) } },
            { Down, new[] { new GridCoordinate(3, 2), new GridCoordinate(2, 2), new GridCoordinate(1, 2), new GridCoordinate(0, 2) } },
            { Left, new[] { new GridCoordinate(1, 3), new GridCoordinate(1, 2), new GridCoordinate(1, 1), new GridCoordinate(1, 0) } }
        };
        Build(orientation);
    }

    // Methods -----------------------------------------------------------------
    public override void Rotate() {
        if (Position.X < 0 || Position.X == ActiveBoard.Width - 4 || Position.Y < 0 || Position.Y > ActiveBoard.Height - 5) { return; }

        base.Rotate(); // Call the base Rotate method to rotate the piece
    }
}
public class OPiece : Piece {
    public OPiece(GridCoordinate position, Color color = Green, Orientation orientation = Up) : base(position, color, orientation) {
        BlockPositions = new Dictionary<Orientation, GridCoordinate[]> {
            { Up, new[] { new GridCoordinate(0, 0), new GridCoordinate(0, 1), new GridCoordinate(1, 0), new GridCoordinate(1, 1) } },
            { Right, new[] { new GridCoordinate(0, 0), new GridCoordinate(0, 1), new GridCoordinate(1, 0), new GridCoordinate(1, 1) } },
            { Down, new[] { new GridCoordinate(0, 0), new GridCoordinate(0, 1), new GridCoordinate(1, 0), new GridCoordinate(1, 1) } },
            { Left, new[] { new GridCoordinate(0, 0), new GridCoordinate(0, 1), new GridCoordinate(1, 0), new GridCoordinate(1, 1) } }
        };
        Build(orientation);
    }

    // Methods -----------------------------------------------------------------
    public override void Rotate() { }
}
public class TPiece : Piece {
    public TPiece(GridCoordinate position, Color color = Cyan, Orientation orientation = Up) : base(position, color, orientation) {
        BlockPositions = new Dictionary<Orientation, GridCoordinate[]> {
            { Up, new[] { new GridCoordinate(0, 0), new GridCoordinate(-1, 0), new GridCoordinate(1, 0), new GridCoordinate(0, 1) } },
            { Right, new[] { new GridCoordinate(0, 0), new GridCoordinate(0, -1), new GridCoordinate(0, 1), new GridCoordinate(-1, 0) } },
            { Down, new[] { new GridCoordinate(0, 0), new GridCoordinate(1, 0), new GridCoordinate(-1, 0), new GridCoordinate(0, -1) } },
            { Left, new[] { new GridCoordinate(0, 0), new GridCoordinate(0, 1), new GridCoordinate(0, -1), new GridCoordinate(1, 0) } }
        };
        Build(orientation);
    }
}
public class LPiece : Piece {
    public LPiece(GridCoordinate position, Color color = Red, Orientation orientation = Up) : base(position, color, orientation) {
        BlockPositions = new Dictionary<Orientation, GridCoordinate[]> {
            { Up, new[] { new GridCoordinate(0, 0), new GridCoordinate(0, -1), new GridCoordinate(0, 1), new GridCoordinate(1, 1) } },
            { Right, new[] { new GridCoordinate(0, 0), new GridCoordinate(1, 0), new GridCoordinate(-1, 0), new GridCoordinate(-1, 1) } },
            { Down, new[] { new GridCoordinate(0, 0), new GridCoordinate(0, 1), new GridCoordinate(0, -1), new GridCoordinate(-1, -1) } },
            { Left, new[] { new GridCoordinate(0, 0), new GridCoordinate(-1, 0), new GridCoordinate(1, 0), new GridCoordinate(1, -1) } }
        };
        Build(orientation);
    }
}
public class JPiece : Piece {
    public JPiece(GridCoordinate position, Color color = Magenta, Orientation orientation = Up) : base(position, color, orientation) {
        BlockPositions = new Dictionary<Orientation, GridCoordinate[]> {
            { Up, new[] { new GridCoordinate(0, 0), new GridCoordinate(0, -1), new GridCoordinate(0, 1), new GridCoordinate(-1, 1) } },
            { Right, new[] { new GridCoordinate(0, 0), new GridCoordinate(1, 0), new GridCoordinate(-1, 0), new GridCoordinate(-1, -1) } },
            { Down, new[] { new GridCoordinate(0, 0), new GridCoordinate(0, 1), new GridCoordinate(0, -1), new GridCoordinate(1, -1) } },
            { Left, new[] { new GridCoordinate(0, 0), new GridCoordinate(-1, 0), new GridCoordinate(1, 0), new GridCoordinate(1, 1) } }
        };
        Build(orientation);
    }
}
public class SPiece : Piece {
    public SPiece(GridCoordinate position, Color color = Yellow, Orientation orientation = Up) : base(position, color, orientation) {
        BlockPositions = new Dictionary<Orientation, GridCoordinate[]> {
            { Up, new[] { new GridCoordinate(0, 0), new GridCoordinate(-1, 0), new GridCoordinate(0, -1), new GridCoordinate(1, -1) } },
            { Right, new[] { new GridCoordinate(0, 0), new GridCoordinate(0, -1), new GridCoordinate(1, 0), new GridCoordinate(1, 1) } },
            { Down, new[] { new GridCoordinate(0, 0), new GridCoordinate(1, 0), new GridCoordinate(0, 1), new GridCoordinate(-1, 1) } },
            { Left, new[] { new GridCoordinate(0, 0), new GridCoordinate(0, 1), new GridCoordinate(-1, 0), new GridCoordinate(-1, -1) } }
        };
        Build(orientation);
    }
}
public class ZPiece : Piece {
    public ZPiece(GridCoordinate position, Color color = White, Orientation orientation = Up) : base(position, color, orientation) {
        BlockPositions = new Dictionary<Orientation, GridCoordinate[]> {
            { Up, new[] { new GridCoordinate(0, 0), new GridCoordinate(-1, -1), new GridCoordinate(0, -1), new GridCoordinate(1, 0) } },
            { Right, new[] { new GridCoordinate(0, 0), new GridCoordinate(1, -1), new GridCoordinate(1, 0), new GridCoordinate(0, 1) } },
            { Down, new[] { new GridCoordinate(0, 0), new GridCoordinate(1, 1), new GridCoordinate(0, 1), new GridCoordinate(-1, 0) } },
            { Left, new[] { new GridCoordinate(0, 0), new GridCoordinate(-1, 1), new GridCoordinate(-1, 0), new GridCoordinate(0, -1) } }
        };
        Build(orientation);
    }
}