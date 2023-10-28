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