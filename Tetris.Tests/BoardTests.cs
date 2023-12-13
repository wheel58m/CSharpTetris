using Tetris.Classes;
namespace Tetris.Tests;

public class BoardTests {
    private Board board;

    [SetUp]
    public void Setup() {
        board = new Board();
    }

    [Test]
    public void TestDropMethod() {
        // Run a Test on 100 Drops to Ensure Piece Stops
        for (int i = 0; i < 100; i++) {
            board.GeneratePiece(); // Generate a Piece
            board.ActivePiece.Drop(); // Drop the Piece
            Assert.IsTrue(board.CheckForStop()); // Check if the Piece Stopped
        }
    }
}