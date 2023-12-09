using Tetris.Classes;
namespace Tetris.Tests;
public class ConstantsTests {
    private GridCoordinate PositiveGridCoordinate;
    private GridCoordinate NegativeGridCoordinate;

    [SetUp]
    public void Setup() {
        PositiveGridCoordinate = new(2, 3);
        NegativeGridCoordinate = new(-2, -3);
    }

    [Test]
    // Test That Positive GridCoordinate Returns Correct Values
    public void PositiveGridCoordinate_ConvertToConsoleCoordinate_ReturnsCorrectValues() {
        (int, int) result = PositiveGridCoordinate.ConvertToConsoleCoordinate();
        Assert.That(result, Is.EqualTo((7, 4)));
    }

    [Test]
    // Test That Negative GridCoordinate Returns Correct Values
    public void NegativeGridCoordinate_ConvertToConsoleCoordinate_ReturnsCorrectValues() {
        (int, int) result = NegativeGridCoordinate.ConvertToConsoleCoordinate();
        Assert.That(result, Is.EqualTo((-7, -4)));
    }
}