using ChessGame.Common;

namespace ChessGame.Client
{
    public class GameService
    {
        private readonly GameStateContainer _state;
        private Game _game;
        public GameService(GameStateContainer state)
        {
            _state = state;
            _game = new Game();
            _state.SetChessboard(_game.ChessBoard);
        }

        public void SetHighlitedSquares(List<Coords> coords)
        {
            Chessboard board = _state.GetChessboard();

            board.ResetHighlightedSquares();
            
            foreach(var coord in coords)
            {
                board.Board[coord.x, coord.y].SetHighlighted(true);
            }

            _state.SetChessboard(board);
        }
    }
}
