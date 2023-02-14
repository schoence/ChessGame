using ChessGame.Common;

namespace ChessGame.Client
{
    public class GameStateContainer
    {
        private Chessboard _chessBoard;
        
        //public Chessboard Chessboard { get { return _chessBoard; } }

        public Action OnUpdate { get; set; }

        private void NotifySubscribers()
        {
            OnUpdate?.Invoke();
        }

        public void SetChessboard(Chessboard square)
        {
            _chessBoard = square;
            NotifySubscribers();
        }

        public Chessboard GetChessboard()
        {
            return _chessBoard;
        }
    }
}
