using Tetris.Classes;
using Tetris.Utilities;

namespace Tetris.Tests;

public class ClassTests {
    [Test]
    public void Block_DefaultValues() {
        Block block = new();

        Assert.That(block.Color, Is.EqualTo(ConsoleColor.White));
        Assert.That(block.Position.X, Is.EqualTo(0));
        Assert.That(block.Position.Y, Is.EqualTo(0));
    }
    [Test]
    public void Block_Constructor() {
        Block block = new(ConsoleColor.Red, new(2, 3));

        Assert.That(block.Color, Is.EqualTo(ConsoleColor.Red));
        Assert.That(block.Position.X, Is.EqualTo(2));
        Assert.That(block.Position.Y, Is.EqualTo(3));
    }
    [Test]
    public void Block_Move() {
        Block block = new(ConsoleColor.Red, new(2, 3));
        block.Move(1, 2);

        Assert.That(block.Position.X, Is.EqualTo(3));
        Assert.That(block.Position.Y, Is.EqualTo(5));
    }
}