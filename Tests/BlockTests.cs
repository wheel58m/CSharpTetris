using Classes;

namespace Tests;

public class BlockTests {
    [Test]
    public void ConvertZerosToConsoleCoordinate() {
        GridCoordinate location1 = new(0, 0); // Location with zero values.
        Assert.That(location1.ConvertToConsoleCoordinates(), Is.EqualTo((2, 2)));
    }
    [Test]
    public void ConvertNonZerosToConsoleCoordinate() {
        GridCoordinate location2 = new(1, 1); // Location with non-zero values.
        Assert.That(location2.ConvertToConsoleCoordinates(), Is.EqualTo((Art.Block.Width + Settings.BoardBuffer, 3)));
    }
}