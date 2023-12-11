﻿// FINAL: TETRIS ///////////////////////////////////////////////////////////////
// Author: Austin Wheeler
// Class: Object-Oriented Programming Lab (CS-1415-N01)
////////////////////////////////////////////////////////////////////////////////

// TODOS //////////////////////////////////////////////////////////////////////
// TODO: Add Game Over Screen & Functionality
// TODO: Add Scoring
////////////////////////////////////////////////////////////////////////////////

// ISSUES //////////////////////////////////////////////////////////////////////
// ISSUE: Rotation Occassionally Breaks Boundaries Resulting In Exception
// ISSUE: Dropped Pieces Occassionaly Keep Falling Past The Stopping Point
////////////////////////////////////////////////////////////////////////////////

using Tetris.Classes;

// Set Console Properties ------------------------------------------------------
Console.Title = "Tetris";
Console.CursorVisible = false;
Utilities.Resize(50, 32);

// Display Title Screen --------------------------------------------------------
#region Title Screen
Console.Clear();
Board titleBoard = new();
titleBoard.Display();

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

// Display Title Pieces
foreach (Piece piece in titlePieces) {
    piece.Display();
}

// Display Title Text
string[] tetrisTitle = {
    @"╚══════════════════════════════╝",
    @"  _____ ___ _____ ___ ___ ___   ",
    @" |_   _| __|_   _| _ \_ _/ __|  ",
    @"   | | | _|  | | |   /| |\__ \  ",
    @"   |_| |___| |_| |_|_\___|___/  ",
    @"                                ",
    @"╔══════════════════════════════╗",
};

Console.SetCursorPosition(0, 7);
foreach (string line in tetrisTitle) {
    Console.WriteLine(line);
}

// Start Game Prompt
Console.Write("║   Press any key to start...");
Console.ReadKey(true);
#endregion

Game.Run();