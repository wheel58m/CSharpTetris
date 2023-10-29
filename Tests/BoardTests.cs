using Classes;
using System.Drawing;
namespace Tests;

public class BoardTests {
    [Test]
    public void OPieceWithinBounds() {
        Board board = new(0, 0) {
            ActivePiece = new OPiece(new GridCoordinate(0, 0), Color.Red) // O-Shaped Pieces have a minimum position of (0, 0), this is within bounds.
        };
        Assert.That(board.WithinBounds(board.ActivePiece), Is.True);
    }
    [Test]
    public void IPieceWithinBounds() {
        Board board = new(0, 0) {
            ActivePiece = new IPiece(new GridCoordinate(0, 0), Color.Red) // I-Shaped Pieces have a minimum position of (0, 0), this is within bounds.
        };
        Assert.That(board.WithinBounds(board.ActivePiece), Is.True);
    }
    [Test]
    public void SPieceOutsideBounds() {
        Board board = new(0, 0) {
            ActivePiece = new SPiece(new GridCoordinate(0, 0), Color.Red) // S-Shaped Pieces have a minimum position of (-1, 0), this is outside bounds.
        };
        Assert.That(board.WithinBounds(board.ActivePiece), Is.False);
    }
    [Test]
    public void ZPieceOutsideBounds() {
        Board board = new(0, 0) {
            ActivePiece = new ZPiece(new GridCoordinate(0, 0), Color.Red) // Z-Shaped Pieces have a minimum position of (-1, 0), this is outside bounds.
        };
        Assert.That(board.WithinBounds(board.ActivePiece), Is.False);
    }
    [Test]
    public void TPieceOutsideBounds() {
        Board board = new(0, 0) {
            ActivePiece = new TPiece(new GridCoordinate(0, 0), Color.Red) // T-Shaped Pieces have a minimum position of (-1, 0), this is outside bounds.
        };
        Assert.That(board.WithinBounds(board.ActivePiece), Is.False);
    }
    [Test]
    public void LPieceWithinBounds() {
        Board board = new(0, 0) {
            ActivePiece = new LPiece(new GridCoordinate(0, 0), Color.Red) // L-Shaped Pieces have a minimum position of (0, 0), this is within bounds.
        };
        Assert.That(board.WithinBounds(board.ActivePiece), Is.True);
    }
    [Test]
    public void JPieceOutsideBounds() {
        Board board = new(0, 0) {
            ActivePiece = new JPiece(new GridCoordinate(0, 0), Color.Red) // J-Shaped Pieces have a minimum position of (-1, 0), this is outside bounds.
        };
        Assert.That(board.WithinBounds(board.ActivePiece), Is.False);
    }
}