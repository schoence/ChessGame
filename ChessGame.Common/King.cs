namespace ChessGame.Common
{
    public class King : Piece
    {
        public King(PieceColor color) : base(PieceValue.King, color)
        {

        }

        public override async Task<List<Coords>> TheoreticallyPossibleMoves(Coords startingCoords)
        {
            List<Coords> possibleMoves = new List<Coords>();

            int x = startingCoords.x;
            int y = startingCoords.y;

            possibleMoves.AddRange(Up(startingCoords,1));
            possibleMoves.AddRange(Down(startingCoords,1));
            possibleMoves.AddRange(Left(startingCoords,1));
            possibleMoves.AddRange(Right(startingCoords,1));
            possibleMoves.AddRange(UpLeft(startingCoords,1));
            possibleMoves.AddRange(DownLeft(startingCoords,1));
            possibleMoves.AddRange(UpRight(startingCoords,1));
            possibleMoves.AddRange(DownRight(startingCoords,1));

            return possibleMoves;

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