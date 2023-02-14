using ChessGame.Common;

namespace ChessGame.Client
{
    public class SquareStateContainer
    {
        private Square _square;

        public Square Square { get { return _square; } }

        public Action OnUpdate { get; set; }

        private void NotifySubscribers()
        {
            OnUpdate?.Invoke();
        }

        public void SetSquare(Square square)
        {
            _square = square;
            NotifySubscribers();
        }
    }
}
