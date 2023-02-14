namespace ChessGame.Common
{
    public class Rook : Piece
    {
        public Rook(PieceColor color) : base(PieceValue.Rook, color)
        {

        }

        public override async Task<List<Coords>> TheoreticallyPossibleMoves(Coords startingCoords)
        {
            List<Coords> possibleMoves = new List<Coords>();

            int x = startingCoords.x;
            int y = startingCoords.y;

            possibleMoves.AddRange(Up(startingCoords));
            possibleMoves.AddRange(Down(startingCoords));
            possibleMoves.AddRange(Left(startingCoords));
            possibleMoves.AddRange(Right(startingCoords));

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