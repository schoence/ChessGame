namespace ChessGame.Common
{
    public class Knight : Piece
    {
        public Knight(PieceColor color) : base(PieceValue.Knight, color)
        {

        }

        public override async Task<List<Coords>> TheoreticallyPossibleMoves(Coords startingCoords)
        {
            List<Coords> possibleMoves = new List<Coords>();

            int x = startingCoords.x;
            int y = startingCoords.y;

            Coords oneAtATime = null;
            //
            oneAtATime = UpUpRight(startingCoords, 1);
            if (oneAtATime != null)
            {
                possibleMoves.Add(oneAtATime);
            }
            //
            oneAtATime = UpUpLeft(startingCoords, 1);
            if (oneAtATime != null)
            {
                possibleMoves.Add(oneAtATime);
            }
            //
            oneAtATime = RighRightUp(startingCoords, 1);
            if (oneAtATime != null)
            {
                possibleMoves.Add(oneAtATime);
            }
            //
            oneAtATime = RighRightDown(startingCoords, 1);
            if (oneAtATime != null)
            {
                possibleMoves.Add(oneAtATime);
            }
            //
            oneAtATime = DownDownRight(startingCoords, 1);
            if (oneAtATime != null)
            {
                possibleMoves.Add(oneAtATime);
            }
            //
            oneAtATime = DownDownLeft(startingCoords, 1);
            if (oneAtATime != null)
            {
                possibleMoves.Add(oneAtATime);
            }
            //
            oneAtATime = LeftLeftDown(startingCoords, 1);
            if (oneAtATime != null)
            {
                possibleMoves.Add(oneAtATime);
            }
            //
            oneAtATime = LeftLeftUp(startingCoords, 1);
            if (oneAtATime != null)
            {
                possibleMoves.Add(oneAtATime);
            }


            return possibleMoves;

        }

        public override async Task<bool> CanMakeMove(int sx, int sy, int ex, int ey)
        {
            Coords startingCoord = new Coords(sx, sy);
            Coords endingCoord = new Coords (ex, ey);

            List<Coords> possibleMoves = await TheoreticallyPossibleMoves(startingCoord);

            foreach (var cord in possibleMoves)
            {
                if (cord.x == endingCoord.x && cord.y == endingCoord.y)
                    return true;
            }

            return false;
        }

        private Coords? UpUpLeft(Coords startingCoords, int v)
        {
            int y = startingCoords.y - 2;
            int x = startingCoords.x - 1;

            if (IsInRange(x) && IsInRange(y))
                return new Coords(x, y);
            return null;
        }

        private Coords? LeftLeftUp(Coords startingCoords, int v)
        {
            int y = startingCoords.y - 1;
            int x = startingCoords.x - 2;

            if (IsInRange(x) && IsInRange(y))
                return new Coords(x, y);
            return null;
        }

        private Coords? LeftLeftDown(Coords startingCoords, int v)
        {
            int y = startingCoords.y + 1;
            int x = startingCoords.x - 2;

            if (IsInRange(x) && IsInRange(y))
                return new Coords(x, y);
            return null;
        }

        private Coords? DownDownLeft(Coords startingCoords, int v)
        {
            int y = startingCoords.y + 2;
            int x = startingCoords.x - 1;

            if (IsInRange(x) && IsInRange(y))
                return new Coords(x, y);
            return null;
        }

        private Coords? DownDownRight(Coords startingCoords, int v)
        {
            int y = startingCoords.y + 2;
            int x = startingCoords.x + 1;

            if (IsInRange(x) && IsInRange(y))
                return new Coords(x, y);
            return null;
        }

        private Coords? RighRightDown(Coords startingCoords, int v)
        {
            int y = startingCoords.y + 1;
            int x = startingCoords.x + 2;

            if (IsInRange(x) && IsInRange(y))
                return new Coords(x, y);
            return null;
        }

        private Coords? RighRightUp(Coords startingCoords, int v)
        {
            int y = startingCoords.y - 1;
            int x = startingCoords.x + 2;

            if (IsInRange(x) && IsInRange(y))
                return new Coords(x, y);
            return null;
        }

        private Coords? UpUpRight(Coords startingCoords, int v)
        {
            int y = startingCoords.y - 2;
            int x = startingCoords.x + 1;

            if (IsInRange(x) && IsInRange(y))
                return new Coords(x, y);
            return null;
        }

        private bool IsInRange(int i)
        {
            if (i >= 0 && i < 8)
                    return true;
            return false;
        }
    }
}