# FINAL PROJECT: C# TETRIS

**Author:** Austin Wheeler
**Class:** Object-Oriented Programming Lab (CS-1415-N01)

## TODOS

## KNOWN ISSUES

- Thread Race Conditions (When Dropping) Occasionally Cause:
    - Dropped Pieces Continuing to Fall Past the Stopping Point
    - Game Information Overlapping on the Game Board (Debug Info and/or Score)
    - Blocks That Complete A Row Don't Clear
    - Dropped Blocks Leave Artifacts
    - Pieces Breaking Through Boundaries
    - Game Will Clear More Rows Than Completed

- Rotation Occasionally Breaks Boundaries Resulting In Exception
- IPiece Rotation is Blocked at the Incorrect Position

## DESCRIPTION
This project is a console-based implementation of the classic game Tetris. The game is implemented in C# and uses a static class Game to manage the game state and handle user inputs.

Like the classic game, a single piece will generate at the top with a randomized x position, shape, color, and orientation. The generated piece will fall at a speed that increments with each completed row, the score will increment by 1 with each cleared block (10 per row).

### Controls
- **Up Arrow (↑):** Rotates Piece Clockwise
- **Down Arrow (↓):** Drops Piece (Disables Movement)
- **Left Arrow (←):** Moves Piece Left 1 Unit
- **Down Arrow (→):** Moves Piece Right 1 Unit

## DEBUGGING
This project includes a set of debug tools and settings found in the Utilities.cs file. This includes:
- Option to Disable Falling
- Option to Display Properties for Game, Board, Piece, or Blocks
- Option to Show Block Indexes

## TESTING
The project currently includes unit tests for:
- GridCoordinate Record and its conversion method.
- Drop Test to ensure pieces don't drop beneath the stopping point (currently not functioning).

## LICENSE & USUAGE
This project is licensed under the MIT License and is suitable for personal and private projects. It is not intended for commercial use and is not affiliated with Tetris. Developed for educational purposes, this project is not intended for use or distribution outside of my programming class.