// FINAL - C# TETRIS ///////////////////////////////////////////////////////////
// Author: Austin Wheeler
// Class: Object-Oriented Programming (CS-1410-N01)
// Date: October 27, 2023
////////////////////////////////////////////////////////////////////////////////

// NOTES ///////////////////////////////////////////////////////////////////////
// - I-Shaped Pieces typically don't rotate around a block; consider changing.
// - Further increase utilization of the Rotation Enum.
////////////////////////////////////////////////////////////////////////////////
using Classes;
using DebugTools;
using System.Diagnostics;
using System.Drawing;
namespace Tetris;

class Program {
    static void Main(string[] args) {
        Console.Clear();
        Board board = new(0, 0);
        board.Render();
        // DebugTools.BoardDebug.FillGrid(board);
        
        while(true) {
            board.GeneratePiece();
            board.ActivePiece!.ChangeColor(Color.Blue);
            board.ActivePiece!.Render();
            PieceDebug.HighlightOrigin(board.ActivePiece!);
            // PieceDebug.HighlightCenter(board.ActivePiece!, Color.Red);
            Console.SetCursorPosition(0, board.Bounds.yMax + 3);
            Console.WriteLine($"Piece Location: {board.ActivePiece!.Location.ColumnX}, {board.ActivePiece!.Location.RowY}");
            Console.ReadKey();
            board.ActivePiece?.Clear();
        }
    }
}