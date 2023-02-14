namespace ChessGame.Common
{
    public class Pawn : Piece
    {
        public Pawn(PieceColor color) : base(PieceValue.Pawn, color)
        {
            //_squaresThreatening;
        }

        private int MoveUp(int i)
        {
            if (this.Color == PieceColor.Black)
            {
                return i + 1;
            }
            else
            {
                return i - 1;
            }
        }

        private int MoveLeft(int i)
        {
            if (this.Color == PieceColor.Black)
            {
                return i + 1;
            }
            else
            {
                return i - 1;
            }
        }

        private int MoveRight(int i)
        {
            if (this.Color == PieceColor.Black)
            {
                return i - 1;
            }
            else
            {
                return i + 1;
            }
        }

        public override async Task<List<Coords>> TheoreticallyPossibleMoves(Coords startingCoords)
        {
            List<Coords> possibleMoves = new List<Coords>();

            if (Color == PieceColor.Black)
            {
                if (startingCoords.y == 1)
                {
                    possibleMoves.AddRange(Down(startingCoords, 2));
                }
                else
                {
                    possibleMoves.AddRange(Down(startingCoords, 1));
                }
                possibleMoves.AddRange(DownLeft(startingCoords, 1));
                possibleMoves.AddRange(DownRight(startingCoords, 1));

            }
            else
            {
                if (startingCoords.y == 6)
                {
                    possibleMoves.AddRange(Up(startingCoords, 2));
                }
                else
                {
                    possibleMoves.AddRange(Up(startingCoords, 1));
                }
                possibleMoves.AddRange(UpLeft(startingCoords, 1));
                possibleMoves.AddRange(UpRight(startingCoords, 1));
            }

            return possibleMoves;
        }

        public override void SetThreateningSquares(Coords startingCoords)
        {

            List<Coords> possibleMoves = new List<Coords>();

            Coords upLeft = new Coords()
            {
                x = MoveLeft(startingCoords.x),
                y = MoveUp(startingCoords.y)
            };

            Coords upRight = new Coords()
            {
                x = MoveRight(startingCoords.x),
                y = MoveUp(startingCoords.y)
            };
            possibleMoves.Add(upLeft);
            possibleMoves.Add(upRight);

            possibleMoves = possibleMoves.Where(pm => pm.x >= 0 && pm.x < 8 && pm.y >= 0 && pm.y < 8).ToList();

            _squaresThreatening = new List<Coords>();
            _squaresThreatening.AddRange(possibleMoves);
        }

        public override async Task<bool> CanMakeMove(int sx, int sy, int ex, int ey)
        {
            Coords startingCoord = new Coords(sx, sy);
            Coords endingCoord = new Coords(ex, ey);

            List<Coords> possibleMoves = await TheoreticallyPossibleMoves(startingCoord);

            foreach (var cord in possibleMoves)
            {
                if (cord.x == endingCoord.x && cord.y == endingCoord.y)
                    return true;
            }

            return false;
        }
    }
}