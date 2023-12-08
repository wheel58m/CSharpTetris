using static Tetris.Classes.Color; // Allows us to use the Color enum values without the enum name
using static Tetris.Classes.Orientation; // Allows us to use the Orientation enum values without the enum name
namespace Tetris.Classes;

public abstract class Piece {
    public Shape Shape { get; set; } = Shape.I;
    public Block[] Blocks { get; set; } = new Block[4];
    public Color Color { get; set; } = Green;
    public GridCoordinate Position { get; set; } = new GridCoordinate(0, 0);
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
            try { block.Display();
            } catch (NullReferenceException ex) {
                Console.WriteLine($"NullReferenceException caught: {ex.Message}");
                Console.WriteLine($"Piece Details: Shape: {Shape}, Block Count: {Blocks.Length}, Color: {Color}, Position: ({Position.X}, {Position.Y}), Orientation: {Orientation}, ActiveBoard: {ActiveBoard}");
                Console.WriteLine($"Block Details: Position: ({block.Position.X}, {block.Position.Y}), Symbol: {Block.Symbol}, Color: {block.Color}");
            } catch (ArgumentOutOfRangeException ex) {
                Console.WriteLine($"ArgumentOutOfRangeException caught: {ex.Message}");
                Console.WriteLine($"Piece Details: Shape: {Shape}, Block Count: {Blocks.Length}, Color: {Color}, Position: ({Position.X}, {Position.Y}), Orientation: {Orientation}, ActiveBoard: {ActiveBoard}");
                Console.WriteLine($"Block Details: Position: ({block.Position.X}, {block.Position.Y}), Symbol: {Block.Symbol}, Color: {block.Color}");
            }
        }
        // Console.SetCursorPosition(0, ActiveBoard.Height);
    }
    public void Clear() {
        foreach (Block block in Blocks) {
            try { block.Clear();
            } catch (NullReferenceException ex) {
                Console.WriteLine($"NullReferenceException caught: {ex.Message}");
                Console.WriteLine($"Piece Details: Shape: {Shape}, Block Count: {Blocks.Length}, Color: {Color}, Position: ({Position.X}, {Position.Y}), Orientation: {Orientation}, ActiveBoard: {ActiveBoard}");
                Console.WriteLine($"Block Details: Position: ({block.Position.X}, {block.Position.Y}), Symbol: {Block.Symbol}, Color: {block.Color}");
            } catch (ArgumentOutOfRangeException ex) {
                Console.WriteLine($"ArgumentOutOfRangeException caught: {ex.Message}");
                Console.WriteLine($"Piece Details: Shape: {Shape}, Block Count: {Blocks.Length}, Color: {Color}, Position: ({Position.X}, {Position.Y}), Orientation: {Orientation}, ActiveBoard: {ActiveBoard}");
                Console.WriteLine($"Block Details: Position: ({block.Position.X}, {block.Position.Y}), Symbol: {Block.Symbol}, Color: {block.Color}");
            }
        }
    }
    public void Rotate() {
        Clear();
        Orientation = (Orientation)(((int)Orientation == 3 ? 0 : (int)Orientation + 1) % 4);
        Build(Orientation);
        Display();
    }
    public void Move(int x, int y) {
        Clear();
        Position = new GridCoordinate(Position.X + x, Position.Y + y);

        foreach (Block block in Blocks) {
            block.Move(x, y);
        }

        Display();
    }
}
public class IPiece : Piece {
    // Constructor -------------------------------------------------------------
    public IPiece(GridCoordinate position, Color color = Green, Orientation orientation = Up) : base(position, color, orientation) {
        Build(orientation);
    }

    // Methods -----------------------------------------------------------------
    public override void Build(Orientation orientation) {
        switch (orientation) {
            case Right:
                Blocks[0] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 0), Color);
                Blocks[1] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 1), Color);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 2), Color);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 3), Color);
                break;
            case Up:
                Blocks[0] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 1), Color);
                Blocks[1] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 1), Color);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 3, Position.Y + 1), Color);
                break;
            case Left:
                Blocks[0] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 0), Color);
                Blocks[1] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 2), Color);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 3), Color);
                break;
            case Down:
                Blocks[0] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 2), Color);
                Blocks[1] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 2), Color);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 2), Color);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 3, Position.Y + 2), Color);
                break;
        }
    }
}
public class OPiece : Piece {
    // Constructor -------------------------------------------------------------
    public OPiece(GridCoordinate position, Color color = Green, Orientation orientation = Up) : base(position, color, orientation) {
        Build(orientation);
    }

    // Methods -----------------------------------------------------------------
    public override void Build(Orientation orientation) {
        Blocks[0] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 0), Color);
        Blocks[1] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 0), Color);
        Blocks[2] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 1), Color);
        Blocks[3] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color);
    }
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
                Blocks[0] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 0), Color);
                Blocks[1] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 0), Color);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 0), Color);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color);
                break;
            case Left: // ⊢
                Blocks[0] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 0), Color);
                Blocks[1] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 1), Color);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 2), Color);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color);
                break;
            case Down: // ⊥
                Blocks[0] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 2), Color);
                Blocks[1] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 2), Color);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 2), Color);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color);
                break;
            case Right: // ⊣
                Blocks[0] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 0), Color);
                Blocks[1] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 1), Color);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 2), Color);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color);
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
                Blocks[0] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 0), Color);
                Blocks[1] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 1), Color);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 2), Color);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 2), Color);
                break;
            case Right:
                Blocks[0] = new Block(new GridCoordinate(Position.X - 1, Position.Y + 1), Color);
                Blocks[1] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 1), Color);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color);
                Blocks[3] = new Block(new GridCoordinate(Position.X - 1, Position.Y + 2), Color);
                break;
            case Down:
                Blocks[0] = new Block(new GridCoordinate(Position.X - 1, Position.Y + 0), Color);
                Blocks[1] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 0), Color);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 1), Color);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 2), Color);
                break;
            case Left:
                Blocks[0] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 0), Color);
                Blocks[1] = new Block(new GridCoordinate(Position.X - 1, Position.Y + 1), Color);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 1), Color);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color);
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
            case Up: // ┘
                Blocks[0] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 0), Color);
                Blocks[1] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 2), Color);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 2), Color);
                break;
            case Right: // ﹂
                Blocks[0] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 0), Color);
                Blocks[1] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 1), Color);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 1), Color);
                break;
            case Down: // └
                Blocks[0] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 0), Color);
                Blocks[1] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 0), Color);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 2), Color);
                break;
            case Left: // ﹁
                Blocks[0] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 1), Color);
                Blocks[1] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 1), Color);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 2), Color);
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
                Blocks[0] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 0), Color);
                Blocks[1] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 0), Color);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 1), Color);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color);
                break;
            case Right:
                Blocks[0] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 0), Color);
                Blocks[1] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 1), Color);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 2), Color);
                break;
            case Down:
                Blocks[0] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color);
                Blocks[1] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 1), Color);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 2), Color);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 2), Color);
                break;
            case Left:
                Blocks[0] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 0), Color);
                Blocks[1] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 1), Color);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 2), Color);
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
        switch (orientation) {
            case Up:
                Blocks[0] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 0), Color);
                Blocks[1] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 0), Color);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 1), Color);
                break;
            case Right:
                Blocks[0] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 0), Color);
                Blocks[1] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 1), Color);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 2), Color);
                break;
            case Down:
                Blocks[0] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 1), Color);
                Blocks[1] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 2), Color);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 2, Position.Y + 2), Color);
                break;
            case Left:
                Blocks[0] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 0), Color);
                Blocks[1] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 1), Color);
                Blocks[2] = new Block(new GridCoordinate(Position.X + 1, Position.Y + 1), Color);
                Blocks[3] = new Block(new GridCoordinate(Position.X + 0, Position.Y + 2), Color);
                break;
        }
    }
}