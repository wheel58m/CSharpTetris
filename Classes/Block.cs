﻿using System.Drawing;
namespace Classes;

public class Block : IBlockObject {
    public GridCoordinate Location { get; set; } // How can I make this private?
    public Color Color { get; set; }

    public Block(GridCoordinate location, Color color) {
        Location = location;
        Color = color;
    }

    public void Render() {
        (int x, int y) = Location.ConvertToConsoleCoordinates();
        Console.SetCursorPosition(x, y);

        Console.ForegroundColor = Utility.ColorMap[Color];
        Console.Write(Art.Block.Art);
        Console.ResetColor();
    }
    public void Clear() {
        (int x, int y) = Location.ConvertToConsoleCoordinates();
        Console.SetCursorPosition(x, y);
        for (int i = 0; i < Art.Block.Art.Length; i++) {
            Console.Write(" ");
        }
    }
    public void Move(int x, int y, bool rerender = false) {
        if (rerender) {
            Clear(); // Erase the block from the console // This conflicts with the Piece.Move() method because it can clear a block that was already cleared.
        }
        Location = new GridCoordinate(Location.ColumnX + x, Location.RowY + y); // Is this bad practice?
        if (rerender) {
            Render();
        }
    }
}