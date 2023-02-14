namespace ChessGame.Common
{
    public class Piece
    {
        private PieceValue _value;
        private PieceColor _color;
        internal List<Coords> _squaresThreatening;

        public Piece(PieceValue value, PieceColor color)
        {
            _value = value;
            _color = color;
            _squaresThreatening = new List<Coords>();
        }

        //public IEnumerable<string> SquaresThreatening { get; set; }
        public bool IsPinned { get; set; }
        public PieceValue Value { get { return _value; } }
        public PieceColor Color { get { return _color; } }
        public List<Coords> SquaresThreatening { get { return _squaresThreatening; } }

        public virtual async Task<bool> CanMakeMove(int sx, int sy, int ex, int ey)
        {
            throw new NotImplementedException("Base Piece move not impletemented.");
        }

        public virtual async Task<List<Coords>> TheoreticallyPossibleMoves(Coords startingCoords)
        {
            throw new NotImplementedException("Base Piece theortically possible moves not implemented.");
        }

        public virtual void SetThreateningSquares(Coords startingCoords)
        {
            //throw new NotImplementedException("SetThreateningSquares not implemented.");
        }

        internal bool DoesPossibleMoveContainEndingMove(List<Coords> possibleMoves, Coords endingCoords)
        {
            foreach (var coord in possibleMoves)
            {
                if (coord.x == endingCoords.x && coord.y == endingCoords.y)
                {
                    return true;
                }
            }
            return false;
        }

        internal IEnumerable<Coords> Right(Coords startingCoords, int times = 8)
        {
            List<Coords> possibleMoves = new List<Coords>();
            int x = startingCoords.x;
            int y = startingCoords.y;
            int i = 1;

            while (x < 7 && y >= 0 && x >= 0 && y < 8 && i <= times)
            {
                x = x + 1;
                possibleMoves.Add(new Coords(x, y));
                i = i + 1;
            }
            return possibleMoves;
        }

        internal IEnumerable<Coords> Left(Coords startingCoords, int times = 8)
        {
            List<Coords> possibleMoves = new List<Coords>();
            int x = startingCoords.x;
            int y = startingCoords.y;
            int i = 1;

            while (x > 0 && y >= 0 && x < 8 && y < 8 && i <= times)
            {
                x = x - 1;
                possibleMoves.Add(new Coords(x, y));
                i = i + 1;
            }
            return possibleMoves;
        }

        internal IEnumerable<Coords> Down(Coords startingCoords, int times = 8)
        {
            List<Coords> possibleMoves = new List<Coords>();
            int x = startingCoords.x;
            int y = startingCoords.y;
            int i = 1;

            while (x >= 0 && y >= 0 && x < 8 && y < 7 && i <= times)
            {
                y = y + 1;
                possibleMoves.Add(new Coords(x, y));
                i = i + 1;
            }
            return possibleMoves;
        }

        internal IEnumerable<Coords> Up(Coords startingCoords, int times = 8)
        {
            List<Coords> possibleMoves = new List<Coords>();
            int x = startingCoords.x;
            int y = startingCoords.y;
            int i = 1;

            while (x >= 0 && y > 0 && x < 8 && y < 8 && i <= times)
            {
                y = y - 1;
                possibleMoves.Add(new Coords(x, y));
                i = i + 1;
            }
            
            return possibleMoves;
        }

        internal List<Coords> UpLeft(Coords startingCoords, int times = 8)
        {
            List<Coords> possibleMoves = new List<Coords>();
            int x = startingCoords.x;
            int y = startingCoords.y;
            int i = 1;

            while (x > 0 && y > 0 && x < 8 && y < 8 && i <= times)
            {
                x = x - 1;
                y = y - 1;
                possibleMoves.Add(new Coords()
                {
                    x = x,
                    y = y,
                });
                i = i + 1;
            }
            return possibleMoves;
        }

        internal List<Coords> DownLeft(Coords startingCoords, int times = 8)
        {
            List<Coords> possibleMoves = new List<Coords>();
            int x = startingCoords.x;
            int y = startingCoords.y;
            int i = 1;

            while (x > 0 && y < 7 && x < 8 && y >= 0 && i <= times)
            {
                x = x - 1;
                y = y + 1;
                possibleMoves.Add(new Coords()
                {
                    x = x,
                    y = y,
                });
                i = i + 1;
            }
            return possibleMoves;
        }

        internal List<Coords> UpRight(Coords startingCoords, int times = 8)
        {
            List<Coords> possibleMoves = new List<Coords>();
            int x = startingCoords.x;
            int y = startingCoords.y;
            int i = 1;

            while (x < 7 && y > 0 && x > 0 && y < 8 && i <= times)
            {
                x = x + 1;
                y = y - 1;
                possibleMoves.Add(new Coords()
                {
                    x = x,
                    y = y,
                });
                i = i + 1;
            }
            return possibleMoves;
        }

        internal List<Coords> DownRight(Coords startingCoords, int times = 8)
        {
            List<Coords> possibleMoves = new List<Coords>();
            int x = startingCoords.x;
            int y = startingCoords.y;
            int i = 1;

            while (x < 7 && y < 7 && x >= 0 && y >= 0 && i <= times)
            {
                x = x + 1;
                y = y + 1;
                possibleMoves.Add(new Coords()
                {
                    x = x,
                    y = y,
                });
                i = i + 1;
            }
            return possibleMoves;
        }

    }

    public class Coords
    {
        public int x { get; set; }
        public int y { get; set; }

        public Coords()
        {

        }
        public Coords(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Move
    {
        public List<Coords> PossibleCoords { get; set; }
        public Coords StartingCoords { get; set; }
        public PieceValue PieceType { get; set; }
    }
}