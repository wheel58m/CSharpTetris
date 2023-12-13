// FINAL: TETRIS ///////////////////////////////////////////////////////////////
// Author: Austin Wheeler
// Class: Object-Oriented Programming Lab (CS-1415-N01)
////////////////////////////////////////////////////////////////////////////////

// TODOS //////////////////////////////////////////////////////////////////////

////////////////////////////////////////////////////////////////////////////////

// ISSUES //////////////////////////////////////////////////////////////////////
// ISSUE: Thread Race Conditions (When Dropping) Occasionally Cause:
// - Dropped Pieces to Keep Falling Past the Stopping Point
// - Game Information Loads Onto The Game Board
// - Blocks That Complete A Row Don't Clear
// - Dropped Blocks Leave Artifacts
//
// ISSUE: Rotation Occassionally Breaks Boundaries Resulting In Exception
////////////////////////////////////////////////////////////////////////////////

using Tetris.Classes;

// Set Console Properties ------------------------------------------------------
Console.Title = "Tetris";
Console.CursorVisible = false;
Utilities.Resize(45, 32);

// Initialize Game Variables ---------------------------------------------------
#region Game Variables
Board titleBoard = new();

// Create Title Pieces
List<Piece> titlePieces = new() {
    new IPiece(new(0, 4), Color.Cyan, Orientation.Up),
    new LPiece(new(1, 4), Color.Red, Orientation.Left),
    new OPiece(new(0, 2), Color.Yellow, Orientation.Up),
    new SPiece(new(3, 4), Color.Green, Orientation.Right),
    new TPiece(new(5, 4), Color.Magenta, Orientation.Left),
    new JPiece(new(7, 4), Color.Blue, Orientation.Up),
    new LPiece(new(8, 4), Color.Red, Orientation.Up),
    new IPiece(new(8, 1), Color.Blue, Orientation.Left),
    new ZPiece(new(4, 1), Color.Red, Orientation.Right),
};

// Title Text
string[] tetrisTitle = {
    @"╚══════════════════════════════╝",
    @"  _____ ___ _____ ___ ___ ___   ",
    @" |_   _| __|_   _| _ \_ _/ __|  ",
    @"   | | | _|  | | |   /| |\__ \  ",
    @"   |_| |___| |_| |_|_\___|___/  ",
    @"                                ",
    @"╔══════════════════════════════╗",
};
#endregion

// Display Title Screen --------------------------------------------------------
DisplayTitleScreen("║   Press any key to start...");
// DisplayTitleScreen("║         Game Over!");
// Console.WriteLine($"║        Score: {Game.Score}");

// Run Game --------------------------------------------------------------------
Game.Run();

// Display Game Over Screen ----------------------------------------------------
DisplayTitleScreen("║         Game Over!");

void DisplayTitleScreen(string msg) {
    Console.Clear();

    // Display Borders
    titleBoard.Display();

    // Display Title Pieces
    foreach (Piece piece in titlePieces) {
        piece.Display();
    }

    // Display Title Text
    Console.SetCursorPosition(0, 7);
    foreach (string line in tetrisTitle) {
        Console.WriteLine(line);
    }

    // Display Message & Continue Prompt
    Console.WriteLine(msg);
    if (!Game.IsRunning) {
        Console.WriteLine($"║        Score: {Game.Score}");
    } else {
        Console.WriteLine("║ The game is setup so pieces  ║");
        Console.WriteLine("║ of a random shape, position, ║");
        Console.WriteLine("║ and orientation are created. ║");
        Console.WriteLine("║                              ║");
        Console.WriteLine("║   Use the following keys to  ║");
        Console.WriteLine("║      control the pieces:     ║");
        Console.WriteLine("║                              ║");
        Console.WriteLine("║Up Arrow (↑): Rotate Clockwise║");
        Console.WriteLine("║Down Arrow (↓): Drop Piece    ║");
        Console.WriteLine("║Left Arrow (←): Move Left     ║");
        Console.WriteLine("║Down Arrow (→): Drop Piece    ║");
        
    }
    Console.ReadKey(true);
}