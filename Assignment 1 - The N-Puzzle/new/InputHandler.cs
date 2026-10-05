namespace theNPuzzle

{
    class InputHandler
    {
        private Board board;
        public InputHandler(Board board){
            this.board = board;
        }
        public void HandleKeyClick(ConsoleKeyInfo keyInfo) {

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    board.MoveTile(Direction.Up);
                    break;
                case ConsoleKey.DownArrow:
                    board.MoveTile(Direction.Down);
                    break;
                case ConsoleKey.LeftArrow:
                    board.MoveTile(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    board.MoveTile(Direction.Right);
                    break;
                default:
                    Console.WriteLine("Invalid key. Use arrow keys to move tiles.");
                    break;
            }
     
        }
    }
}
