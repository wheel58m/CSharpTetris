using Tetris.Utilities;

namespace Tetris.Tests;

public class UtilityTests {
    [Test]
    public void GridPosition_DefaultValues() {
        GridPosition gridPosition = new();

        Assert.That(gridPosition.X, Is.EqualTo(0));
        Assert.That(gridPosition.Y, Is.EqualTo(0));
    }

    [Test]
    public void GridPositionToCursorPosition_Converts() {
        GridPosition gridPosition = new(2, 3);
        (int x, int y) = gridPosition.ToCursorPosition(10, 20);

        Assert.That(x, Is.EqualTo(20));
        Assert.That(y, Is.EqualTo(60));
    }
}