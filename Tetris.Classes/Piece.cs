using static Tetris.Classes.Color; // Allows us to use the Color enum values without the enum name
using static Tetris.Classes.Orientation; // Allows us to use the Orientation enum values without the enum name
namespace Tetris.Classes;

public abstract class Piece {
    public Block[] Blocks { get; set; } = new Block[4];
    public Color Color { get; set; } = Green;
    public Orientation Orientation { get; set; } = Up;
    public Board ActiveBoard { get; init; } = Game.ActiveBoard;

    // Constructor -------------------------------------------------------------
    public Piece(Color color = Green, Orientation orientation = Up) {
        Color = color;
        Orientation = orientation;
    }

    // Methods -----------------------------------------------------------------
    public abstract void SetOrientation(Orientation orientation);
    public abstract void Rotate();
    public abstract void Move(int x, int y);
}
public class IPiece : Piece {
    // Constructor -------------------------------------------------------------
    public IPiece(Color color = Green, Orientation orientation = Up) : base(color, orientation) {}

    // Methods -----------------------------------------------------------------
    public override void SetOrientation(Orientation orientation) {}
    public override void Rotate() {}
    public override void Move(int x, int y) {}
}
public class OPiece : Piece {
    // Constructor -------------------------------------------------------------
    public OPiece(Color color = Green, Orientation orientation = Up) : base(color, orientation) {}

    // Methods -----------------------------------------------------------------
    public override void SetOrientation(Orientation orientation) {}
    public override void Rotate() {}
    public override void Move(int x, int y) {}
}
public class TPiece : Piece {
    // Constructor -------------------------------------------------------------
    public TPiece(Color color = Green, Orientation orientation = Up) : base(color, orientation) {}

    // Methods -----------------------------------------------------------------
    public override void SetOrientation(Orientation orientation) {}
    public override void Rotate() {}
    public override void Move(int x, int y) {}
}
public class LPiece : Piece {
    // Constructor -------------------------------------------------------------
    public LPiece(Color color = Green, Orientation orientation = Up) : base(color, orientation) {}

    // Methods -----------------------------------------------------------------
    public override void SetOrientation(Orientation orientation) {}
    public override void Rotate() {}
    public override void Move(int x, int y) {}
}
public class JPiece : Piece {
    // Constructor -------------------------------------------------------------
    public JPiece(Color color = Green, Orientation orientation = Up) : base(color, orientation) {}

    // Methods -----------------------------------------------------------------
    public override void SetOrientation(Orientation orientation) {}
    public override void Rotate() {}
    public override void Move(int x, int y) {}
}
public class SPiece : Piece {
    // Constructor -------------------------------------------------------------
    public SPiece(Color color = Green, Orientation orientation = Up) : base(color, orientation) {}

    // Methods -----------------------------------------------------------------
    public override void SetOrientation(Orientation orientation) {}
    public override void Rotate() {}
    public override void Move(int x, int y) {}
}
public class ZPiece : Piece {
    // Constructor -------------------------------------------------------------
    public ZPiece(Color color = Green, Orientation orientation = Up) : base(color, orientation) {}

    // Methods -----------------------------------------------------------------
    public override void SetOrientation(Orientation orientation) {}
    public override void Rotate() {}
    public override void Move(int x, int y) {}
}