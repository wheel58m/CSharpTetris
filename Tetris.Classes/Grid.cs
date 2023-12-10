using System.Linq;
namespace Tetris.Classes;

public class Grid {
    public int Width { get; init; }
    public int Height { get; init; }
    public List<Row> Rows { get; set; }
    public List<Row> CompleteRows { get; set; } = new List<Row>();

    // Constructor -------------------------------------------------------------
    public Grid(int width = 10, int height = 30) {
        Width = width;
        Height = height;
        Rows = new List<Row>();

        // Initialize Rows
        for (int i = 0; i < Height; i++) {
            Rows.Add(new Row(Width, i, this));
        }
    }

    // Methods -----------------------------------------------------------------
    public bool CheckForCompleteRows() {
        CompleteRows = Rows.Where(row => row.IsFull()).ToList(); // Get List of Complete Rows
        return CompleteRows.Any(); // Return True if Any Rows Are Complete
    }
    public void ClearRows() {
        foreach (Row row in CompleteRows) {
            row.ClearBlocks();
        }

        CompleteRows.Clear(); // Empty List of Complete Rows
    }
    public void DropRows() {
        // Check If Each Row Is Empty (Starting From Bottom) & Move Contents Down
        for (int i = Rows.Count - 1; i >= 0; i--) {
            if (Rows[i].IsEmpty()) {
                int dropSize = 0; // Number of Empty Rows Below

                for (int j = i; j >= 0; j--) {
                    if (Rows[j].IsEmpty()) {
                        dropSize++;
                        continue;
                    }

                    // Move Blocks Down By Number of Empty Rows Below
                    Rows[j].MoveBlocksDown(dropSize);
                }
            }
        }
    }
}

public class Row : IBlockContainer {
    public Grid Container { get; set; } = null!;
    public int RowID { get; set; } = 0;
    public Block[] Blocks { get; set; } = new Block[10];

    // Constructor -------------------------------------------------------------
    public Row(int width, int rowID = 0, Grid container = null!) {
        Container = container;
        RowID = rowID;
        Blocks = new Block[width];
    }

    // Methods -----------------------------------------------------------------
    public void ClearBlocks() {
        for (int i = 0; i < Blocks.Length; i++) {
            Blocks[i]?.Clear(); // Clear Block From Console If Not Null
            Blocks[i] = null!; // Remove Block Reference
        }
    }
    public void MoveBlocksDown(int dropSize = 1) {
        // Loop Through Each Block In Row
        for (int i = 0; i < Blocks.Length; i++) {
            Block blockRef = Blocks[i]; // Save Block Reference

            if (blockRef == null) continue; // Skip if the block is null

            if (RowID < Container.Height - 1) Container.Rows[RowID + dropSize].Blocks[i] = blockRef; // Move Block References To Row Below

            blockRef.Container = Container.Rows[RowID + dropSize]; // Update Block Container Reference

            // Rerender Block In New Position
            blockRef.Clear(); // Clear Block Symbol
            blockRef.Move(0, dropSize); // Move Block Down
            blockRef.Display(); // Display Block

            Blocks[i] = null!; // Remove The Block (Reference) From The Current Row
        }
    }
    public bool IsEmpty() => Blocks.All(block => block == null); // Check If All Indexes Are Null
    public bool IsFull() => Blocks.All(block => block != null); // Check If All Indexes Have Blocks
}