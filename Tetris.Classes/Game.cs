namespace Tetris.Classes;
    public static class Game {
        public static Board ActiveBoard { get; set; } = new Board();
        public static bool IsRunning { get; set; } = true;
        public static int Score { get; set; } = 0;
        public static readonly object lockObject = new();

        public static void Run() {
            InitializeGame();

            // Start a new thread for user input processing
            Thread inputThread = new Thread(ProcessUserInput);
            inputThread.Start();

            GameLoop();
        }

        private static void InitializeGame() {
            Console.CursorVisible = false; // Hide the Cursor

            // Set & Display Board
            ActiveBoard = new Board();
            ActiveBoard.Display();

            // Generate First Piece
            ActiveBoard.GeneratePiece();
        }

private static void GameLoop() {
    while (IsRunning) {
        bool checkForStop;
        bool checkForCompleteRows;

        lock (lockObject) {
            checkForStop = ActiveBoard.CheckForStop();
            checkForCompleteRows = ActiveBoard.Grid.CheckForCompleteRows();
        }

        if (!checkForStop) {
            ActiveBoard.ActivePiece?.Fall(ActiveBoard.FallSpeed);
        }
        else if (checkForCompleteRows) {
            Score += ActiveBoard.Grid.CompleteRows.Count * ActiveBoard.Grid.Width; // Update Score
            ActiveBoard.Grid.ClearRows();
            ActiveBoard.Grid.DropRows();
            ActiveBoard.FallSpeed = ActiveBoard.FallSpeed == 200 ? 200 : ActiveBoard.FallSpeed - 10; // Increase Speed
        }
        else {
            ActiveBoard.GeneratePiece();

            // Check If New Piece Is Stopped
            if (ActiveBoard.CheckForStop() && ActiveBoard.ActivePiece?.Position.Y <= 1) {
                IsRunning = false;
            }
        }
    }
}

        public static void ProcessUserInput() {
            while (IsRunning) {
                if (Console.KeyAvailable) {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    GameAction action = GetActionFromKey(key.Key);
                    lock (lockObject) {
                        PerformAction(action);
                    }
                }
            }
        }

    private static GameAction GetActionFromKey(ConsoleKey key) {
        switch (key) {
            case ConsoleKey.LeftArrow:
            case ConsoleKey.A:
                return GameAction.MoveLeft;
            case ConsoleKey.RightArrow:
            case ConsoleKey.D:
                return GameAction.MoveRight;
            case ConsoleKey.DownArrow:
                return GameAction.Drop;
            case ConsoleKey.S:
                return GameAction.MoveDown;
            case ConsoleKey.UpArrow:
                return GameAction.Rotate;
            case ConsoleKey.W:
                return GameAction.MoveUp;
            default:
                return GameAction.ShowHelp;
                // return GameAction.GeneratePiece;
        }
    }

    private static void PerformAction(GameAction action) {
        switch (action) {
            case GameAction.MoveLeft:
                ActiveBoard.ActivePiece?.Move(-1, 0);
                break;
            case GameAction.MoveRight:
                ActiveBoard.ActivePiece?.Move(1, 0);
                break;
            case GameAction.Drop:
                ActiveBoard.ActivePiece?.Drop();
                break;
            case GameAction.MoveDown:
                ActiveBoard.ActivePiece?.Move(0, 1);
                break;
            case GameAction.Rotate:
                ActiveBoard.ActivePiece?.Rotate();
                break;
            case GameAction.MoveUp:
                ActiveBoard.ActivePiece?.Move(0, -1);
                break;
            case GameAction.GeneratePiece:
                ActiveBoard.ActivePiece?.Clear();
                ActiveBoard.GeneratePiece();
                break;
            case GameAction.ShowHelp:
                DisplayControls();
                break;
        }
    }

    public static void ShowGameInfo() {
        lock (lockObject) {
            if (Utilities.Debug.ShowDebugInfo) {
                switch (Utilities.Debug.DebugInfo) {
                    case DebugItem.Game:
                        break;
                    case DebugItem.Board:
                        Utilities.Debug.DisplayBoardInfo(ActiveBoard);
                        break;
                    case DebugItem.Piece:
                        Utilities.Debug.DisplayPieceInfo(ActiveBoard.ActivePiece);
                        break;
                    case DebugItem.Block:
                        Utilities.Debug.DisplayBlocksInfo(ActiveBoard.ActivePiece.Blocks);
                        break;
                }
            } else {
                Utilities.Debug.ClearInfo();
                Console.SetCursorPosition(0, ActiveBoard.Height + 2);
                Console.WriteLine($"Fallspeed: {ActiveBoard.FallSpeed}");
                Console.WriteLine($"Score: {Score}");
            }
        }
    }
    public static void DisplayControls() {
        Utilities.Debug.ClearInfo();
        Console.SetCursorPosition(0, ActiveBoard.Height + 2);
        Console.WriteLine("(↑): Rotate (↓): Drop (←): Move (→): Drop");
    }
}

public enum GameAction { MoveLeft, MoveRight, Drop, MoveDown, Rotate, MoveUp, GeneratePiece, ShowHelp }