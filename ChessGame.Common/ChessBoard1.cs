namespace ChessGame.Common
{
    public class Chessboard
    {
        private Square[,] _board;

        public Square[,] Board { get { return _board; } }

        public Chessboard()
        {
            SetNewBoard();
        }
        private void SetNewBoard()
        {
            _board = new Square[8, 8];
            bool color = true;
            bool startColor = false;

            for (int x = 0; x < 8; x++)
            {
                color = !startColor;
                for (int y = 0; y < 8; y++)
                {
                    _board[x, y] = new Square(x, y, color ? SquareColor.White : SquareColor.Black);
                    color = !color;
                }
                startColor = !startColor;
            }

            _board[0, 0].SetPiece(new Rook(PieceColor.Black));
            _board[1, 0].SetPiece(new Knight(PieceColor.Black));
            _board[2, 0].SetPiece(new Bishop(PieceColor.Black));
            _board[3, 0].SetPiece(new Queen(PieceColor.Black));
            _board[4, 0].SetPiece(new King(PieceColor.Black));
            _board[5, 0].SetPiece(new Bishop(PieceColor.Black));
            _board[6, 0].SetPiece(new Knight(PieceColor.Black));
            _board[7, 0].SetPiece(new Rook(PieceColor.Black));

            _board[0, 1].SetPiece(new Pawn(PieceColor.Black));
            _board[1, 1].SetPiece(new Pawn(PieceColor.Black));
            _board[2, 1].SetPiece(new Pawn(PieceColor.Black));
            _board[3, 1].SetPiece(new Pawn(PieceColor.Black));
            _board[4, 1].SetPiece(new Pawn(PieceColor.Black));
            _board[5, 1].SetPiece(new Pawn(PieceColor.Black));
            _board[6, 1].SetPiece(new Pawn(PieceColor.Black));
            _board[7, 1].SetPiece(new Pawn(PieceColor.Black));

            _board[0, 6].SetPiece(new Pawn(PieceColor.White));
            _board[1, 6].SetPiece(new Pawn(PieceColor.White));
            _board[2, 6].SetPiece(new Pawn(PieceColor.White));
            _board[3, 6].SetPiece(new Pawn(PieceColor.White));
            _board[4, 6].SetPiece(new Pawn(PieceColor.White));
            _board[5, 6].SetPiece(new Pawn(PieceColor.White));
            _board[6, 6].SetPiece(new Pawn(PieceColor.White));
            _board[7, 6].SetPiece(new Pawn(PieceColor.White));

            _board[0, 7].SetPiece(new Rook(PieceColor.White));
            _board[1, 7].SetPiece(new Knight(PieceColor.White));
            _board[2, 7].SetPiece(new Bishop(PieceColor.White));
            _board[3, 7].SetPiece(new Queen(PieceColor.White));
            _board[4, 7].SetPiece(new King(PieceColor.White));
            _board[5, 7].SetPiece(new Bishop(PieceColor.White));
            _board[6, 7].SetPiece(new Knight(PieceColor.White));
            _board[7, 7].SetPiece(new Rook(PieceColor.White));
        }
        public Piece? GetPiece(int x, int y)
        {
            return Board[x, y].Piece;
        }

        public Square GetSquare(int x, int y)
        {
            return Board[x, y];
        }

        public bool IsMoveInBoard(int? sx, int? sy, int? ex, int? ey)
        {
            if (sx < 0 || sx > 7)
                return false;

            if (sy < 0 || sy > 7)
                return false;

            if (ex < 0 || ex > 7)
                return false;

            if (ey < 0 || ey > 7)
                return false;

            return true;
        }

        public bool IsSquareOccupiedByColor(int ex, int ey, PieceColor color)
        {
            Square square = GetSquare(ex, ey);

            Piece piece = square.Piece;
            
            if (piece == null)
                return false;

            if (piece.Color == color)
                return true;

            return false;
        }

        public void MovePiece(int sx, int sy, int ex, int ey)
        {
            Board[ex, ey].SetPiece(Board[sx, sy].Piece);
            Board[sx, sy].RemovePiece();
        }        

        public (int sx, int sy) ConvertSquareToCoords(string startSquare)
        {
            int x = 100, y = 100;
            char xchar, ychar;

            xchar = startSquare[0];
            ychar = startSquare[1];

            switch (char.ToUpper(xchar))
            {
                case 'A':
                    x = 0;
                    break;
                case 'B':
                    x = 1;
                    break;
                case 'C':
                    x = 2;
                    break;
                case 'D':
                    x = 3;
                    break;
                case 'E':
                    x = 4;
                    break;
                case 'F':
                    x = 5;
                    break;
                case 'G':
                    x = 6;
                    break;
                case 'H':
                    x = 7;
                    break;
            }

            switch (char.ToUpper(ychar))
            {
                case '8':
                    y = 0;
                    break;
                case '7':
                    y = 1;
                    break;
                case '6':
                    y = 2;
                    break;
                case '5':
                    y = 3;
                    break;
                case '4':
                    y = 4;
                    break;
                case '3':
                    y = 5;
                    break;
                case '2':
                    y = 6;
                    break;
                case '1':
                    y = 7;
                    break;
            }

            return (x, y);
        }

        public void SetHighlightedSquares(List<Coords> coords)
        {
            foreach (var coord in coords)
            {
                Board[coord.x, coord.y].SetHighlighted(true);
            }
        }

        public void ResetHighlightedSquares()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Board[x, y].SetHighlighted(false);
                }
            }
        }
    }
}