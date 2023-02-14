using System.Drawing;

namespace ChessGame.Common
{
    public class Game
    {
        private Chessboard _chessBoard;
        public Chessboard ChessBoard { get { return _chessBoard; } }

        public Game()
        {
            _chessBoard = new Chessboard();
        }
        public async Task<bool> MovePiece(string startSquare, string endSquare)
        {
            int sx, sy, ex, ey;

            (sx, sy) = _chessBoard.ConvertSquareToCoords(startSquare);
            (ex, ey) = _chessBoard.ConvertSquareToCoords(endSquare);

            return await MovePiece(sx, sy, ex, ey);
        }

        public async Task<bool> MovePiece(int sx, int sy, int ex, int ey)
        {
            Square square = _chessBoard.GetSquare(sx, sy);
            if (square == null)
                return false;

            Piece? pieceToMove = square.Piece;

            if (pieceToMove == null)
                return false;

            if (!await pieceToMove.CanMakeMove(sx, sy, ex, ey))
                return false;

            if (!_chessBoard.IsMoveInBoard(sx, sy, ex, ey))
                return false;

            if (_chessBoard.IsSquareOccupiedByColor(ex, ey, pieceToMove.Color))
            {
                return false;
            }

            _chessBoard.MovePiece(sx, sy, ex, ey);
            return true;
        }

        public void SetThreateningPieces()
        {
            foreach(Square square in _chessBoard.Board)
            {
                if (square.IsOccupied)
                {
                    square.Piece?.SetThreateningSquares(square.Coords);
                    foreach(var sq in square.Piece.SquaresThreatening)
                    {
                        _chessBoard.Board[sq.x, sq.y].AddThreatenedBy(sq);
                    }
                }
            }
        }

        public void SetPossibleMoves(Coords coords)
        {
            _chessBoard.Board[coords.x, coords.y].Piece.TheoreticallyPossibleMoves(coords);
        }

        public void SetHighlightedSquares(List<Coords> coords)
        {
            RemoveHighlightedSquares();

            _chessBoard.SetHighlightedSquares(coords);
            
        }

        public void RemoveHighlightedSquares()
        {
            _chessBoard.ResetHighlightedSquares();
        }
    }
}