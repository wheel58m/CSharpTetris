// FINAL - C# TETRIS ///////////////////////////////////////////////////////////
// Author: Austin Wheeler
// Class: Object-Oriented Programming (CS-1410-N01)
// Date: October 27, 2023
////////////////////////////////////////////////////////////////////////////////

// NOTES ///////////////////////////////////////////////////////////////////////
// - I-Shaped Pieces typically don't rotate around a block; consider changing.
////////////////////////////////////////////////////////////////////////////////
using Classes;
using System.Drawing;
namespace Tetris;

class Program {
    static void Main(string[] args) {
        Piece piece = new SPiece(new GridCoordinate(5, 5), Color.Yellow);
        piece.Render();
        
        while(true) {
            Console.ReadKey(true);
            piece.ChangeColor(Utility.GetRandomColor(piece.Color));
            piece.Rotate();

            Console.SetCursorPosition(0, 0);
        }
    }
}