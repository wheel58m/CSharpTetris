using Classes;
using System.Drawing;
namespace Tests;

public class UtilityTests {
    [Test]
    public void GetRandomColorExclude() {
        Color excludeColor = Color.Red;
        for (int i = 0; i < 100; i++) {
            Color randomColor = Utility.GetRandomColor(excludeColor);
            Assert.That(randomColor, Is.Not.EqualTo(excludeColor));
        }
    }
}
public class ConversionTests {
    [Test]
    public void ConvertZerosToConsoleCoordinates() {
        GridCoordinate gridCoordinate = new(0, 0);
        (int x, int y) = gridCoordinate.ConvertToConsoleCoordinates();
        Assert.That(x, Is.EqualTo(2));
        Assert.That(y, Is.EqualTo(2));
    }
    [Test]
    public void ConvertIntegersToConsoleCoordinates() {
        GridCoordinate gridCoordinate = new(1, 1);
        (int x, int y) = gridCoordinate.ConvertToConsoleCoordinates();
        Assert.That(x, Is.EqualTo(5));
        Assert.That(y, Is.EqualTo(3));
    }
}