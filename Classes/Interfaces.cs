using System.Drawing;
namespace Classes;

public interface IBlockObject {
    public GridCoordinate Location { get; set; }
    public Color Color { get; set; }

    public void Render();
    public void Clear();
    public void Move(int x, int y);
}
